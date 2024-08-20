using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApp2.Model
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public string AuthorId { get; set; }
        public ApplicationUser Author { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public ICollection<Category> Categories { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
