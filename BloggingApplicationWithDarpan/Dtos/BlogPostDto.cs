using BloggingApplicationWithDarpan.Model;

namespace BloggingApplicationWithDarpan.Dtos
{
    public class BlogPostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public int AuthorId {  get; set; }  
        public string UserName { get; set;}
        //public int? CategoryId { get; set; }
        public CategoryDto Category { get; set; }
        public List<CommentDto> Comments { get; set; }
        
    }
}
