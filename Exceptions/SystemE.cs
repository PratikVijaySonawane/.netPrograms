using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class SystemE
    {
        public SystemE()
        {
            try
            {
                
                Console.WriteLine("Enter the Input1");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the Input2");
                int b = Convert.ToInt32(Console.ReadLine());    
                Console.WriteLine("The Division is "+(a/b));

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
