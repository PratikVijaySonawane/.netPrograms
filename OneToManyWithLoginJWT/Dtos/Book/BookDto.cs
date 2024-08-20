namespace OneToManyWithLoginJWT.Dtos.Book
{
    public class BookDto
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
    }
}
