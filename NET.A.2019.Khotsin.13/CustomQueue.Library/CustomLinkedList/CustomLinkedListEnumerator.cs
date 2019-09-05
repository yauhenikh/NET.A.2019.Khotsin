using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomQueueLibrary
{
    /// <summary>
    /// Enumerates the elements of a linked list
    /// </summary>
    /// <typeparam name="T">Specifies the element type</typeparam>
    internal class CustomLinkedListEnumerator<T> : IEnumerator<T>
    {
        private CustomLinkedList<T> _list;
        private int position = -1;

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="list">Given linked list</param>
        public CustomLinkedListEnumerator(CustomLinkedList<T> list)
        {
            _list = list;
        }

        /// <summary>
        /// Gets the element at the current position of the enumerator
        /// </summary>
        public T Current
        {
            get
            {
                if (position == -1 || position >= _list.Count)
                {
                    throw new InvalidOperationException("invalid position value");
                }

                return _list[position];
            }
        }

        /// <summary>
        /// Gets the element at the current position of the enumerator
        /// </summary>
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        /// <summary>
        /// Releases all resources used by the enumerator
        /// </summary>
        public void Dispose()
        {
        }

        /// <summary>
        /// Advances the enumerator to the next element of the linked list
        /// </summary>
        /// <returns>True if the enumerator was successfully advanced to the next element</returns>
        public bool MoveNext()
        {
            if (position < _list.Count - 1)
            {
                position++;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Sets the enumerator to its initial position, which is before the first element in the collection
        /// </summary>
        public void Reset()
        {
            position = -1;
        }
    }
}
