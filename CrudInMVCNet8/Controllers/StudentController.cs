using CrudInMVCNet8.Data;
using CrudInMVCNet8.Models;
using CrudInMVCNet8.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.ComponentModel.DataAnnotations;

namespace CrudInMVCNet8.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }
        /* Get Method to add the data */
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        /* The Method for Adding the data*/
        [HttpPost]
        public async Task<ActionResult> Add(AddStudentViewModel addStudentViewModel)
        {
            /* Creating the Object of the Student */
            var student = new Student
            {
                Name = addStudentViewModel.Name,
                Email = addStudentViewModel.Email,
                Phone = addStudentViewModel.Phone,
                Subcribed = addStudentViewModel.Subcribed,
            };

            /* Adding the Object into the database */
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return View();
        }

        /* The Controller Method for Fetching the data from the Database and convert it into the List */
        [HttpGet]
        public async Task<ActionResult> List()
        {
            var student = await _context.Students.ToListAsync();
            return View(student);
        }

        /* The Method to Update the data */
        [HttpGet]
        public async Task<ActionResult> Update(Guid id)
        {
            var student = await _context.Students.FindAsync(id);
            return View(student);
        }

        /* Method to Update the Data */
        [HttpPost]
        public async Task<ActionResult> Update(Student viewModel)
        {
            var student = await _context.Students.FindAsync(viewModel.Id);
            if (student is not null)
            {
                student.Name = viewModel.Name;
                student.Email = viewModel.Email;
                student.Phone = viewModel.Phone;
                student.Subcribed = viewModel.Subcribed;
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("List", "Student");
        }

        /* Creating the Method for Delete */
        [HttpPost]
        public async Task<ActionResult> Delete(Student viewModel)
        {
            var student = await _context.Students.AsNoTracking().FirstOrDefaultAsync(u => u.Id == viewModel.Id);  
            if (student is not null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("List", "Student");
        }
    }
}
