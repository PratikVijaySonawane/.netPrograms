// See https://aka.ms/new-console-template for more information

using System.Threading.Tasks.Dataflow;

namespace ABC
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employeelist = Data.GetEmployee();
            List<Department> departments = Data.GetDepartment();

            /*Query Syntax for the sorting [orderby, orderby descending] */
            var result = from emp in employeelist
                         join dept in departments on emp.DeptId equals dept.Id
                         orderby emp.DeptId
                         select new
                         {
                             Id = emp.Id,
                             Firstname = emp.FirstName,
                             LastName = emp.LastName,
                             AnnualSalary = emp.AnnualSalary,
                             DepartmentId = emp.DeptId,
                             DepartmentName = dept.LongName
                         };

            foreach(var item in result)
            {
                Console.WriteLine(item.Firstname+" "+item.LastName+" "+item.AnnualSalary+" "+item.DepartmentName);
            }

            
            Console.ReadLine();
        }
    }

    
   


    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long AnnualSalary { get; set; }
        public bool IsManager { get; set; }
        public int DeptId { get; set; }

    }

    public class Department
    {
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string LongName { get; set; }
    }

    public class Data
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
                DeptId = 1
            };
            employees.Add(employee);

            employee = new Employee
            {
                Id = 2,
                FirstName = "Shyam",
                LastName = "Singh",
                AnnualSalary = 700000,
                IsManager = true,
                DeptId = 4
            };
            employees.Add(employee);

            employee = new Employee
            {
                Id = 3,
                FirstName = "Sundar",
                LastName = "Singh",
                AnnualSalary = 800000,
                IsManager = true,
                DeptId = 3
            };
            employees.Add(employee);

            employee = new Employee
            {
                Id = 4,
                FirstName = "Satish",
                LastName = "Singh",
                AnnualSalary = 900000,
                IsManager = true,
                DeptId = 2
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


