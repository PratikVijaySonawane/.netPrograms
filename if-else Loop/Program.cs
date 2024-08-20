// See https://aka.ms/new-console-template for more information

using System;

namespace ABC
{
    class Programme
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the name");
            String name = Console.ReadLine();
            Console.WriteLine($"Hi {name} How are u? Please enter the Age");
            String age = Console.ReadLine();
            

            if(Convert.ToInt64(age) < 18 )
            {
                Console.WriteLine("You are not allowed to get the License, Because you are Underage or may be you are banned");
            }
            else if(Convert.ToInt64(age) > 65 )
            {
                Console.WriteLine("You are older to get the License or may be you are banned");
            }
            else
            {
                if(isBanned)
                {
                    Console.WriteLine("Sorry you are banned form License Department ");
                }
                else
                {
                    Console.WriteLine("You will get your License Soon");
                } 
            }

            Console.ReadLine();
 
        }
        
    }
}

