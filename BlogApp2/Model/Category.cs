using System.ComponentModel.DataAnnotations;

namespace BlogApp2.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BlogPost> BlogPosts { get; set; } = new List<BlogPost>();
    }
}
