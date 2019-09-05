using System.Collections.Generic;

namespace BinarySearchTreeLibrary
{
    public class CustomInt32Comparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return x.ToString().Length.CompareTo(y.ToString().Length);
        }
    }
}
