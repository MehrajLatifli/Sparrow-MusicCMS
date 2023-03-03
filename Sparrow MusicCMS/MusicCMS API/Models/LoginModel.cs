using System.ComponentModel.DataAnnotations;

namespace MusicCMS_API.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "UserPassword is required")]
        public string Password { get; set; }
    }
}
