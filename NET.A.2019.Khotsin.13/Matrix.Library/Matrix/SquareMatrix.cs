using System;
using System.Collections.Generic;

namespace Matrix.Library
{
    /// <summary>
    /// Represents square matrix
    /// </summary>
    /// <typeparam name="T">Specifies the element type of the square matrix</typeparam>
    public class SquareMatrix<T>
    {
        private T[,] _values;

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="order">Given order of the square matrix</param>
        public SquareMatrix(int order)
        {
            if (order <= 0)
            {
                throw new ArgumentException("Order of matrix cannot be less or equal to zero");
            }

            _values = new T[order, order];
            Order = order;
        }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="array">Given 2d array to create square matrix</param>
        public SquareMatrix(T[,] array)
        {
            if (array.GetUpperBound(0) != array.GetUpperBound(0))
            {
                throw new ArgumentException("Number of rows in given array is not equal to number of columns");
            }

            if (array.GetUpperBound(0) == -1)
            {
                throw new ArgumentException("Impossible to create matrix of zero order");
            }

            _values = array;
            Order = array.GetUpperBound(0) + 1;
        }

        /// <summary>
        /// Represents the method with object and ElementChangedEventArgs parameters
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">An object that contains the event data</param>
        public delegate void ElementChangedEventHandler(object sender, ElementChangedEventArgs e);

        /// <summary>
        /// Event, raising when the element in square matrix is changed
        /// </summary>
        public event ElementChangedEventHandler ElementChanged;

        /// <summary>
        /// The order of square matrix
        /// </summary>
        public int Order { get; private set; }

        /// <summary>
        /// Retrieves indexed value
        /// </summary>
        /// <param name="i">First index</param>
        /// <param name="j">Second index</param>
        /// <returns>Indexed value</returns>
        public T this[int i, int j]
        {
            get
            {
                if (i < 0 ||
                i >= Order ||
                j < 0 ||
                j >= Order)
                {
                    throw new ArgumentException("Invalid index value");
                }

                return _values[i, j];
            }

            set
            {
                ChangeElement(i, j, value);
            }
        }

        /// <summary>
        /// Transposes square matrix
        /// </summary>
        public void Transpose()
        {
            T[,] tempArr = new T[Order, Order];

            for (int i = 0; i < Order; i++)
            {
                for (int j = 0; j < Order; j++)
                {
                    tempArr[j, i] = _values[i, j];
                }
            }

            _values = tempArr;
        }

        /// <summary>
        /// Changes element in the square matrix
        /// </summary>
        /// <param name="i">First index</param>
        /// <param name="j">Second index</param>
        /// <param name="value">Value to change element to</param>
        public virtual void ChangeElement(int i, int j, T value)
        {
            if (i < 0 ||
                i >= Order ||
                j < 0 ||
                j >= Order)
            {
                throw new ArgumentException("Invalid index value");
            }

            _values[i, j] = value;

            OnElementChanged(this, new ElementChangedEventArgs($"Element [{i}, {j}] changed to {value}"));
        }

        /// <summary>
        /// Converts a square matrix to its string representation
        /// </summary>
        /// <returns>String that represents square matrix</returns>
        public override string ToString()
        {
            string res = string.Empty;

            for (int i = 0; i < Order; i++)
            {
                for (int j = 0; j < Order; j++)
                {
                    res += string.Format("{0, -8}", _values[i, j]);
                }

                res += "\n";
            }

            return res;
        }

        /// <summary>
        /// Determines if matrix is symmetric
        /// </summary>
        /// <returns>True, if matrix is symmetric</returns>
        protected bool IsSymmetric()
        {
            int colIndex = 1;

            for (int i = 0; i < Order - 1; i++)
            {
                for (int j = colIndex; j < Order; j++)
                {
                    if (Comparer<T>.Default.Compare(_values[i, j], _values[j, i]) != 0)
                    {
                        return false;
                    }
                }

                colIndex++;
            }

            return true;
        }

        /// <summary>
        /// Determines if matrix is diagonal
        /// </summary>
        /// <returns></returns>
        protected bool IsDiagonal()
        {
            for (int i = 0; i < Order; i++)
            {
                for (int j = 0; j < Order; j++)
                {
                    if (i != j && Comparer<T>.Default.Compare(_values[i, j], default(T)) != 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Method responsible for notification of ElementChanged event
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">An object that contains the event data</param>
        protected virtual void OnElementChanged(object sender, ElementChangedEventArgs e)
        {
            if (ElementChanged != null)
            {
                ElementChanged(sender, e);
            }
        }
    }
}
