// See https://aka.ms/new-console-template for more information

using System;

namespace PQR
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Calculator Programme");
                Console.WriteLine("Enter the No1");
                string no1 = Console.ReadLine();
                Console.WriteLine("Enter the No2");
                string no2 = Console.ReadLine();

                Console.WriteLine("Select the Operator --> +(Addition) , -(Subtraction) , *(Multiplication) , /(Division) ");
                string c1 = Console.ReadLine();

                switch (c1)
                {
                    case "+":
                        Console.WriteLine("The Addition is -->" + (Convert.ToInt64(no1) + Convert.ToInt64(no2)));
                        break;
                    case "-":
                        Console.WriteLine("The Subtraction is -->" + (Convert.ToInt64(no1) - Convert.ToInt64(no2)));
                        break;
                    case "*":
                        Console.WriteLine("The Multiplication is -->" + (Convert.ToInt64(no1) * Convert.ToInt64(no2)));
                        break;
                    case "/":
                        Console.WriteLine("The Division is -->" + (Convert.ToInt64(no1) / Convert.ToInt64(no2)));
                        break;
                    default:
                        Console.WriteLine("You have typed the wrong Operator");
                        break;
                }
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                //return ex.ToString();
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
            }
        }
    }
}

