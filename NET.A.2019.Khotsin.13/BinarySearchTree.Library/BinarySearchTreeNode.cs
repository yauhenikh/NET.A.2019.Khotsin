namespace BinarySearchTreeLibrary
{
    /// <summary>
    /// Represents node of binary search tree
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the node</typeparam>
    internal class BinarySearchTreeNode<T>
    {
        /// <summary>
        /// Constructor with 3 parameters
        /// </summary>
        /// <param name="value">Given value</param>
        public BinarySearchTreeNode(T value)
        {
            Value = value;
            Left = null;
            Right = null;
        }

        /// <summary>
        /// Reference to the left node
        /// </summary>
        public BinarySearchTreeNode<T> Left { get; internal set; }

        /// <summary>
        /// Reference to the right node
        /// </summary>
        public BinarySearchTreeNode<T> Right { get; internal set; }

        /// <summary>
        /// Value in the node
        /// </summary>
        public T Value { get; internal set; }
    }
}
