using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class ListP
    {
        public ListP() 
        {
            List<object> list = new List<object> ();
            list.Add("1");
            list.Add("2");
            list.Add("3");
            list.Add(4);
            list.Add(5.5);
          
            Console.WriteLine("The List Items--->");
            foreach (object item in list) 
            {
                Console.WriteLine(item);
            }
        }
    }
}
