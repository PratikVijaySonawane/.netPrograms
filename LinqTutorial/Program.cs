// See https://aka.ms/new-console-template for more information

using System.Threading.Tasks.Dataflow;

namespace ABC { 
    public class Program
    {
        static void Main(string[] args)
        {
            {
            //    Console.WriteLine("Hello, World!");
            //    int[] age = { 12, 23, 31, 45, 21, 25, 67, 78 };
            //    var a = from i in age where i > 20 select i;

            //    /* printing the with foreach Loop */
            //    foreach (int item in a)
            //    {
            //        Console.WriteLine(item);
            //    }

            //    /* Sorting the Array */
            //    int[] Arr = { 199, 29, 331, 45, 23, 12 };
            //    var b = from i in Arr where i >= 20 orderby i ascending select i;

            //    Console.WriteLine("Printing the Sorted Array");
            //    foreach (int item in b)
            //    {
            //        Console.WriteLine(item);
            //    }

            //    /* Contains() Function in the Linq */
            //    string[] names = { "John", "Jay", "Ram", "Shyam", "Jaggu", "Ramesh" };
            //    Console.WriteLine("Printing the Names in which the (J) Letter includes ");
            //    var c = from i in names where i.Contains("J") select i;

            //    foreach (string name in c)
            //    {
            //        Console.WriteLine(name);
            //    }

            //    /* StartsWith() Function in Linq */
            //    Console.WriteLine("Printing te Names Which starts with R ");
            //    var d = from i in names where i.StartsWith("R") select i;

            //    foreach (string name in d)
            //    {
            //        Console.WriteLine(name);
            //    }
            }
            List<Employee> employeelist = Data.GetEmployee();
            List<Department> departments = Data.GetDepartment();

            /* Declaring the Method Syntax */
            Console.WriteLine("Printing the result by the Method Syntax--->");
            var results = employeelist.Select(e => new
            {
                FullName = e.FirstName+" "+e.LastName,
                AnnualSalary = e.AnnualSalary, 
            }).Where(e => e.AnnualSalary >= 650000);

            Console.WriteLine("Printing the result--->");
            foreach (var item in results)
            {
                Console.WriteLine($"{item.FullName}-----{item.AnnualSalary}");
            }

            /* Declaring the Query Syntax */
            Console.WriteLine("Printing the result by the Query syntax--->");
            var results2 = from emp in employeelist
                           where emp.AnnualSalary >= 650000
                           select new
                           {
                               FullName = emp.FirstName+"---"+emp.LastName,
                               AnnualSalary = emp.AnnualSalary, 
                           };
            Console.WriteLine("Printing the Result --> ");
            foreach (var item  in results2)
            {
                Console.WriteLine($"{item.FullName}----{item.AnnualSalary}");
            }

            /* The IEnumarable interface---> GetHighSalariedEmployee() */
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("The Result from HighSalariedEmployee Method -->");

            var result3 = from emp in employeelist.GetHighSalariedEmployees()
                          select new
                          {
                              FullName = emp.FirstName + "---" + emp.LastName,
                              AnnualSalary = emp.AnnualSalary,
                          };
            foreach (var item in result3)
            {
                Console.WriteLine($"{item.FullName}--->{item.AnnualSalary}");
            }


            Console.WriteLine("---------------------------------------------------");
            /* (Join Operator Example - Method Syntax)*/
            var result4 = departments.Join(employeelist, department => department.Id,
                                                         employee => employee.Id,
                                       (department,employee) => new
                                       {
                                           FullName = employee.FirstName+"--"+employee.LastName,
                                           AnnualSalary = employee.AnnualSalary,
                                           departmentName = department.LongName
                                       });

            Console.WriteLine("Operation With the Inner-Join with Method Syntax ---->");
            foreach (var item in result4)
            {
                Console.WriteLine($"{item.FullName}---{item.AnnualSalary}---{item.departmentName}");
            }

            Console.WriteLine("-----------------------------------------------------");
            /* (Join Oprtor Example - Query Syntax)   */
            var result5 = from dept in departments
                         join emp in employeelist
                         on dept.Id equals emp.Id
                         select new
                         {
                             FullName = emp.FirstName + "--" + emp.LastName,
                             AnnualSalary = emp.AnnualSalary,
                             DepartmentName = dept.LongName,
                         };

            Console.WriteLine( "The Inner-Join by the Query Syntax");
            foreach(var item in result5)
            {
                Console.WriteLine($"{item.FullName}---{item.AnnualSalary}----{item.DepartmentName}");
            }

            Console.WriteLine("------------------------------------------------------");
            /* Left Outer Join between Two Tables by Method Syntax */
            Console.WriteLine("Performing the left Join between Two Tables Method Syntax -->");
            var result6 = departments.GroupJoin(employeelist,
                           dept => dept.Id,
                           emp => emp.DeptId,
                           (dept, employeesGroup) => new
                           {
                               Employees = employeesGroup,
                               Departmentname = dept.LongName
                           }); 
            foreach(var item in result6)
            {
                Console.WriteLine($"Department Name --{item.Departmentname }");
                foreach(var i in item.Employees)
                {
                    Console.WriteLine($"{i.FirstName}---{i.LastName}");
                }
            }

            Console.WriteLine("---------------------------------------------------------");
            /* Left Join between Two tables by Query Syntax Method */
            Console.WriteLine("left Join between Two Tables Query Syntax -->");
            var result7 = from Dept in departments
                          join
                               emp in employeelist on
                               Dept.Id equals emp.DeptId
                               into employeeGroup
                          select new
                          {
                              Employee = employeeGroup,
                              deptName = Dept.LongName,
                          };
            foreach(var item in result7)
            {
                Console.WriteLine($"{ item.deptName}");
                foreach(var emp in item.Employee)
                {
                    Console.WriteLine($"{emp.FirstName}--{emp.LastName}");
                }
            }
            Console.ReadLine();
        }
    }

    /* Declaring the static class EnumerableCollectionExtensionMethod */
    public static class EnumerableCollectionExtensionMethods
    {
        public static IEnumerable<Employee> GetHighSalariedEmployees(this IEnumerable<Employee> employees)
        {
            foreach(var  emp in employees)
            {
                //Console.WriteLine($"Accessing Employees: {emp.FirstName}---{emp.LastName}");
                if(emp.AnnualSalary >= 650000)
                   yield return emp;
            }
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
                DeptId = 2
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
                DeptId = 4
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

