using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collections
{
    public class hashtableP
    {
        public void Show()
        {

            Hashtable ht = new();
            ht.Add("1", "Ram");
            ht.Add(2, true);
            ht.Add('3', 4);
            ht.Add(4.4f, 5.5d);
            ht.Add(9.2d, "Shyam");
            ht.Add(6, "Sureash");

            Console.WriteLine("-----Hashtable values-----");
            foreach (DictionaryEntry entry in ht)
            {
                Console.WriteLine($"Key: {entry.Key}, Value: {entry.Value}");
            }

        }
    }
}
