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
    public class BlogPostController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public BlogPostController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("CreateBlogPost")]
        public async Task<ActionResult<BlogPostDto>> PostBlogPost(AddBlogPostDto addBlogPostDto)
        {
            // Validate the input
            if (string.IsNullOrWhiteSpace(addBlogPostDto.Title) || string.IsNullOrWhiteSpace(addBlogPostDto.Content))
            {
                return BadRequest("Title and content are required.");
            }

            var author = await _context.Users.FindAsync(addBlogPostDto.AuthorId);
            if (author == null)
            {
                return BadRequest("Invalid User.");
            }

            var category = addBlogPostDto.CategoryId.HasValue ?
                            await _context.Categories.FindAsync(addBlogPostDto.CategoryId.Value) :
                            null;

            var blogPost = new BlogPost
            {
                Title = addBlogPostDto.Title,
                Content = addBlogPostDto.Content,
                CreatedDate = DateTime.UtcNow, // Set the creation date to the current date and time
                AuthorId = addBlogPostDto.AuthorId,
                Category = category // Set the category if it exists
            };

            _context.BlogPosts.Add(blogPost);
            await _context.SaveChangesAsync();

            // Return the newly created blog post as DTO
            var blogPostDto = new BlogPostDto
            {
                Id = blogPost.Id,
                Title = blogPost.Title,
                Content = blogPost.Content,
                CreatedDate = blogPost.CreatedDate,
                UserName = author.UserName, // Include the author's name
                Category = category == null ? null : new CategoryDto
                {
                    Id = category.Id,
                    Name = category.Name
                },
                Comments = new List<CommentDto>() 
            };

            return CreatedAtAction(nameof(GetBlogPost), new { id = blogPost.Id }, blogPostDto);
        }

        // GET: api/BlogPosts/5
        [HttpGet("GetBlogPost/{id}")]
        public async Task<ActionResult<BlogPostDto>> GetBlogPost(int id)
        {
            var blogPost = await _context.BlogPosts
                .Include(bp => bp.Author)
                .Include(bp => bp.Category)
                .Include(bp => bp.comments)
                .Select(bp => new BlogPostDto
                {
                    Id = bp.Id,
                    Title = bp.Title,
                    Content = bp.Content,
                    CreatedDate = bp.CreatedDate,
                    UserName = bp.Author.UserName,
                    Category = bp.Category == null ? null : new CategoryDto
                    {
                        Id = bp.Category.Id,
                        Name = bp.Category.Name
                    },
                    Comments = bp.comments.Select(c => new CommentDto
                    {
                        Id = c.Id,
                        Content = c.Content,
                        CreatedDate = c.CreatedDate,
                        UserName = c.Author.UserName
                    }).ToList()
                })
                .FirstOrDefaultAsync(bp => bp.Id == id);

            if (blogPost == null)
            {
                return NotFound();
            }

            return blogPost;
        }


        /* Getting the BlogPost By its CategoryName */
        [HttpGet("GetBpByCategoryId/{categoryId}")]
        public async Task<ActionResult<IEnumerable<BlogPostDto>>> GetBlogPostsByCategoryId(int categoryId)
        {
            // Retrieve blog posts based on CategoryId
            var blogPosts = await _context.BlogPosts
                .Where(bp => bp.CategoryId == categoryId)
                .Include(bp => bp.Category)  // Include related category
                .Include(bp => bp.Author)    // Include author data
                .Include(bp => bp.comments)  // Include comments data
                    .ThenInclude(c => c.Author)  // Include comment author data
                .Select(bp => new BlogPostDto
                {
                    Id = bp.Id,
                    Title = bp.Title,
                    Content = bp.Content,
                    CreatedDate = bp.CreatedDate,
                    AuthorId = bp.AuthorId,
                    UserName = bp.Author.UserName, // Ensure that the Author is loaded
                    Category = bp.Category == null ? null : new CategoryDto
                    {
                        Id = bp.Category.Id,
                        Name = bp.Category.Name
                    },
                    Comments = bp.comments.Select(c => new CommentDto
                    {
                        Id = c.Id,
                        Content = c.Content,
                        CreatedDate = c.CreatedDate,
                   
                        UserName = c.Author != null ? c.Author.UserName : "Unknown" // Handle null author
                    }).ToList()
                })
                .ToListAsync();

            if (blogPosts == null || !blogPosts.Any())
            {
                return NotFound("No blog posts found for the specified category.");
            }

            return Ok(blogPosts);
        }
    }
}
