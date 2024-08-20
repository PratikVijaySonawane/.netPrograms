using OneToManyWithLoginJWT.Dtos.Book;

namespace OneToManyWithLoginJWT.Dtos.Author
{
    public class AuthorDto
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }

        public IEnumerable<BookDto> Books { get; set; }
    }
}
