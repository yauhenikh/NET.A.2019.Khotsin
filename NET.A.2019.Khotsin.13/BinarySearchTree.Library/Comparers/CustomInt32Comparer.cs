using System.Collections.Generic;

namespace BinarySearchTreeLibrary
{
    /// <summary>
    /// Represents custom int comparer
    /// </summary>
    public class CustomInt32Comparer : IComparer<int>
    {
        /// <summary>
        /// Compares two integers by length of their string representation
        /// </summary>
        /// <param name="x">First integer</param>
        /// <param name="y">Second integer</param>
        /// <returns>An integer that indicates the relative values of the x and y parameters</returns>
        public int Compare(int x, int y)
        {
            return x.ToString().Length.CompareTo(y.ToString().Length);
        }
    }
}
