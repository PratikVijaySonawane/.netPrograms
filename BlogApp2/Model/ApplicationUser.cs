using Microsoft.AspNetCore.Identity;

namespace BlogApp2.Model
{
    public class ApplicationUser : IdentityUser
    {
        public List<BlogPost> BlogPosts { get; set; } = new List<BlogPost>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
