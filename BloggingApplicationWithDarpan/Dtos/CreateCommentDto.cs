namespace BloggingApplicationWithDarpan.Dtos
{
    public class CreateCommentDto
    {
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public int BlogPostId { get; set; }
    }
}
