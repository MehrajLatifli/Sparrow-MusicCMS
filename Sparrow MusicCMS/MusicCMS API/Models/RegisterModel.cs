using System.ComponentModel.DataAnnotations;

namespace MusicCMS_API.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "UserEmail is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "UserPassword is required")]
        public string Password { get; set; }


    }
}
