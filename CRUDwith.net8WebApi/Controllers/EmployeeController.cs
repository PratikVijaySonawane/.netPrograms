using CRUDwith.net8WebApi.Data;
using CRUDwith.net8WebApi.Models;
using CRUDwith.net8WebApi.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDwith.net8WebApi.Controllers
{
    /*With this [Controller] token Url Will be Generated in this manner */
    /* loclahost : PortNo/api/controller name(Employees) */
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext dbcontext;

        /* Creating the constructor to accept the object of the (ApplicationDbContext) class */
        public EmployeeController(ApplicationDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        /* Declaring the Action Method to ge the All Employees */
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var allEmployees = dbcontext.Employees.ToList();
            return Ok(allEmployees);
        }

        /* Declaring the Action-Method to all Employees from Stored Procedure */
        [HttpGet("SP")]
        public IActionResult GetAllEmployeesBySp()
        {
            var allEmployees = dbcontext.Employees.FromSqlRaw("SelectAllEmployees").ToList();
            return Ok(allEmployees);
        }

        /* Declaring the Action-Method to Get Single Employee */
        [HttpGet("getbySP/{id?}")]
        public IActionResult GetSingleEmployeesBySp(Guid id)
        {
            var SEmployee = dbcontext.Employees.FromSql($"SelectSingleEmployee {id}").ToList();
            return Ok(SEmployee);
        }

        /* Declaring the Method for Updating the Phone Using the Id */
        [HttpGet("UpdateBySP/{id?}/{Phone}")]
        public  IActionResult UpdatePhoneBySP(Guid id,string Phone)
        {
            var EmployeeP = dbcontext.Database.ExecuteSql($"UpdateEmployeePhone {id}, {Phone}");
            return Ok(EmployeeP);
        }

        /* Declaring the Method for Adding the Employee */
        /* So step-1 add the dto class in to Model Folder to accept the dto class Object in to the AddEmployees() */
        [HttpPost]
        public IActionResult AddEmployees(AddEmployeeDto addEmployeeDto)
        {
            //Step-2
            /* Creating variable to pass the data into the database */
            var employeeEntity = new Employee()
            {
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email,
                Phone = addEmployeeDto.Phone,
                Salary = addEmployeeDto.Salary,
            };

            //Step-3
            /* Declaring the Add() Method to add the data into the data base */
            dbcontext.Employees.Add(employeeEntity);
            dbcontext.SaveChanges();

            //Step-4
            /* Returning the Response with OK() method */
            return Ok(employeeEntity);
        }

        /* Declaring the Method to get the Single Employee data by its Id */
        [HttpGet]
        [Route("{id?}")]
        public IActionResult GetSingleEmployee(Guid id)
        {
            var employee = dbcontext.Employees.Find(id);
            if(employee == null)
            {
                return NotFound();
            }
            
            return Ok(employee);
        }


        /* Declaring the Method to update the data */
        /* Here We have to make the new UpdateEmployeeDto class in the Model Folder */
        [HttpPut]
        [Route("{id?}")]
        public IActionResult UpdateEmployee(Guid id, UpdateEmployeeDto updateEmployeeDto)
        {
            var employee = dbcontext.Employees.Find(id);
            if(employee == null)
            {
                return NotFound();
            }
            employee.Name = updateEmployeeDto.Name;
            employee.Email = updateEmployeeDto.Email;
            employee.Phone = updateEmployeeDto.Phone;
            employee.Salary = updateEmployeeDto.Salary;

            dbcontext.SaveChanges();

            return Ok(employee);
        }


        /* Declaring the Methods to delete the data */
        /* */
        [HttpDelete]
        [Route("{id?}")]
        public IActionResult DeleteEmployee(Guid id) 
        {
            var employee = dbcontext.Employees.Find(id);
            if(employee == null)
            {
                return NotFound();
            }

            /*Deleting the record with the Remove method */
            dbcontext.Employees.Remove(employee);
            dbcontext.SaveChanges();

            return Ok(employee);
 
        }
    }
}
