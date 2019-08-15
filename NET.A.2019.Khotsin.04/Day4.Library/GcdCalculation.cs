using System;
using System.Diagnostics;

namespace Day4.Library
{
    // Develop a class to calculate GCD of two, three or more integer numbers using Euclid's algorithm.
    // Add methods to calculate GCD using Stein's algorithm (binary GCD algorithm).
    // Methods should also calculate the time of finding GCD.
    public static class GcdCalculation
    {
        #region Euclid's Algorithm

        /// <summary>
        /// Calculates GCD of numbers using Euclid's algorithm
        /// </summary>
        /// <param name="executionTime">Time to perform calculations of GCD</param>
        /// <param name="numbers">List of numbers</param>
        /// <returns>GCD of numbers</returns>
        public static int GcdEuclidsAlgorithm(out double executionTime, params int[] numbers)
        {
            if (numbers == null || numbers.Length < 2)
            {
                throw new ArgumentException();
            }

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            int gcd = 0;
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                gcd = EuclidsAlgorithmForTwoNumbers(numbers[i], numbers[i + 1]);
                numbers[i + 1] = gcd;
            }

            stopwatch.Stop();

            TimeSpan timeDiff = stopwatch.Elapsed;
            executionTime = timeDiff.TotalMilliseconds;

            return gcd;
        }

        /// <summary>
        /// Calculates GCD of two numbers using Euclid's algorithm
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>GCD of two numbers</returns>
        private static int EuclidsAlgorithmForTwoNumbers(int a, int b)
        {
            if (a == int.MinValue || b == int.MinValue)
            {
                throw new ArgumentOutOfRangeException();
            }

            a = Math.Abs(a);
            b = Math.Abs(b);

            if (a == 0)
            {
                return b;
            }

            if (b == 0)
            {
                return a;
            }

            while (a != b)
            {
                if (a > b)
                {
                    a = a - b;
                }
                else
                {
                    b = b - a;
                }
            }

            return a;
        }

        #endregion

        #region Stein's Algorithm

        /// <summary>
        /// Calculates GCD of numbers using Stein's algorithm
        /// </summary>
        /// <param name="executionTime">Time to perform calculations of GCD</param>
        /// <param name="numbers">List of numbers</param>
        /// <returns>GCD of numbers</returns>
        public static int GcdSteinsAlgorithm(out double executionTime, params int[] numbers)
        {
            if (numbers == null || numbers.Length < 2)
            {
                throw new ArgumentException();
            }

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            int gcd = 0;
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                gcd = SteinsAlgorithmForTwoNumbers(numbers[i], numbers[i + 1]);
                numbers[i + 1] = gcd;
            }

            stopwatch.Stop();

            TimeSpan timeDiff = stopwatch.Elapsed;
            executionTime = timeDiff.TotalMilliseconds;

            return gcd;
        }

        /// <summary>
        /// Calculates GCD of two numbers using Stein's algorithm
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>GCD of two numbers</returns>
        private static int SteinsAlgorithmForTwoNumbers(int a, int b)
        {
            if (a == int.MinValue || b == int.MinValue)
            {
                throw new ArgumentOutOfRangeException();
            }

            a = Math.Abs(a);
            b = Math.Abs(b);

            if (a == 0)
            {
                return b;
            }

            if (b == 0)
            {
                return a;
            }

            int shift = 0;

            while (((a | b) & 1) == 0)
            {
                shift++;
                a = a >> 1;
                b = b >> 1;
            }

            while ((a & 1) == 0)
            {
                a = a >> 1;
            }

            do
            {
                while ((b & 1) == 0)
                {
                    b = b >> 1;
                }

                if (a > b)
                {
                    (a, b) = (b, a);
                }

                b = b - a;
            } while (b != 0);

            return a << shift;
        }

        #endregion
    }
}
