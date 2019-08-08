namespace ArraySorting
{
    /// <summary>
    /// Extension methods of quicksort and merge sort for int[] array
    /// </summary>
    public static class ArraySort
    {
        /// <summary>
        /// Sorts array of integers using quicksort algorithm
        /// </summary>
        /// <param name="array">Given array of integers</param>
        public static void QuickSort(this int[] array)
        {
            if (array == null)
            {
                return;
            }

            QuickSort(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Sorts the segment of an array of integers
        /// </summary>
        /// <param name="array">Given array of integers</param>
        /// <param name="low">Start index of the segment that needs to be sorted</param>
        /// <param name="high">End index of the segment that needs to be sorted</param>
        private static void QuickSort(int[] array, int low, int high)
        {
            if (low  < high)
            {
                int pivotIndex = Partition(array, low, high);
                QuickSort(array, low, pivotIndex - 1);
                QuickSort(array, pivotIndex + 1, high);
            }
        }

        /// <summary>
        /// Reorders the segment of an array so that all elements with values less than the pivot come before the pivot,
        /// while all elements with values greater than the pivot come after it 
        /// </summary>
        /// <param name="array">Given array of integers</param>
        /// <param name="low">Start index of the segment that needs to be reordered</param>
        /// <param name="high">End index of the segment that needs to be reordered</param>
        /// <returns>Index of pivot element</returns>
        private static int Partition(int[] array, int low, int high)
        {
            int pivot = array[high];
            int pivotIndex = low;

            for (int i = low; i <= high - 1; i++)
            {
                if (array[i] <= pivot)
                {
                    (array[i], array[pivotIndex]) = (array[pivotIndex], array[i]);
                    pivotIndex++;
                }
            }

            (array[pivotIndex], array[high]) = (array[high], array[pivotIndex]);

            return pivotIndex;
        }

        /// <summary>
        /// Sorts array of integers using merge sort algorithm
        /// </summary>
        /// <param name="array">Given array of integers</param>
        public static void MergeSort(this int[] array)
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
            int[] leftArr = new int[mid];
            int[] rightArr = new int[array.Length - mid];

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
        private static void Merge(int[] array, int[] leftArr, int[] rightArr)
        {
            int i = 0;
            int j = 0;
            int k = 0;

            while (i < leftArr.Length && j < rightArr.Length)
            {
                if (leftArr[i] <= rightArr[j])
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
