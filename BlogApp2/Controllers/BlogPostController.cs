using BlogApp2.Data;
using BlogApp2.DTO;
using BlogApp2.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BlogApp2.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BlogPostController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BlogPostController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<BlogPostDTO>> CreateBlogPost(CreateBlogPostDTO dto)
        {
            var authorId = User.FindFirst("sid")?.Value;
            var blogPost = new BlogPost
            {
                Title = dto.Title,
                Content = dto.Content,
                CreatedDate = DateTime.UtcNow,
                AuthorId = authorId,
                CategoryId = dto.CategoryId
            };

            _context.BlogPosts.Add(blogPost);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBlogPost), new { id = blogPost.Id }, new BlogPostDTO
            {
                Id = blogPost.Id,
                Title = blogPost.Title,
                Content = blogPost.Content,
                CreatedDate = blogPost.CreatedDate,
                AuthorName = (await _context.Users.FindAsync(blogPost.AuthorId))?.UserName,
                CategoryId = blogPost.CategoryId
            });
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<BlogPostDTO>> GetBlogPost(int id)
        {
            var blogPost = await _context.BlogPosts
                .Include(b => b.Author)
                .Include(b => b.Categories) // Ensure this includes the categories
                .FirstOrDefaultAsync(b => b.Id == id);

            if (blogPost == null)
            {
                return NotFound();
            }

            var blogPostDto = new BlogPostDTO
            {
                Id = blogPost.Id,
                Title = blogPost.Title,
                Content = blogPost.Content,
                CreatedDate = blogPost.CreatedDate,
                AuthorName = blogPost.Author?.UserName, // Safe navigation in case Author is null
                Categories = blogPost.Categories?.Select(c => new CategoryDTO
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList() ?? new List<CategoryDTO>() // Return an empty list if no categories
            };

            return Ok(blogPostDto);
        }


        //[HttpGet("{id}")]
        //public async Task<ActionResult<BlogPostDTO>> GetBlogPost(int id)
        //{
        //    var blogPost = await _context.BlogPosts
        //        .Include(b => b.Author)
        //        .Include(b => b.Categories)
        //        .FirstOrDefaultAsync(b => b.Id == id);

        //    if (blogPost == null)
        //    {
        //        return NotFound();
        //    }

        //    return new BlogPostDTO
        //    {
        //        Id = blogPost.Id,
        //        Title = blogPost.Title,
        //        Content = blogPost.Content,
        //        CreatedDate = blogPost.CreatedDate,
        //        AuthorName = blogPost.Author.UserName,
        //        CategoryId = blogPost.CategoryId,
        //        Categories = blogPost.Categories.Select(c => new CategoryDTO
        //        {
        //            Id = c.Id,
        //            Name = c.Name
        //        }).ToList()
        //    };
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateBlogPost(int id, CreateBlogPostDTO dto)
        //{
        //    var blogPost = await _context.BlogPosts.FindAsync(id);
        //    if (blogPost == null)
        //    {
        //        return NotFound();
        //    }

        //    blogPost.Title = dto.Title;
        //    blogPost.Content = dto.Content;

        //    _context.BlogPosts.Update(blogPost);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlogPost(int id)
        {
            var blogPost = await _context.BlogPosts.FindAsync(id);
            if (blogPost == null)
            {
                return NotFound();
            }

            _context.BlogPosts.Remove(blogPost);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}
