using System.ComponentModel.DataAnnotations;

namespace BlogApplication.Model
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The Password and Conformation Password do not match")]
        public string ConfirmPassword { get; set;}
    }
}
