using System.Collections.Generic;

namespace BinarySearchLibrary
{
    /// <summary>
    /// Represents class for binary search
    /// </summary>
    public static class BinarySearch
    {
        /// <summary>
        /// Searches key in the list and returns its index or null
        /// </summary>
        /// <param name="list">Given list</param>
        /// <param name="key">Search key</param>
        /// <returns>Index of element if element equals to key, null otherwise</returns>
        public static int? Search<T>(IEnumerable<T> list, T key)
        {
            int length = Count(list);

            if (length == 0)
            {
                return null;
            }

            KeyValuePair<int, T>[] array = ToArray(list, length);

            MergeSort(array);

            int min = 0;
            int max = length - 1;

            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (Comparer<T>.Default.Compare(key, array[mid].Value) == 0)
                {
                    return array[mid].Key;
                }
                else if (Comparer<T>.Default.Compare(key, array[mid].Value) < 0)
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }

            return null;
        }

        /// <summary>
        /// Calculates number of elements in IEnumerable<T> list
        /// </summary>
        /// <param name="list">Given IEnumerable<T> list</param>
        /// <returns>Number of elements</returns>
        private static int Count<T>(IEnumerable<T> list)
        {
            int count = 0;

            foreach (T element in list)
            {
                count++;
            }

            return count;
        }

        /// <summary>
        /// Converts IEnumerable<T> list to KeyValuePair<int, T> array
        /// </summary>
        /// <param name="list">Given IEnumerable<T> list</param>
        /// <param name="length">Length of array</param>
        /// <returns>KeyValuePair<int, T> array</returns>
        private static KeyValuePair<int, T>[] ToArray<T>(IEnumerable<T> list, int length)
        {
            KeyValuePair<int, T>[] array = new KeyValuePair<int, T>[length];

            int index = 0;

            foreach (T element in list)
            {
                array[index] = new KeyValuePair<int, T>(index, element);
                index++;
            }

            return array;
        }

        /// <summary>
        /// Sorts array using merge sort algorithm
        /// </summary>
        /// <param name="array">Given array</param>
        private static void MergeSort<T>(KeyValuePair<int, T>[] array)
        {
            if (array == null)
            {
                return;
            }

            if (array.Length <= 1)
            {
                return;
            }

            int mid = array.Length / 2;

            KeyValuePair<int, T>[] leftArr = new KeyValuePair<int, T>[mid];
            KeyValuePair<int, T>[] rightArr = new KeyValuePair<int, T>[array.Length - mid];

            for (int i = 0; i <= mid - 1; i++)
            {
                leftArr[i] = array[i];
            }

            for (int i = mid; i <= array.Length - 1; i++)
            {
                rightArr[i - mid] = array[i];
            }

            MergeSort(leftArr);
            MergeSort(rightArr);

            Merge(array, leftArr, rightArr);
        }

        /// <summary>
        /// Merges "left" and "right" subarrays into one sorted array
        /// </summary>
        /// <param name="array">Array that needs to be sorted</param>
        /// <param name="leftArr">"Left" subarray</param>
        /// <param name="rightArr">"Right" subarray</param>
        private static void Merge<T>(KeyValuePair<int, T>[] array, KeyValuePair<int, T>[] leftArr, KeyValuePair<int, T>[] rightArr)
        {
            int i = 0;
            int j = 0;
            int k = 0;

            while (i < leftArr.Length && j < rightArr.Length)
            {
                if (Comparer<T>.Default.Compare(leftArr[i].Value, rightArr[j].Value) <= 0)
                {
                    array[k] = leftArr[i];
                    i++;
                }
                else
                {
                    array[k] = rightArr[j];
                    j++;
                }

                k++;
            }

            while (i < leftArr.Length)
            {
                array[k] = leftArr[i];
                i++;
                k++;
            }

            while (j < rightArr.Length)
            {
                array[k] = rightArr[j];
                j++;
                k++;
            }
        }
    }
}
