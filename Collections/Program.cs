// See https://aka.ms/new-console-template for more information

using System.Collections;
using System;
using Collections;

namespace collections
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hello World");

            ArrayListPractice a1 = new ArrayListPractice();
            a1.show();

            hashtableP h1 = new hashtableP();
            h1.Show();

            ListP ll1 = new ListP();

            DictionaryP dd1 = new DictionaryP();
            Console.ReadLine();
        }
    }
}
