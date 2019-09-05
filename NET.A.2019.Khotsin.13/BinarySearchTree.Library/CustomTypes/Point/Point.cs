namespace BinarySearchTreeLibrary
{
    /// <summary>
    /// Represents point with coordinates x, y
    /// </summary>
    public struct Point
    {
        /// <summary>
        /// Constructor with 2 parameters
        /// </summary>
        /// <param name="x">x coordinate</param>
        /// <param name="y">y coordinate</param>
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// x coordinate
        /// </summary>
        public int X { get; private set; }

        /// <summary>
        /// y coordinate
        /// </summary>
        public int Y { get; private set; }
    }
}
