using BloggingApplicationWithDarpan.Data;
using BloggingApplicationWithDarpan.Dtos;
using BloggingApplicationWithDarpan.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace BloggingApplicationWithDarpan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public UserController(ApplicationDbContext context) 
        {
            _context = context;
        }

        /*Checking If User and Email has whitespace */
        [HttpPost("Create")]
        public async Task<IActionResult> AddTheUser(UserDto userDto) 
        {
            /* Checking if UserName and Email has the Whitespace */
            if(string.IsNullOrWhiteSpace(userDto.UserName) || string.IsNullOrWhiteSpace(userDto.Email))
            {
                return BadRequest("UserName and Email are required");
            }

            /* Checking if Email already exist or not */
            if( await _context.Users.AnyAsync(u => u.Email == userDto.Email))
            {
                return Conflict("User with this Email already Exists");
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(userDto.Password);

            /* Creating the Object of the User */
            var user = new User 
            { 
                UserName = userDto.UserName,
                Email = userDto.Email,
                Password = hashedPassword
            };

            /* Adding the User into the Database and save the Changes */
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            /* set the Id of the newly created user */
            //userDto.Id = user.Id;

            var usershow = await _context.Users
                            .Select(u => new UserShowDto
                            {
                                Id = user.Id,
                                UserName = user.UserName,
                                Email = user.Email
                            }).FirstOrDefaultAsync();

            // Return the newly created user as the DTO
            //return CreatedAtAction(nameof(GetUser),new {id = user.Id} ,userDto);
            return Ok(usershow);
        }

        [HttpGet("GetUser/{id}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            var user = await _context.Users.Where(u => u.Id == id)
                            .Select(u => new UserShowDto
                            {
                                Id = u.Id,  
                                UserName = u.UserName,
                                Email = u.Email
                            }).FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}
