namespace BlogApp2.DTO
{
    public class CreateCommentDTO
    {
        public string Content { get; set; }
        public int BlogPostId { get; set; }
        public string AuthorId { get; set; }
    }
}
