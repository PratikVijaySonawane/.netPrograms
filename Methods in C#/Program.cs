// See https://aka.ms/new-console-template for more information

using System;

namespace ABC
{
    class Program
    {
        /* Declaring the static Method in the class */
        static int addition(int a, int b)
        {
            return a + b;
        }
        static float average(float a, float b, float c)
        {
            return (a + b + c) / 3;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine("The addition is "+addition(1, 2));
            Console.WriteLine("The average is "+average(1, 3, 5));
            Console.ReadLine();
        }
    }
}

