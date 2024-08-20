using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAndAwaitMethods
{
    public class ASynchronous
    {
        public async void Task1()
        {
            await Task.Run(() => {

                Console.WriteLine("Task1");
                Thread.Sleep(10000);
                Console.WriteLine("Task1 Completed");
            });
        }

        public async void Task2()
        {
            await Task.Run(() => {

                Console.WriteLine("Task2");
                Thread.Sleep(5000);
                Console.WriteLine("Task2 Completed");
            });
        }

        public async void Task3()
        {
            await Task.Run(() => {

                Console.WriteLine("Task3");
                Thread.Sleep(10000);
                Console.WriteLine("Task3 Completed");
            });
        }
    }
}
