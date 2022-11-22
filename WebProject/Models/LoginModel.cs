using System.ComponentModel.DataAnnotations;

namespace WebProject.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Must type username")]
        public string? Username { get; set; }

        [Required(ErrorMessage ="Must type password")]
        public string? Password { get; set; }
    }
}
