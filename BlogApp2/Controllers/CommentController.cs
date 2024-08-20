using BlogApp2.Data;
using BlogApp2.DTO;
using BlogApp2.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp2.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CommentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<CommentDTO>> CreateComment(CreateCommentDTO dto)
        {
            var comment = new Comment
            {
                Content = dto.Content,
                CreatedDate = DateTime.UtcNow,
                AuthorId = dto.AuthorId,
                BlogPostId = dto.BlogPostId
            };

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetComment), new { id = comment.Id }, new CommentDTO
            {
                Id = comment.Id,
                Content = comment.Content,
                CreatedDate = comment.CreatedDate,
                AuthorName = (await _context.Users.FindAsync(comment.AuthorId))?.UserName,
                BlogPostId = comment.BlogPostId
            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CommentDTO>> GetComment(int id)
        {
            var comment = await _context.Comments.Include(c => c.Author).FirstOrDefaultAsync(c => c.Id == id);

            if (comment == null)
            {
                return NotFound();
            }

            return new CommentDTO
            {
                Id = comment.Id,
                Content = comment.Content,
                CreatedDate = comment.CreatedDate,
                AuthorName = comment.Author.UserName,
                BlogPostId = comment.BlogPostId
            };
        }

        
        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateComment(int id, CreateCommentDTO dto)
        //{
        //    var comment = await _context.Comments.FindAsync(id);
        //    if (comment == null)
        //    {
        //        return NotFound();
        //    }

        //    comment.Content = dto.Content;
        //    comment.BlogPostId = dto.BlogPostId;

        //    _context.Comments.Update(comment);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}
