using System;
using System.Collections.Generic;

namespace JaggedArraySortRefactoring
{
    public static class JaggedArraySortFirstWay
    {
        #region Public Methods

        /// <summary>
        /// Orders rows of the jagged array by sum of their elements
        /// </summary>
        /// <param name="jaggedArray">Given jagged array</param>
        public static void SortByRowElementsSum(int[][] jaggedArray)
        {
            BubbleSort(jaggedArray, CompareRowsBySum, false);
        }

        /// <summary>
        /// Orders rows of the jagged array by sum of their elements in reverse order
        /// </summary>
        /// <param name="jaggedArray">Given jagged array</param>
        public static void SortByRowElementsSumReverse(int[][] jaggedArray)
        {
            BubbleSort(jaggedArray, CompareRowsBySum, true);
        }

        /// <summary>
        /// Orders rows of the jagged array by their maximum element
        /// </summary>
        /// <param name="jaggedArray">Given jagged array</param>
        public static void SortByRowMaximumElement(int[][] jaggedArray)
        {
            BubbleSort(jaggedArray, CompareRowsByMaxElement, false);
        }

        /// <summary>
        /// Orders rows of the jagged array by their maximum element in reverse order
        /// </summary>
        /// <param name="jaggedArray">Given jagged array</param>
        public static void SortByRowMaximumElementReverse(int[][] jaggedArray)
        {
            BubbleSort(jaggedArray, CompareRowsByMaxElement, true);
        }

        /// <summary>
        /// Orders rows of the jagged array by their minimum element
        /// </summary>
        /// <param name="jaggedArray">Given jagged array</param>
        public static void SortByRowMinimumElement(int[][] jaggedArray)
        {
            BubbleSort(jaggedArray, CompareRowsByMinElement, false);
        }

        /// <summary>
        /// Orders rows of the jagged array by their minimum element in reverse order
        /// </summary>
        /// <param name="jaggedArray">Given jagged array</param>
        public static void SortByRowMinimumElementReverse(int[][] jaggedArray)
        {
            BubbleSort(jaggedArray, CompareRowsByMinElement, true);
        }

        #endregion

        #region Helper Bubble Sort Methods

        /// <summary>
        /// Orders rows of the jagged array using comparer in ascending or descending order using comparer class
        /// </summary>
        /// <param name="jaggedArray">Given jagged array</param>
        /// <param name="comparer">Given comparer</param>
        /// <param name="isReverseOrder">Determines if order is ascending or descending</param>
        private static void BubbleSort(int[][] jaggedArray, IComparer<int[]> comparer, bool isReverseOrder)
        {
            if (jaggedArray == null)
            {
                throw new ArgumentNullException();
            }

            if (jaggedArray.Length == 0)
            {
                return;
            }

            for (int k = 0; k < jaggedArray.Length - 1; k++)
            {
                bool flag = false;

                for (int i = 0; i < jaggedArray.Length - k - 1; i++)
                {
                    if (isReverseOrder)
                    {
                        if (comparer.Compare(jaggedArray[i], jaggedArray[i + 1]) < 0)
                        {
                            (jaggedArray[i], jaggedArray[i + 1]) = (jaggedArray[i + 1], jaggedArray[i]);
                            flag = true;
                        }
                    }
                    else
                    {
                        if (comparer.Compare(jaggedArray[i], jaggedArray[i + 1]) > 0)
                        {
                            (jaggedArray[i], jaggedArray[i + 1]) = (jaggedArray[i + 1], jaggedArray[i]);
                            flag = true;
                        }
                    }
                }

                if (flag == false)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Orders rows of the jagged array using comparer in ascending or descending order using comparison delegate
        /// </summary>
        /// <param name="jaggedArray">Given jagged array</param>
        /// <param name="compareDelegate">Given comparison method</param>
        /// <param name="isReverseOrder">Determines if order is ascending or descending</param>
        private static void BubbleSort(int[][] jaggedArray, Comparison<int[]> compareDelegate, bool isReverseOrder)
        {
            Comparer<int[]> comparer = Comparer<int[]>.Create(compareDelegate);
            BubbleSort(jaggedArray, comparer, isReverseOrder);
        }

        #endregion

        #region Comparison Methods

        /// <summary>
        /// Compares two arrays by sum of their elements
        /// </summary>
        /// <param name="x">First array</param>
        /// <param name="y">Second array</param>
        /// <returns>An integer that indicates the relative values of the x and y parameters</returns>
        private static int CompareRowsBySum(int[] x, int[] y)
        {
            if (Sum(x) > Sum(y))
            {
                return 1;
            }
            else if (Sum(x) < Sum(y))
            {
                return -1;
            }
            else
            {
                return 0;
            }

            int Sum(int[] array)
            {
                int result = 0;

                foreach (int element in array)
                {
                    result = checked(result + element);
                }

                return result;
            }
        }

        /// <summary>
        /// Compares two arrays by the values of their maximum elements
        /// </summary>
        /// <param name="x">First array</param>
        /// <param name="y">Second array</param>
        /// <returns>An integer that indicates the relative values of the x and y parameters</returns>
        private static int CompareRowsByMaxElement(int[] x, int[] y)
        {
            return Nullable.Compare(MaxElement(x), MaxElement(y));

            int? MaxElement(int[] array)
            {
                if (array.Length == 0)
                {
                    return null;
                }

                int max = array[0];

                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i] > max)
                    {
                        max = array[i];
                    }
                }

                return max;
            }
        }

        /// <summary>
        /// Compares two arrays by the values of their minimum elements
        /// </summary>
        /// <param name="x">First array</param>
        /// <param name="y">Second array</param>
        /// <returns>An integer that indicates the relative values of the x and y parameters</returns>
        private static int CompareRowsByMinElement(int[] x, int[] y)
        {
            return Nullable.Compare(MinElement(x), MinElement(y));

            int? MinElement(int[] array)
            {
                if (array.Length == 0)
                {
                    return null;
                }

                int min = array[0];

                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i] < min)
                    {
                        min = array[i];
                    }
                }

                return min;
            }
        }

        #endregion
    }
}
