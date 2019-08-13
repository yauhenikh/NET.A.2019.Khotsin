using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Day2.Library
{
    public class Day2Tasks
    {
        #region Insert Number Task

        // 1. Даны два целых знаковых четырех байтовых числа и две позиции битов i и j(i<j).
        // Реализовать+ алгоритм InsertNumber вставки битов с j-ого по i-ый бит одного числа
        // в другое так, чтобы биты второго числа занимали позиции с бита j по бит i
        // (биты нумеруются справа налево). Разработать модульные тесты(NUnit и(!) MS Unit Test)
        // для тестирования метода.
        /// <summary>
        /// Inserts bits from <paramref name="numberIn"/> to <paramref name="numberSource"/>
        /// </summary>
        /// <param name="numberSource">Number to set bits taken from <paramref name="numberIn"/></param>
        /// <param name="numberIn">Number to take bits from</param>
        /// <param name="i">Smaller bit in the <paramref name="numberSource"/></param>
        /// <param name="j">Bigger bit in the <paramref name="numberSource"/></param>
        /// <returns>Number with bits inserted from <paramref name="numberIn"/></returns>
        public static int InsertNumber(int numberSource, int numberIn, int i, int j)
        {
            if (i > j ||
                j > 31 ||
                i < 0 ||
                j < 0)
            {
                throw new ArgumentException();
            }

            int k = 0;
            while (i <= j)
            {
                if (GetBit(numberIn, k))
                {
                    numberSource = SetBit(numberSource, i);
                }
                else
                {
                    numberSource = UnsetBit(numberSource, i);
                }

                i++;
                k++;
            }

            return numberSource;
        }

        /// <summary>
        /// Sets a bit in particular position
        /// </summary>
        /// <param name="numberSource">Number to set a bit at</param>
        /// <param name="position">Bit position</param>
        /// <returns>Number with a bit, set in particular position</returns>
        private static int SetBit(int numberSource, int position)
        {
            return numberSource | (1 << position);
        }

        /// <summary>
        /// Unsets a bit in particular position
        /// </summary>
        /// <param name="numberSource">Number to unset a bit at</param>
        /// <param name="position">Bit position</param>
        /// <returns>Number with a bit, unset in particular position</returns>
        private static int UnsetBit(int numberSource, int position)
        {
            return numberSource & ~(1 << position);
        }

        /// <summary>
        /// Get value of specific bit in number
        /// </summary>
        /// <param name="numberSource">Number to get a value of particular bit</param>
        /// <param name="position">Bit position</param>
        /// <returns>True, if bit is in particular position</returns>
        private static bool GetBit(int numberSource, int position)
        {
            return (numberSource & (1 << position)) != 0;
        }

        #endregion

        #region Find Next Bigger Number Task

        // 2. Реализовать метод FindNextBiggerNumber, который принимает положительное
        // целое число и возвращает ближайше наибольшее целое, состоящее из цифр исходного
        // числа, и - 1 (null), если такого числа не существует.Разработать модульные
        // тесты(NUnit или MS Unit Test) для тестирования метода.
        /// <summary>
        /// Gets next bigger number with same digits
        /// </summary>
        /// <param name="numberSource">Number to get next bigger number</param>
        /// <returns>Next bigger number with same digits, returns -1 if such number doesn't exist</returns>
        public static int FindNextBiggerNumber(int numberSource)
        {
            if (numberSource <= 0)
            {
                throw new ArgumentException();
            }

            int[] digitsArr = NumberToArrayOfDigits(numberSource);

            int index = digitsArr.Length - 1;
            while (index > 0)
            {
                if (digitsArr[index - 1] < digitsArr[index])
                {
                    break;
                }
                index--;
            }

            if (index == 0)
            {
                return -1;
            }
            else
            {
                int val = digitsArr[index - 1];
                int i = digitsArr.Length - 1;
                while (i >= index)
                {
                    if (digitsArr[i] > val)
                    {
                        break;
                    }
                    i--;
                }

                (digitsArr[i], digitsArr[index - 1]) = (digitsArr[index - 1], digitsArr[i]);

                ReverseSort(digitsArr, index);
            }

            return ArrayOfDigitsToNumber(digitsArr);
        }

        /// <summary>
        /// Converts <paramref name="numberSource"/> to array of its digits
        /// </summary>
        /// <param name="numberSource">Number to get array of its digits</param>
        /// <returns>Array of digits from the <paramref name="numberSource"/></returns>
        private static int[] NumberToArrayOfDigits(int numberSource)
        {
            int size = (int)Math.Log10(numberSource) + 1;
            int[] digitsArr = new int[size];

            for (int i = size - 1; i >= 0; i--)
            {
                digitsArr[i] = numberSource % 10;
                numberSource /= 10;
            }

            return digitsArr;
        }

        /// <summary>
        /// Converts array of digits to number
        /// </summary>
        /// <param name="array">Array to convert to number</param>
        /// <returns>Number obtained from <paramref name="array"/></returns>
        private static int ArrayOfDigitsToNumber(int[] array)
        {
            int number = 0;
            int multiplier = 1;

            for (int i = array.Length - 1; i >= 0; i--)
            {
                try
                {
                    number = checked(number + array[i] * multiplier);
                }
                catch (OverflowException e)
                {
                    return -1;
                }

                multiplier *= 10;
            }

            return number;
        }

        /// <summary>
        /// Sorts in reverse order part of an array from <paramref name="start"/> index to end
        /// </summary>
        /// <param name="array">Array to sort part in reverse order</param>
        /// <param name="start">Starting index to begin sorting</param>
        private static void ReverseSort(int[] array, int start)
        {
            int end = array.Length - 1;

            if (start > array.Length - 1)
            {
                return;
            }

            for (int i = start; i <= (start + end) / 2; i++)
            {
                (array[i], array[start + end - i]) = (array[start + end - i], array[i]);
            }
        }

        #endregion

        #region Find Next Bigger Number With Execution Time Task

        // 3. Добавить к методу FindNextBiggerNumber возможность вернуть время нахождения
        // заданного числа, рассмотрев различные языковые возможности.Разработать модульные
        // тесты(NUnit или MS Unit Test) для тестирования метода.
        /// <summary>
        /// Gets next bigger number with same digits, calculates execution time using DateTime class
        /// </summary>
        /// <param name="numberSource">Number to get next bigger number</param>
        /// <param name="executionTime">Execution time of FindNextBiggerNumber method</param>
        /// <returns>Next bigger number with same digits, returns -1 if such number doesn't exist</returns>
        public static int FindNextBiggerNumberWithExecutionTimeUsingDateTime(int numberSource, out double executionTime)
        {
            DateTime start = DateTime.UtcNow;

            int biggerNumber = FindNextBiggerNumber(numberSource);

            DateTime end = DateTime.UtcNow;

            TimeSpan timeDiff = end - start;
            executionTime = timeDiff.TotalMilliseconds;

            return biggerNumber;
        }

        /// <summary>
        /// Gets next bigger number with same digits, calculates execution time using Stopwatch class
        /// </summary>
        /// <param name="numberSource">Number to get next bigger number</param>
        /// <param name="executionTime">Execution time of FindNextBiggerNumber method</param>
        /// <returns>Next bigger number with same digits, returns -1 if such number doesn't exist</returns>
        public static int FindNextBiggerNumberWithExecutionTimeUsingStopwatch(int numberSource, out double executionTime)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            int biggerNumber = FindNextBiggerNumber(numberSource);

            stopwatch.Stop();

            TimeSpan timeDiff = stopwatch.Elapsed;
            executionTime = timeDiff.TotalMilliseconds;

            return biggerNumber;
        }

        #endregion

        #region Filter Digit Task

        // 4. Реализовать метод FilterDigit который принимает список целых чисел и фильтрует
        // список, таким образом, чтобы на выходе остались только числа, содержащие заданную
        // цифру.LINQ не использовать! Разработать модульные тесты(NUnit или MS Unit Test)
        // для тестирования метода.
        /// <summary>
        /// Filters list of numbers, returns only numbers containing given digit
        /// </summary>
        /// <param name="digit">Given digit</param>
        /// <param name="numberList">List of numbers</param>
        /// <returns>List of numbers containing given digit</returns>
        public static IEnumerable<int> FilterDigit(int digit, params int[] numberList)
        {
            if (digit < 0 || digit > 9)
            {
                throw new ArgumentException();
            }

            foreach (int number in numberList)
            {
                if (ContainsDigit(number, digit))
                {
                    yield return number;
                }
            }
        }

        /// <summary>
        /// Determines if <paramref name="numberSource"/> contains <paramref name="digit"/>
        /// </summary>
        /// <param name="numberSource">Number to determine the presence of a <paramref name="digit"/></param>
        /// <param name="digit">Given digit</param>
        /// <returns>True, if number contains digit</returns>
        private static bool ContainsDigit(int numberSource, int digit)
        {
            if (numberSource == int.MinValue)
            {
                return ContainsDigit(numberSource + 1, digit);
            }

            numberSource = Math.Abs(numberSource);

            while (numberSource > 0)
            {
                int digitInNumber = numberSource % 10;

                if (digitInNumber == digit)
                {
                    return true;
                }
                numberSource = numberSource / 10;
            }

            return false;
        }

        #endregion

        #region Find Nth Root Task

        // 5. Реализовать алгоритм FindNthRoot, позволяющий вычислять корень n-ой степени(n∈N )
        // из числа(a∈R ) методом Ньютона с заданной точностью.Разработать модульные тесты(NUnit
        // и (или) MS Unit Test) для тестирования метода.
        /// <summary>
        /// Find nth root using Newton's method
        /// </summary>
        /// <param name="numberSource">Given number</param>
        /// <param name="degree">Degree of the root</param>
        /// <param name="precision">Given precision</param>
        /// <returns>Root with given precision</returns>
        public static double FindNthRoot(double numberSource, int degree, double precision)
        {
            if (degree <= 0 ||
                precision < 0 ||
                precision >= 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (degree % 2 == 0 && numberSource < 0)
            {
                throw new ArgumentException();
            }

            double x0 = 5;
            double xK = int.MaxValue;

            double difference = Math.Abs(xK - x0);

            while (difference > precision)
            {
                xK = (1 / (double)degree) * (x0 * (degree - 1) + numberSource / Math.Pow(x0, degree - 1));
                difference = Math.Abs(xK - x0);
                x0 = xK;
            }

            return Math.Round(xK, (int)Math.Abs(Math.Log10(precision)));
        }

        #endregion
    }
}
