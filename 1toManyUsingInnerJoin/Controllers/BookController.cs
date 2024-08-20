using _1toManyUsingInnerJoin.Data;
using _1toManyUsingInnerJoin.DTOs.Book;
using _1toManyUsingInnerJoin.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _1toManyUsingInnerJoin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public BookController(ApplicationDbContext context) 
        { 
            _context = context;
        }

        /* DEclaring the Method of the create Book */
        [HttpPost("CreateBook")]
        public async Task<ActionResult<BookDto>> CreateBook(BookCreateDto bookCreateDto)
        {
            /* Declaring the Object for the Book */
            var book = new Book
            {
                Title = bookCreateDto.Title,
                AuthorId = bookCreateDto.AuthorId,
            };

            /* Adding the data into the database */
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            /* Creating the Object of the BookDto Class */
            var bookDto = new BookDto
            {
                BookId = book.BookId,
                Title = book.Title,
                AuthorId = book.AuthorId,
            };

            /* returning the result */
            return CreatedAtAction(nameof(GetBook), new { id = book.BookId }, bookDto);

        }

        /* Declaring the Method to get the Book */
        [HttpGet("GetBook/{id}")]
        public async Task<ActionResult<BookDto>> GetBook(int id)
        {
            /* Declaring the Method to Fetch the data */
            var book = await _context.Books.Include( a => a.Author).FirstOrDefaultAsync(b => b.BookId == id);

            /* Checking if Book is null or not */
            if(book == null)
            {
                return NotFound();
            }

            /* Creating the Object of the Dto class */
            var bookDto = new BookDto
            {
                BookId = book.BookId,
                Title = book.Title,
           
                Author = new DTOs.Author.AuthorDto
                {
                    AuthorId = book.Author.AuthorId,
                    AuthorName = book.Author.AuthorName
                }
            };

            /* Returning the Dto Result */
            return Ok(bookDto);
        }

        /* Declaring the Method to Get The Books */
        [HttpGet("GetBooks")]
        public async Task<ActionResult<BookDto>> GetBooks()
        {
            var books = await _context.Books.Include(b => b.Author).ToListAsync();  

            /* Creating the Object of the BookDto class */
            var bookDto = books.Select( a => new BookDto
                                            {
                                                BookId = a.BookId,
                                                Title = a.Title,                                                                                     
                                                Author = new DTOs.Author.AuthorDto
                                                {
                                                    AuthorId = a.Author.AuthorId,
                                                    AuthorName = a.Author.AuthorName
                                                }
                                            }).ToList();
            /* Returning the Response */
            return Ok(bookDto);
        }

    }
}
