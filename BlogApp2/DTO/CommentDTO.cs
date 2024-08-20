namespace BlogApp2.DTO
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public string AuthorName { get; set; }
        public int BlogPostId { get; set; }
    }
}
