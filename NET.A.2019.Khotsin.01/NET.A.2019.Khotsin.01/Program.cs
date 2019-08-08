using ArraySorting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NET.A._2019.Khotsin._01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //int[] array = { 1, 5, 4, 7, 3, 8, 8, 2, 1000, 2 };
            int[] array = null;
            
            PrintArray(array);
            //array.QuickSort();
            array.MergeSort();
            PrintArray(array);


            Console.ReadKey();


        }

        static void PrintArray(int[] array)
        {
            if (array == null)
            {
                return;
            }

            foreach (int element in  array)
            {
                Console.Write($"{element} ");
            }
            Console.WriteLine();
        }
    }
}
