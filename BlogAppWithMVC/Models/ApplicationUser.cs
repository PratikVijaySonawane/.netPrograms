using Microsoft.AspNetCore.Identity;

namespace BlogAppWithMVC.Models
{
    public class ApplicationUser : IdentityUser
    {
       public Guid id { get; set; }
        public string UserName {  get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
