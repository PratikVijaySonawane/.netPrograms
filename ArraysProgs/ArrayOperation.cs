using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysProgs
{
    public class ArrayOperation
    {
        public  void ArrayShow()
        {
            // case 1 : Taking input from the User

            // Declaring the Array
            int[] arr = new int[5];

            // Taking the input from the User
            int i,j,temp=0;
            Console.WriteLine("Enter the Input into the Array");
            for (i = 0; i < arr.Length; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }

            //Console.WriteLine("The Elements into the Array");
            //for (i = 0; i < arr.Length; i++)
            //{
            //    Console.WriteLine(arr[i]);
            //}


             //case 2: Sorting the Array
            //for (i=0;i<arr.Length-1; i++)
            //{
            //    for (j=0;j<arr.Length-1-i; j++)
            //    {
            //        if (arr[j] > arr[j+1])
            //        {
            //            temp = arr[j];
            //            arr[j] = arr[j+1];
            //            arr[j+1] = temp;
            //        }
            //    }
            //}

            //Console.WriteLine("The Sorted Elements into the Array");
            //for (i = 0; i < arr.Length; i++)
            //{
            //    Console.WriteLine(arr[i]);
            //}


            // case 3: Reversing the Array 
            //for(i=0;i<arr.Length-1;i++)
            //{
            //    for (j = 0; j < arr.Length - 1 - i; j++)
            //    {
            //            temp = arr[j];
            //            arr[j] = arr[j + 1];
            //            arr[j + 1] = temp;
            //    }

            //}

            //Console.WriteLine("The Reversed Elements into the Array");
            //for (i = 0; i < arr.Length; i++)
            //{
            //    Console.WriteLine(arr[i]);
            //}


            for (i = 0; i < arr.Length - 1; i++)
            {
                for (j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }

            int count=0;
            for (i = 0; i < arr.Length - 1; i++)
            {
                for (j = 0; j < arr.Length - 1 - i; j++)
                {
                    count = 1;
                    if (arr[j] == arr[j + 1])
                    {
                        count++;
                    }
                    else
                    {
                        Console.WriteLine(arr[j]+"--->"+count);
                    }
                }
            }

        }
    }
}
