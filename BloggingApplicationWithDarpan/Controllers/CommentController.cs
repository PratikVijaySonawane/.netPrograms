using BloggingApplicationWithDarpan.Data;
using BloggingApplicationWithDarpan.Dtos;
using BloggingApplicationWithDarpan.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BloggingApplicationWithDarpan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CommentController(ApplicationDbContext context)
        {
            _context = context;        
        }

    
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<CommentDto>>> GetComments()
        {
            return await _context.Comments
                .Include(c => c.Author)
                .Include(c => c.BlogPost)
                .Select(c => new CommentDto
                {
                    Id = c.Id,
                    Content = c.Content,
                    CreatedDate = c.CreatedDate,
                    UserName = c.Author.UserName,
                    //Title = c.BlogPost.Title
                })
                .ToListAsync();
        }

       

     
        [HttpPost("CreateComment")]
        public async Task<ActionResult<CommentDto>> PostComment(CreateCommentDto createCommentDto)
        {
            if (string.IsNullOrWhiteSpace(createCommentDto.Content))
            {
                return BadRequest("Content is required.");
            }

            var author = await _context.Users.FindAsync(createCommentDto.AuthorId);
            if (author == null)
            {
                return BadRequest("Invalid author.");
            }

            var blogPost = await _context.BlogPosts.FindAsync(createCommentDto.BlogPostId);
            if (blogPost == null)
            {
                return BadRequest("Invalid blog post.");
            }

            var comment = new Comment
            {
                Content = createCommentDto.Content,
                CreatedDate = DateTime.UtcNow,
                AuthorId = createCommentDto.AuthorId,
                BlogPostId = createCommentDto.BlogPostId
            };

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            // Return the newly created comment as DTO
            var commentDto = new CommentDto
            {
                Id = comment.Id,
                Content = comment.Content,
                CreatedDate = comment.CreatedDate,
                UserName = author.UserName,
                //Title = blogPost.Title
            };

            return Ok(commentDto);
        }


    }
}
