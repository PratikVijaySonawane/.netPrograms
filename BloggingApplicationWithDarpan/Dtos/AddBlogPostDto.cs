namespace BloggingApplicationWithDarpan.Dtos
{
    public class AddBlogPostDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public int? CategoryId { get; set; } // Nullable if the category is optional

    }
}
