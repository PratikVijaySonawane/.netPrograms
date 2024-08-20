using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class ArrayExcep
    {
        public ArrayExcep() 
        {
            try
            {
                int[] a = { 1, 2, 3, 4, 5};
                Console.WriteLine(a[6]);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally 
            { 
                Console.WriteLine(" finally block after try catch block "); 
            }
        }
    }
}
