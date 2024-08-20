// See https://aka.ms/new-console-template for more information
using System;

namespace ABC
{
    class Programme
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            /* Datatypes */
            int a = 30;
            string s1 = "pratik";
            float f1 = 3.2f;
            char c1 = 'a';
            double d1 = 4.5d;
            bool isGreat = false;

            Console.WriteLine("Integer values"+a);
            Console.WriteLine("String value"+s1);
            Console.WriteLine("Float Value"+f1);
            Console.WriteLine("Char Value"+c1);
            Console.WriteLine("Double Value"+d1);
            Console.WriteLine("Boolean Value"+isGreat);
            

            /* Type casting */
            /* Implicite-type casting */
            int a1 = 10;
            float c2 = a1;
            long l1 = 12L;
            double d2 = l1;
            int a2 = 'A';
            Console.WriteLine(d2);
            Console.WriteLine(a2);
            

            /* Explicite-type Casting */
            int x = (int)3.5;
            double x1 = (double)3.5f;
            Console.WriteLine(x);
            Console.WriteLine(x1);


            /* Taking the Input from the User and type casting 
            Console.WriteLine("Hi ");
            Console.WriteLine("Enter your Name ");
            string name = Console.ReadLine();
            Console.WriteLine("Hi "+name+" How are you?");
            Console.WriteLine("How many candies do you want?");
            string can = Console.ReadLine();
            Console.WriteLine("You will get 4 more candies "+(Convert.ToInt64(can)+4));*/


            /* Operators */
            /*
             1. Arthmetic
             2. Assignment 
             3. Logical 
             4. Comparision */


            /* 1.Arithmetic */
            int v1 = 42;
            int v2 = 23;
            Console.WriteLine(" Arithemetic Operator ");
            Console.WriteLine("Addition " + (v1+v2));
            Console.WriteLine("Subtraction" + (v1-v2));
            Console.WriteLine("Multiplication" + (v1*v2));
            Console.WriteLine("Division" + (v1/v2));

            /* 2.Assignment */
            int a3 = 10;
            int b3 = a3;
            b3 += 4;
            b3 -= 4;
            b3 *= 4;
            b3 /= 4;
            Console.WriteLine("Assignment Operator "+b3);


            /* Math class in the c# */
            int a4 = Math.Max(90,12);
            double b4 = Math.Sqrt(56);
            int c4 = Math.Abs(-89);
            Console.WriteLine("maximum from two values "+a4);
            Console.WriteLine("Square root of the value "+b4);
            Console.WriteLine("Absolute value "+c4);

            /* String Mathods */
            string s2 = "Hi How are y?";
            Console.WriteLine(s2);
            Console.WriteLine("Uppercase value "+s2.ToUpper());
            Console.WriteLine("Lowercase value "+s2.ToLower());
            Console.WriteLine("Indexof method "+s2.IndexOf("How"));
            Console.WriteLine("Substring method "+s2.Substring(2));

            /* Interpolated Strings */
            String name = "pratik";
            String age = "29";
            Console.WriteLine($" The name of the candidate is {name} and the age is {age} ");

            Console.ReadLine();
        }
    }
}


