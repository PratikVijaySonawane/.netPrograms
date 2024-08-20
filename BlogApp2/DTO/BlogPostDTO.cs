using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApp2.DTO
{
    public class BlogPostDTO
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public string AuthorName { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public List<CategoryDTO> Categories { get; set; } = new List<CategoryDTO>();
    }
}
