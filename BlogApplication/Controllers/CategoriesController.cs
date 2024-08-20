using BlogApplication.Data;
using BlogApplication.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApplication.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        /* Declaring the Method to Create the category */
        [HttpPost("CreateCate")]
        public async Task<IActionResult> CreateCategory([FromBody] Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return Ok(category);
        }


        /* Declaring the Method to Get the Category */
        [HttpGet("GetCate")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            return Ok(categories);
        }

        /* Declaring the Method to Update the Category */
        [HttpPut("UpdateCate{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] Category updatedCategory)
        {
            var category = await _context.Categories.FindAsync(id);
            if(category == null) 
            { 
                return NotFound();
            }

            category.Name = updatedCategory.Name;

            /* Updating the data in the category Section */
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();  
            return NoContent();
        }

        /* Declaring the Method to Delete the Category */
        [HttpDelete("DeleteCate{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            
            /* Removing the Categories */
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return NoContent();
        }


    }
}
