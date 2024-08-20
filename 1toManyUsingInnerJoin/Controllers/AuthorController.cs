using _1toManyUsingInnerJoin.Data;
using _1toManyUsingInnerJoin.DTOs.Author;
using _1toManyUsingInnerJoin.DTOs.Book;
using _1toManyUsingInnerJoin.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace _1toManyUsingInnerJoin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public AuthorController(ApplicationDbContext context)
        {
            _context = context;            
        }

        /* Adding the Method to add the Author */
        [HttpPost("CreateAuthor")]
        public async Task<ActionResult<AuthorDto>> CreateAuthor(AuthorCreateDto authorCreateDto)
        {
            /* Fetching the data from the (authorCreateDto) and  asssigning into Author class Field (AuthorName) */
            var author = new Author
            {
                AuthorName = authorCreateDto.Name
            };

            /*Adding the data into the database */
            _context.Author.Add(author);
            await _context.SaveChangesAsync();

            /* Assigning the value to AuthorDto Class Fields */
            var authorDto = new AuthorDto
            {
                AuthorId = author.AuthorId,
                AuthorName = author.AuthorName,
            };

            return CreatedAtAction(nameof(GetAuthor), new { id = author.AuthorId }, authorDto);           
        }

        /* Declaring the Method to get the Author */
        [HttpGet("GetAuthor/{id}")]
        public async Task<ActionResult<AuthorDto>> GetAuthor(int id)
        {
            var author = await _context.Author.Include(b => b.Books).FirstOrDefaultAsync(a => a.AuthorId == id);


            /* Checking if author is null or not */
            if(author == null) 
            {
                return NotFound();
            }

            /* Creating the Object of the AuthorDto class */
            var authorDto = new AuthorDto()
            {
                AuthorId = author.AuthorId,
                AuthorName = author.AuthorName,
                Books = author.Books.Select(a => new BookDto
                { Title = a.Title, }).ToList()
            };

            return Ok(authorDto);   
        }

        /* Declaring the Method to get the Authors */
        [HttpGet("Getauthors")]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAuthors()
        {
            /* This Line will Fetch the data of the Author class Author(Object of Author class) and also the object of Book class->(Books)*/
            var author = await _context.Author.Include(a => a.Books).ToListAsync();

            /* Creating the Object of the authorDto class */
            var authorDtos = author.Select( a => new AuthorDto
            {
                AuthorId = a.AuthorId,
                AuthorName = a.AuthorName
            }).ToList();
            return Ok(authorDtos);
        }
    }
}
