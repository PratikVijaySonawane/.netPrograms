using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAndAwaitMethods
{
    public class Synchronous
    {
        public void Task1()
        {
            Console.WriteLine("Task1");
            Thread.Sleep(4000);
            Console.WriteLine("Task1 completed");
        }

        public void Task2()
        {
            Console.WriteLine("Task2");
            Thread.Sleep(2000);
            Console.WriteLine("Task2 completed");
        }

        public void Task3()
        {
            Console.WriteLine("Task3");
            Thread.Sleep(3000);
            Console.WriteLine("Task completed");
        }
    }
}
