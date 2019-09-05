using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomQueueLibrary
{
    /// <summary>
    /// Represents a custom doubly linked list
    /// </summary>
    /// <typeparam name="T">Specifies the element type of the linked list</typeparam>
    internal class CustomLinkedList<T> : IEnumerable<T>
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public CustomLinkedList()
        {
            First = null;
            Last = null;
            Count = 0;
        }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new linked list</param>
        public CustomLinkedList(IEnumerable<T> collection) : this()
        {
            if (collection == null)
            {
                throw new ArgumentNullException(null, "collection cannot be null");
            }

            foreach (T item in collection)
            {
                AddLast(item);
            }
        }

        /// <summary>
        /// Gets or sets the first node of the linked list
        /// </summary>
        public CustomLinkedListNode<T> First { get; private set; }

        /// <summary>
        /// Gets or sets the last node of the linked list
        /// </summary>
        public CustomLinkedListNode<T> Last { get; private set; }

        /// <summary>
        /// Gets or sets the number of nodes actually contained in the linked list
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Retrieves indexed value
        /// </summary>
        /// <param name="i">Index</param>
        /// <returns>Indexed value</returns>
        public T this[int i]
        {
            get
            {
                if (i >= Count || i < 0)
                {
                    throw new ArgumentException("invalid index");
                }

                CustomLinkedListNode<T> current = this.First;

                int j = 0;

                while (j < i)
                {
                    current = current.Next;
                    j++;
                }

                return current.Value;
            }
        }

        /// <summary>
        /// Adds a new node containing the specified value at the end of the linked list
        /// </summary>
        /// <param name="value">The value to add at the end of the linked list</param>
        public void AddLast(T value)
        {
            CustomLinkedListNode<T> node = new CustomLinkedListNode<T>(value);

            if (Count == 0)
            {
                First = node;
            }
            else
            {
                Last.Next = node;
                node.Previous = Last;
            }

            Last = node;

            Count++;
        }

        /// <summary>
        /// Removes the node at the start of the linked list
        /// </summary>
        public void RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("list is empty");
            }

            CustomLinkedListNode<T> previous = First;
            First = First.Next;
            previous.Next = null;

            Count--;

            if (Count == 0)
            {
                Last = null;
            }
            else
            {
                First.Previous = null;
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the linked list
        /// </summary>
        /// <returns>An enumerator for the linked list</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new CustomLinkedListEnumerator<T>(this);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the linked list
        /// </summary>
        /// <returns>An enumerator for the linked list</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
