using BlogApplication.Data;
using BlogApplication.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApplication.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public BlogPostsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;           
        }

        /* Declaring the Methods for creating the Post */
        [HttpPost("CreatePost")]
        public async Task<IActionResult> CreatePost([FromBody] BlogPost post)
        {
            var user = await _userManager.GetUserAsync(User);
            post.AuthorId = user.Id;
            post.CreatedDate = DateTime.UtcNow;

            /*Code for adding the post */
            _context.BlogPosts.Add(post);
            await _context.SaveChangesAsync();
            return Ok(post);
        }

        /* Declaring the Method to Get the Post */
        [HttpGet("GetPost{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _context.BlogPosts
                .Include(p => p.Comments) //Includes the related comments
                .Include(p => p.Categories) //Includes the related categories
                .FirstOrDefaultAsync(p => p.Id == id);
            
            if(post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        /* Declaring the Method to Get The Posts */
        [HttpGet("GetPosts")]
        public async Task<IActionResult> GetPosts()
        {
            var user = await _userManager.GetUserAsync(User);
            var posts = await _context.BlogPosts
                .Where(p => p.AuthorId == user.Id)
                .Include(p => p.Comments)
                .Include(p => p.Categories).ToListAsync();

            return Ok(posts);   
        }

        /* Declaring the Method to Update the Post */
        [HttpPut("UpdatePost{id}")]
        public async Task<IActionResult> UpdatePost(int id, [FromBody] BlogPost updatedPost)
        {
            var post = await _context.BlogPosts.FindAsync(id);
            if(post == null)
            {
                return NotFound();
            }

            post.Title = updatedPost.Title;
            post.Content = updatedPost.Content;
            post.Categories = updatedPost.Categories;

            _context.BlogPosts.Update(post);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        /* Declaring the Method to delete the Post */
        [HttpDelete("DeletePost{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var post = await _context.BlogPosts.FindAsync(id);
            if(post == null)
            {
                return NotFound();
            }
            
            /* Declaring the code to delete*/
             _context.BlogPosts.Remove(post);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
