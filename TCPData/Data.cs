using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPData
{
    public static class Data
    {
        public static List<Employee> GetEmployee()
        {
            List<Employee> employees = new List<Employee>();
            Employee employee = new Employee
            {
                Id = 1,
                FirstName = "Ram",
                LastName = "Singh",
                AnnualSalary = 600000,
                IsManager = true,
                DepartmentId = 1
            };
            employees.Add(employee);

            employee = new Employee
            {
                Id = 2,
                FirstName = "Shyam",
                LastName = "Singh",
                AnnualSalary = 700000,
                IsManager = true,
                DepartmentId = 2
            };
            employees.Add(employee);

            employee = new Employee
            {
                Id = 3,
                FirstName = "Sundar",
                LastName = "Singh",
                AnnualSalary = 800000,
                IsManager = true,
                DepartmentId = 3
            };
            employees.Add(employee);

            employee = new Employee
            {
                Id = 4,
                FirstName = "Satish",
                LastName = "Singh",
                AnnualSalary = 900000,
                IsManager = true,
                DepartmentId = 4
            };
            employees.Add(employee);


            return employees;
        }

        public static List<Department> GetDepartment()
        {
            List<Department> departments = new List<Department>();
            Department department = new Department
            {
                Id = 1,
                ShortName = "HR",
                LongName = "Human Resources"
            };
            departments.Add(department);

            department = new Department
            {
                Id = 2,
                ShortName = "FN",
                LongName = "Finance"
            };
            departments.Add(department);    

            department = new Department
            {
                Id = 3,
                ShortName = "TE",
                LongName = "Technology"
            };
            departments.Add(department);


            return departments;
        }
    }
}
