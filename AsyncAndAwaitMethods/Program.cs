using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAndAwaitMethods
{
    public  class Program
    {
        static void Main(string[] args)
        {
            /* Declaring the Objects for the Synchronous Threads */
            /*Synchronous s1 = new Synchronous();
            s1.Task1();
            s1.Task2();
            s1.Task3();*/

            /* Declaring the Objects for the Asynchronous Threads */
            ASynchronous s2 = new ASynchronous();
            s2.Task1();
            s2.Task2();
            s2.Task3();

            Console.ReadLine();
        }
    }
}
