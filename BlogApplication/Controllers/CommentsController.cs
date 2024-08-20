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
    public class CommentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public CommentsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;          
        }

        /* Declaring the Method to create the Comment */
        [HttpPost("createComment")]
        public async Task<IActionResult> CreateComment([FromBody] Comment comment)
        {
            var user = await _userManager.GetUserAsync(User);
            comment.AuthorId = user.Id; // Associate comment with current user
            comment.CreatedDate = DateTime.UtcNow;

            /* Adding the Comment */
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync(); 
            return Ok(comment);
        }

       
        /* Declaring the Method to Get the Comment */
        [HttpGet("GetComment{id}")]
        public async Task<IActionResult> GetComment(int id)
        {
            var comment = await _context.Comments
                          .Include(c => c.BlogPost)
                          .FirstOrDefaultAsync(b => b.Id == id);

            if (comment == null)
            { 
                return NotFound();  
            }

            return Ok(comment);
        }

        /* Declaring the Method for the GetCommentForPost */
        [HttpGet("GetCommentforpost/{postId}")]
        public async Task<IActionResult> GetCommentsForPost(int postId)
        {
            var comments = await _context.Comments
                           .Where(c => c.BlogPostId == postId)
                           .ToListAsync();

            return Ok(comments);
        }

        /* Declaring the Method for Update the Comment */
        [HttpPut("UpdateComment{id}")]
        public async Task<IActionResult> UpdateComment(int id, [FromBody] Comment updatedcomment)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null) 
            {
             return NotFound();
            }

            /**/
            comment.Content = updatedcomment.Content;

            _context.Comments.Update(comment);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        /* Declaring the Method for Delete the Comment */
        [HttpDelete("DeleteComment{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            /* Declaring the code to remove comment */
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return NoContent();
        }


    }
}
