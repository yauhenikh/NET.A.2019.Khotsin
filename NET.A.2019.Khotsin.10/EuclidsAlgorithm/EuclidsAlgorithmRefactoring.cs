using System;
using System.Diagnostics;

namespace EuclidsAlgorithm
{
    public static class EuclidsAlgorithmRefactoring
    {
        #region Delegates

        /// <summary>
        /// Delegate, encapsulating methods of finding GCD of two numbers
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>GCD of two numbers</returns>
        private delegate int GcdOfTwoInts(int a, int b);

        #endregion

        #region Method Using Delegate

        /// <summary>
        /// Calculates GCD of numbers using appropriate delegate
        /// </summary>
        /// <param name="executionTime">Time to perform calculations of GCD</param>
        /// <param name="gcdOfTwo">Delegate, encapsulating methods of finding GCD of two numbers</param>
        /// <param name="numbers">List of numbers</param>
        /// <returns>GCD of numbers</returns>
        private static int GcdAlgorithm(out double executionTime, GcdOfTwoInts gcdOfTwo, params int[] numbers)
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
                gcd = gcdOfTwo(numbers[i], numbers[i + 1]);
                numbers[i + 1] = gcd;
            }

            stopwatch.Stop();

            TimeSpan timeDiff = stopwatch.Elapsed;
            executionTime = timeDiff.TotalMilliseconds;

            return gcd;
        }

        #endregion

        #region Euclid's Algorithm

        /// <summary>
        /// Calculates GCD of numbers using Euclid's algorithm
        /// </summary>
        /// <param name="executionTime">Time to perform calculations of GCD</param>
        /// <param name="numbers">List of numbers</param>
        /// <returns>GCD of numbers</returns>
        public static int GcdEuclidsAlgorithm(out double executionTime, params int[] numbers)
        {
            return GcdAlgorithm(out executionTime, EuclidsAlgorithmForTwoNumbers, numbers);
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
            return GcdAlgorithm(out executionTime, SteinsAlgorithmForTwoNumbers, numbers);
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
            }
            while (b != 0);

            return a << shift;
        }

        #endregion
    }
}
