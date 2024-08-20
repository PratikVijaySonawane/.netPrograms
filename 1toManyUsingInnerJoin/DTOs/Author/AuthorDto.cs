using _1toManyUsingInnerJoin.DTOs.Book;

namespace _1toManyUsingInnerJoin.DTOs.Author
{
    public class AuthorDto
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }

        public List<BookDto> Books { get; set; }
    }
}
