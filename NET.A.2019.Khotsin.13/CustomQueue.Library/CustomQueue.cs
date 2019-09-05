using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomQueueLibrary
{
    /// <summary>
    /// Represents a custom first-in, first-out collection of objects
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the queue</typeparam>
    public class CustomQueue<T> : IEnumerable<T>
    {
        private CustomLinkedList<T> _list;

        /// <summary>
        /// Default constructor
        /// </summary>
        public CustomQueue()
        {
            _list = new CustomLinkedList<T>();
        }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new queue</param>
        public CustomQueue(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(null, "collection cannot be null");
            }

            _list = new CustomLinkedList<T>(collection);
        }

        /// <summary>
        /// Gets the number of elements contained in the queue
        /// </summary>
        public int Count
        {
            get
            {
                return _list.Count;
            }
        }

        /// <summary>
        /// Adds an object to the end of the queue
        /// </summary>
        /// <param name="item">The object to add to the queue</param>
        public void Enqueue(T item)
        {
            _list.AddLast(item);
        }

        /// <summary>
        /// Removes and returns the object at the beginning of the queue
        /// </summary>
        /// <returns>The object that is removed from the beginning of the queue</returns>
        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("queue is empty");
            }

            T item = _list.First.Value;
            _list.RemoveFirst();

            return item;
        }

        /// <summary>
        /// Returns the object at the beginning of the queue
        /// </summary>
        /// <returns>The object at the beginning of the queue</returns>
        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("queue is empty");
            }

            return _list.First.Value;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the queue
        /// </summary>
        /// <returns>An enumerator for the queue</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the queue
        /// </summary>
        /// <returns>An enumerator for the queue</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
