using System;
using System.Collections.Generic;

namespace JaggedArraySortRefactoring
{
    public static class JaggedArraySortSecondWay
    {
        #region Public Methods

        /// <summary>
        /// Orders rows of the jagged array by sum of their elements
        /// </summary>
        /// <param name="jaggedArray">Given jagged array</param>
        public static void SortByRowElementsSum(int[][] jaggedArray)
        {
            BubbleSort(jaggedArray, new RowElementSumComparer(), false);
        }

        /// <summary>
        /// Orders rows of the jagged array by sum of their elements in reverse order
        /// </summary>
        /// <param name="jaggedArray">Given jagged array</param>
        public static void SortByRowElementsSumReverse(int[][] jaggedArray)
        {
            BubbleSort(jaggedArray, new RowElementSumComparer(), true);
        }

        /// <summary>
        /// Orders rows of the jagged array by their maximum element
        /// </summary>
        /// <param name="jaggedArray">Given jagged array</param>
        public static void SortByRowMaximumElement(int[][] jaggedArray)
        {
            BubbleSort(jaggedArray, new RowMaxElementComparer(), false);
        }

        /// <summary>
        /// Orders rows of the jagged array by their maximum element in reverse order
        /// </summary>
        /// <param name="jaggedArray">Given jagged array</param>
        public static void SortByRowMaximumElementReverse(int[][] jaggedArray)
        {
            BubbleSort(jaggedArray, new RowMaxElementComparer(), true);
        }

        /// <summary>
        /// Orders rows of the jagged array by their minimum element
        /// </summary>
        /// <param name="jaggedArray">Given jagged array</param>
        public static void SortByRowMinimumElement(int[][] jaggedArray)
        {
            BubbleSort(jaggedArray, new RowMinElementComparer(), false);
        }

        /// <summary>
        /// Orders rows of the jagged array by their minimum element in reverse order
        /// </summary>
        /// <param name="jaggedArray">Given jagged array</param>
        public static void SortByRowMinimumElementReverse(int[][] jaggedArray)
        {
            BubbleSort(jaggedArray, new RowMinElementComparer(), true);
        }

        #endregion

        #region Helper Bubble Sort Methods

        /// <summary>
        /// Orders rows of the jagged array using comparer in ascending or descending order using comparison delegate
        /// </summary>
        /// <param name="jaggedArray">Given jagged array</param>
        /// <param name="comparisonDelegate">Given comparison method</param>
        /// <param name="isReverseOrder">Determines if order is ascending or descending</param>
        private static void BubbleSort(int[][] jaggedArray, Comparison<int[]> comparisonDelegate, bool isReverseOrder)
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
                        if (comparisonDelegate(jaggedArray[i], jaggedArray[i + 1]) < 0)
                        {
                            (jaggedArray[i], jaggedArray[i + 1]) = (jaggedArray[i + 1], jaggedArray[i]);
                            flag = true;
                        }
                    }
                    else
                    {
                        if (comparisonDelegate(jaggedArray[i], jaggedArray[i + 1]) > 0)
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
        /// Orders rows of the jagged array using comparer in ascending or descending order using comparer class
        /// </summary>
        /// <param name="jaggedArray">Given jagged array</param>
        /// <param name="comparer">Given comparer</param>
        /// <param name="isReverseOrder">Determines if order is ascending or descending</param>
        private static void BubbleSort(int[][] jaggedArray, IComparer<int[]> comparer, bool isReverseOrder)
        {
            Comparison<int[]> comparisonDelegate = comparer.Compare;
            BubbleSort(jaggedArray, comparisonDelegate, isReverseOrder);
        }

        #endregion

        #region Comparer Classes

        /// <summary>
        /// Class, comparing arrays by sum of their elements
        /// </summary>
        private class RowElementSumComparer : IComparer<int[]>
        {
            /// <summary>
            /// Compares two arrays by sum of their elements
            /// </summary>
            /// <param name="x">First array</param>
            /// <param name="y">Second array</param>
            /// <returns>An integer that indicates the relative values of the x and y parameters</returns>
            public int Compare(int[] x, int[] y)
            {
                if (this.Sum(x) > this.Sum(y))
                {
                    return 1;
                }
                else if (this.Sum(x) < this.Sum(y))
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }

            /// <summary>
            /// Calculates sum of elements in array
            /// </summary>
            /// <param name="array">Given array</param>
            /// <returns>Sum of elements in array</returns>
            private int Sum(int[] array)
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
        private class RowMaxElementComparer : IComparer<int[]>
        {
            /// <summary>
            /// Compares two arrays by the values of their maximum elements
            /// </summary>
            /// <param name="x">First array</param>
            /// <param name="y">Second array</param>
            /// <returns>An integer that indicates the relative values of the x and y parameters</returns>
            public int Compare(int[] x, int[] y)
            {
                return Nullable.Compare(this.MaxElement(x), this.MaxElement(y));
            }

            /// <summary>
            /// Gets maximum element of an array
            /// </summary>
            /// <param name="array">Given array</param>
            /// <returns>Maximum element of an array or null if array is empty</returns>
            private int? MaxElement(int[] array)
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
        private class RowMinElementComparer : IComparer<int[]>
        {
            /// <summary>
            /// Compares two arrays by the values of their minimum elements
            /// </summary>
            /// <param name="x">First array</param>
            /// <param name="y">Second array</param>
            /// <returns>An integer that indicates the relative values of the x and y parameters</returns>
            public int Compare(int[] x, int[] y)
            {
                return Nullable.Compare(this.MinElement(x), this.MinElement(y));
            }

            /// <summary>
            /// Gets minimum element of an array
            /// </summary>
            /// <param name="array">Given array</param>
            /// <returns>Minimum element of an array or null if array is empty</returns>
            private int? MinElement(int[] array)
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
