using BloggingApplicationWithDarpan.Model;

namespace BloggingApplicationWithDarpan.Dtos
{
    public class UserShowDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        //public string Password { get; set; }
        public DateTime CreatedDate { get; set; }

        // Navigation Property 
        //public ICollection<BlogPost> BlogPosts { get; set; }
        //public ICollection<Comment> comments { get; set; }
    }
}
