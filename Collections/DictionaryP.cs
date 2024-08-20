using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class DictionaryP
    {
        public DictionaryP() 
        {
            /* Declaring the Dictionary */
            Dictionary<int , string> d1 = new Dictionary<int , string>();
            d1.Add(1, "Ram");
            d1.Add(2, "Shyam");
            d1.Add(3, "Sundar");
            d1.Add(4, "Ravi");
            d1.Add(5, "Satu");

            Console.WriteLine("The Dictionary value");
            foreach (KeyValuePair<int , string> kvp in d1)
            {
                Console.WriteLine($"key{kvp.Key} and value{kvp.Value}");
            }

        }
    }
}
