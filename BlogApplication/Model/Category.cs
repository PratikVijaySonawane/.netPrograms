using System.ComponentModel.DataAnnotations;

namespace BlogApplication.Model
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<BlogPost> BlogPosts { get; set;}
    }
}
