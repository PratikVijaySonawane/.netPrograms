using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneToManyWithLoginJWT.Data;

namespace OneToManyWithLoginJWT.Controllers
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

        /* Declaring the MEthod to Create The Book */
        [HttpPost]
        public Task<IActionResult> GetBooks()
        {

        }


    }
}
