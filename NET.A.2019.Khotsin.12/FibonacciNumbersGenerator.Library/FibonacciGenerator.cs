using System;
using System.Collections.Generic;

namespace FibonacciNumbersGenerator.Library
{
    public static class FibonacciGenerator
    {
        public static IEnumerable<int> GenerateFibonacciSequence(int count)
        {
            if (count < 1)
            {
                throw new ArgumentException("The length of sequence cannot be less than 1");
            }

            for (int i = 1; i <= count && i <= 2; i++)
            {
                yield return i - 1;
            }

            int current = 1;
            int previous = 0;

            for (int i = 3; i <= count; i++)
            {
                int temp = current;

                checked
                {
                    current += previous;
                }

                previous = temp;

                yield return current;
            }
        }
    }
}
