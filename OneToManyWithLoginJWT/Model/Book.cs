namespace OneToManyWithLoginJWT.Model
{
    public class Book
    {
        /* Declaring the Fields */
        public int BookId { get; set; }
        public string Title { get; set; }
        public int AuthorId {  get; set; }  
        public Author Author { get; set; }
    }
}
