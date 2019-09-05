using System.Collections.Generic;
using BookListServiceLibrary;

namespace BinarySearchTreeLibrary
{
    /// <summary>
    /// Represents custom book comparer
    /// </summary>
    public class CustomBookComparer : IComparer<Book>
    {
        /// <summary>
        /// Compares two books by their number of pages
        /// </summary>
        /// <param name="x">First book</param>
        /// <param name="y">Second book</param>
        /// <returns>An integer that indicates the relative values of the x and y parameters</returns>
        public int Compare(Book x, Book y)
        {
            return x.NumberOfPages.CompareTo(y.NumberOfPages);
        }
    }
}
