using Microsoft.AspNetCore.Identity;

namespace BlogApplication.Model
{
    public class ApplicationUser : IdentityUser
    {
        /* Declaring the Fields */
        public ICollection<BlogPost> BlogPosts { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
