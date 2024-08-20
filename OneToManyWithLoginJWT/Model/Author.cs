namespace OneToManyWithLoginJWT.Model
{
    public class Author
    {
        /* Declaring the Fields */
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public ICollection<Book> Books { get; set; }     
    }
}
