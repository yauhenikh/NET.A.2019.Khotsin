using System.Collections.Generic;

namespace BinarySearchTreeLibrary
{
    /// <summary>
    /// Represents custom string comparer
    /// </summary>
    public class CustomStringComparer : IComparer<string>
    {
        /// <summary>
        /// Compares strings by their length
        /// </summary>
        /// <param name="x">First string</param>
        /// <param name="y">Second string</param>
        /// <returns>An integer that indicates the relative values of the x and y parameters</returns>
        public int Compare(string x, string y)
        {
            return x.Length.CompareTo(y.Length);
        }
    }
}
