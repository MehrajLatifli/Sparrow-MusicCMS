using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using MusicCMS_API.Database.IdentityAuth;
using MusicCMS_API.Models;
using MusicCMS_Business.Abstract;
using MusicCMS_Entities.Concrete.DatabaseFirst;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MusicCMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : Controller
    {
        private readonly UserManager<CustomUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<CustomUser> _signInManager;

        public AuthenticateController(UserManager<CustomUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, SignInManager<CustomUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _signInManager = signInManager;
        }

        List<IdentityError> errorList =new List<IdentityError>();

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);

            if (userExists != null)
                return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "User already exists!" });
            

            CustomUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)

                errorList = result.Errors.ToList();

            var errors = string.Join(", ", errorList.Select(e => e.Description));

            return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "User creation failed! "+' '+errors });
            


        }


        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);

            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });
            

            CustomUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed!" });
            

            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            

            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));
            

            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
               await _userManager.AddToRoleAsync(user, UserRoles.Admin);

            

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });

        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user =await _userManager.FindByNameAsync(model.Username);

            var signInResult = await this._signInManager.PasswordSignInAsync(user, model.Password, false, false);

            if (!signInResult.Succeeded)
            {
                return Unauthorized();
            }

            if (user!=null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles= await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

                var token = new JwtSecurityToken(

                    issuer: _configuration["JWT:ValidateIssuer"],
                    audience: _configuration["JWT:ValidateAudience"],
                    expires: DateTime.Now.AddDays(1),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)

                );

                return Ok(new { token=new JwtSecurityTokenHandler().WriteToken(token), expiration=token.ValidTo });
            }

            return Unauthorized();
        }


        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> Logout([FromBody] LoginModel model)
        {
            await this._signInManager.SignOutAsync();

            return Ok(new Response { Status = "Success", Message = "User logout!" });
        }

        [HttpGet("getusers")]
        public async Task<IActionResult> GetUsers()
        {
            var list = new ObservableCollection<RegisterModel>();

            foreach (var user in _userManager.Users.ToList())
            {
                list.Add(new RegisterModel()
                {
                    Username = user.UserName,
                    Email =user.Email,
                    Password=user.PasswordHash.ToString(),
                });
            }

            return Ok(list);
        }


    }


}
