namespace BloggingApplicationWithDarpan.Model
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }   
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }

        //Navigation Property
        public User Author { get; set; }
        public Category Category { get; set; }
        public ICollection<Comment> comments { get; set; }
        
    }
}
