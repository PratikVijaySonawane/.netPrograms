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
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context) 
        { 
            _context = context;
        }

        /* Creating the Method to Create the category */
        [HttpPost("CreateCategory")]
        public async Task<ActionResult<CategoryDto>> CreateCategory(CreateCategoryDto createCategoryDto) 
        {
            if(string.IsNullOrWhiteSpace(createCategoryDto.Name))
            {
                return BadRequest("Category Name is Required");
            }

            //Create the New Category
            var Category = new Category
            {
                Name = createCategoryDto.Name
            };

            _context.Categories.Add(Category);
            await _context.SaveChangesAsync();

            /*Creating the Dto for Category */
            var CategoryDto = new CategoryDto 
            { 
                Id = Category.Id,
                Name = createCategoryDto.Name 
            };
            return Ok(CategoryDto);
        }

        [HttpGet("GetAllCate")]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll()
        {
            var r = await _context.Categories.Select(c => new CategoryDto
            {
                Id=c.Id,
                Name = c.Name
            }).ToListAsync();

            return Ok(r);             
        }



    }
}
