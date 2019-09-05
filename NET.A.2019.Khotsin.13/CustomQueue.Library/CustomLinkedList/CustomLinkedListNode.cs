namespace CustomQueueLibrary
{
    /// <summary>
    /// Represents a node in a CustomQueueLibrary.CustomLinkedList
    /// </summary>
    /// <typeparam name="T">Specifies the element type of the linked list</typeparam>
    internal class CustomLinkedListNode<T>
    {
        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="value">The value to contain in the node</param>
        public CustomLinkedListNode(T value)
        {
            Value = value;
            Next = null;
            Previous = null;
        }

        /// <summary>
        /// Gets or sets the next node in the linked list
        /// </summary>
        public CustomLinkedListNode<T> Next { get; internal set; }

        /// <summary>
        /// Gets or sets the previous node in the linked list
        /// </summary>
        public CustomLinkedListNode<T> Previous { get; internal set; }

        /// <summary>
        /// Gets or sets the value contained in the node
        /// </summary>
        public T Value { get; internal set; }
    }
}
