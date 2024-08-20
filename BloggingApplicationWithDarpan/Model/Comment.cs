namespace BloggingApplicationWithDarpan.Model
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public int AuthorId {  get; set; }
        public int BlogPostId { get; set; }

        //Navigation Property
        public User Author { get; set; }
        public BlogPost BlogPost { get; set; }  
    }
}
