using System.Collections.Generic;
using BookListServiceLibrary;

namespace BinarySearchTreeLibrary
{
    public class CustomBookComparer : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return x.NumberOfPages.CompareTo(y.NumberOfPages);
        }
    }
}
