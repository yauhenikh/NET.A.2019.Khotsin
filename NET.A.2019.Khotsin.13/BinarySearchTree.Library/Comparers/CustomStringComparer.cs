using System.Collections.Generic;

namespace BinarySearchTreeLibrary
{
    public class CustomStringComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return x.Length.CompareTo(y.Length);
        }
    }
}
