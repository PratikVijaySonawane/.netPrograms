using _1toManyUsingInnerJoin.DTOs.Author;

namespace _1toManyUsingInnerJoin.DTOs.Book
{
    public class BookDto
    {
        public int BookId { get; set; }
        public string Title{ get; set; }
        public int AuthorId { get; set; }
        public AuthorDto Author { get; set; }  

    }
}
