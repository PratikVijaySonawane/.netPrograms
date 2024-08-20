using CRUDWithStoredProcedure.Data;
using CRUDWithStoredProcedure.Model;
using CRUDWithStoredProcedure.Model.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CRUDWithStoredProcedure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public EmployeeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /* Declaring the Method to get all Employee data */
        [HttpGet("GetEmp")]
        public IActionResult GetAllEmployee()
        {
            var result = dbContext.Employees.ToList();
            return Ok(result);
        }

        /* Declaring the Methods to add the data in the Employees table */
        [HttpPost("AddEmp")]
        public IActionResult AddEmployee(AddEmployee addEmployee)
        {
            var employeeEntity = new Employee()
            {
                Name = addEmployee.Name,
                Age = addEmployee.Age,
                Active = addEmployee.Active,    
            };

            dbContext.Employees.Add(employeeEntity); 
            dbContext.SaveChanges();

            return Ok(employeeEntity);
        }

        /* Declaring the Method to Update the data */
        [HttpPut("UpdateEmp/{id?}")]
        public IActionResult UpdateEmployee(int id,UpdateEmployee updateEmployee) 
        {
            var result = dbContext.Employees.Find(id);
            if(result==null)
            {
                return NotFound();
            }
            result.Name = updateEmployee.Name;
            result.Age = updateEmployee.Age;
            result.Active = updateEmployee.Active;

            dbContext.SaveChanges();

            return Ok(result);
        }

        /* Declaring the Method to get the Employees by StoredProcedure */
        [HttpGet("GetBySp")]
        public IActionResult GetEmployeesBySP() 
        {
            var allemps = dbContext.Employees.FromSqlRaw("SelectAllEmployeesByMaster").ToList();
            return Ok(allemps);
           
        }

        /* Declaring the Method to ge the Single Employee */
        [HttpGet("GetSingleBySP/{id?}")]
        public IActionResult GetSingleEmployeeBySP(int id) 
        {
            var SEmployee = dbContext.Employees.FromSql($"SelectSingleEmployeeByMaster {id}").ToList();
            return Ok(SEmployee);
        }

        /* Declaring the Method to Insert the data */
        [HttpPost("AddBySp")]
        public  IActionResult AddEmployeeBySP(string Name,int Age,int Active)
        {
            var AddEmp =  dbContext.Database.ExecuteSql($"EXECUTE InsertEmployeeByMaster {Name}, {Age}, {Active}");

            /* This is also the Method */
            //var parameters = new[]
            //{
            //new SqlParameter("@Name", Name),
            //new SqlParameter("@Age", Age),
            //new SqlParameter("@Active", Active)
            //};

            //// Execute the stored procedure
            //var result = await dbContext.Database.ExecuteSqlRawAsync("EXEC InsertEmployeeByMaster @Name, @Age, @Active", parameters);
            return Ok(AddEmp);
        }

        /* Declaring the SP Method to Update the Data */
        [HttpGet("UpdateBySp/{id?}")]
        public IActionResult UpdateEmployeeBySP(int id,string Name, int Age, int Active)
        {
            var UpdateEmp = dbContext.Database.ExecuteSql($" UpdateEmployeeByMaster {id},{Name},{Age},{Active}");
            return Ok(UpdateEmp);
        }

        /* Declaring the SP Method to Delete the Data */
        [HttpGet()]
        public IActionResult DeleteEmployeeBySP(int id)
        {
            var DeleteEmp = dbContext.Database.ExecuteSql($"DeleteEmployeeByMaster {id}");
            return Ok(DeleteEmp);

        }

    }
}
