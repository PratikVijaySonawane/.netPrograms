// See https://aka.ms/new-console-template for more information



using TCPData;
using TCPExtension;

namespace ThePretendCompanyApplication
{
    public class Program
    {
        static void Main(string[] args)
        {
            /* Declaring the List to get employees */
            //List<Employee> employeelist = Data.GetEmployee();
            //var filteredEmployees = employeelist.Filter(emp => emp.IsManager == true);

            //foreach(var employee in filteredEmployees)
            //{
            //    Console.WriteLine($"First Name-->{employee.FirstName}");
            //    Console.WriteLine($"Last Name-->{employee.LastName}");
            //    Console.WriteLine($"Annual salary-->{employee.AnnualSalary}");
            //    Console.WriteLine($"Manager-->{employee.IsManager}");
            //    Console.WriteLine("---------------------");
            //}

            ///* Declaring the List to get the Department */
            //List<Department> departmentlist = Data.GetDepartment();
            //var filteredDepartment = departmentlist.Filter(dept => dept.ShortName == "HR" || dept.ShortName == "FN");

            ///* We can use the Where Operator in the Lambda Function 
            //var filteredDepartment1 = departmentlist.Where(dept => dept.ShortName == "HR" || dept.ShortName == "FN");*/

            //foreach( var department in filteredDepartment)
            //{
                
            //    Console.WriteLine($"Department Shortname-->{department.ShortName}");
            //    Console.WriteLine($"Departmet Longname-->{department.LongName}");
            //    Console.WriteLine($"Department Id-->{department.Id}");
            //}

            /* Performing the Innerjoin with Linq */
            List <Employee> employeelist = Data.GetEmployee ();
            List<Department> departmentlist = Data.GetDepartment ();

            var resultlist = from emp in employeelist
                                join
                                  dept in departmentlist
                                  on emp.Id equals dept.Id
                             select new
                             {
                                 FName = emp.FirstName,
                                 LName = emp.LastName,
                                 AnnualSalary = emp.AnnualSalary,
                                 Manager = emp.IsManager,
                                 DeptShortName = dept.ShortName,
                                 DeptLongName = dept.LongName
                             };
            //select * from employeelist e JOIN departmentlist d on e.Id = d.Id;
            Console.WriteLine("The data wit Inner-join");
            foreach(var result in resultlist)
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine($"First-Name -->{result.FName}");
                Console.WriteLine($"Last-Name-->{result.LName}");
                Console.WriteLine($"AnnualSalry-->{result.AnnualSalary}");
                Console.WriteLine($"Is manager--> {result.Manager}");
                Console.WriteLine($"Department ShortName-->{result.DeptShortName}");
                Console.WriteLine($"Department Longname--->{result.DeptLongName}");
            }

            /* Average, Max, Min Function in the Linq */

                Console.WriteLine("----------------------------------");

            var averageAnnualSalary = resultlist.Average(a => a.AnnualSalary);
            var highestAnnualsalary = resultlist.Max(a => a.AnnualSalary);
            var lowestAnnualSalary = resultlist.Min(a => a.AnnualSalary) ;

            Console.WriteLine($"Average salary --->{averageAnnualSalary}");
            Console.WriteLine($"Highest salary  --->{highestAnnualsalary}");
            Console.WriteLine($"Lowest salary --->{lowestAnnualSalary}");

            Console.ReadLine();
        }
    }
}

