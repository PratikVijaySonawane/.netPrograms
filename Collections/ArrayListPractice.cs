using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collections
{
    public class ArrayListPractice
    {
        public void show()
        {
            ArrayList al = new ArrayList();
            al.Add("hbhdb");
            al.Add("ABC");
            //al.Add('a');
            //al.Add(1.1f);
            //al.Add(2.32d);
            //al.Add(true);
            //al.Add(null);
            //int[] a  =  {1,2,3,4,5 };
            //string[] b = { "ABC", "PQR", "STU" };
            //al.AddRange(a);
            //al.AddRange(b);

            Console.WriteLine("The Elements in the ArrayList");
            foreach(var item in al)
            {
                Console.WriteLine(item);
            }


            // Deleting the value at specific index
            al.RemoveAt(1);

            Console.WriteLine("After Removing the Element");
            foreach (var ite in al)
            {
                Console.WriteLine(ite);
            }

            // sorting the values 
            al.Sort();
            foreach(var item in al)
            {
                Console.WriteLine(item);
            }
        }
    }
}
