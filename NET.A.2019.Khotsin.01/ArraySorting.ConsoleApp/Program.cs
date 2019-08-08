using System;

namespace ArraySorting.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Array Sorting Testing Application");

            Console.WriteLine("\nCreate array of integers { -10, 9, 8, 10, 2 }");
            int[] array1 = new int[] { -10, 9, 8, 10, 2 };
            PrintArray(array1);

            Console.WriteLine("Sort array using QuickSort method");
            array1.QuickSort();
            PrintArray(array1);

            Console.WriteLine("\nCreate array of integers { 100, 20, -10000, 5, 20 }");
            int[] array2 = new int[] { 100, 20, -10000, 5, 20 };
            PrintArray(array2);

            Console.WriteLine("Sort array using MergeSort method");
            array2.MergeSort();
            PrintArray(array2);

            Console.WriteLine("\nCreate array of integers { 1000, 1000, 1000, 1, 1 }");
            int[] array3 = new int[] { 1000, 1000, 1000, 1, 1 };
            PrintArray(array3);

            Console.WriteLine("Sort array using QuickSort method");
            array3.QuickSort();
            PrintArray(array3);

            Console.WriteLine("\nCreate array of integers { 1, -1, 1, -1, 1, -1, 1 }");
            int[] array4 = new int[] { 1, -1, 1, -1, 1, -1, 1 };
            PrintArray(array4);

            Console.WriteLine("Sort array using MergeSort method");
            array4.MergeSort();
            PrintArray(array4);

            Console.ReadKey();
        }

        static void PrintArray(int[] array)
        {
            if (array == null)
            {
                return;
            }

            foreach (int element in array)
            {
                Console.Write($"{element} ");
            }
            Console.WriteLine();
        }
    }
}
