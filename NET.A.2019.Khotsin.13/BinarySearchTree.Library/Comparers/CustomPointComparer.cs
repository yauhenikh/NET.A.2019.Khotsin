using System;
using System.Collections.Generic;

namespace BinarySearchTreeLibrary
{
    /// <summary>
    /// Represents custom point comparer
    /// </summary>
    public class CustomPointComparer : IComparer<Point>
    {
        /// <summary>
        /// Compares two points by their distance from the origin
        /// </summary>
        /// <param name="a">First point</param>
        /// <param name="b">Second point</param>
        /// <returns>An integer that indicates the relative values of the x and y parameters</returns>
        public int Compare(Point a, Point b)
        {
            return Math.Sqrt((a.X * a.X) + (a.Y * a.Y)).CompareTo(Math.Sqrt((b.X * b.X) + (b.Y * b.Y)));
        }
    }
}
