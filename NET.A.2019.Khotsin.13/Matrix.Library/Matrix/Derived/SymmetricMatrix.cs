using System;

namespace Matrix.Library
{
    /// <summary>
    /// Represents symmetric matrix
    /// </summary>
    /// <typeparam name="T">Specifies the element type of the symmetric matrix</typeparam>
    public class SymmetricMatrix<T> : SquareMatrix<T>
    {
        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="order">Given order of the symmetric matrix</param>
        public SymmetricMatrix(int order) : base(order)
        {
        }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="array">Given 2d array to create symmetric matrix</param>
        public SymmetricMatrix(T[,] array) : base(array)
        {
            if (!this.IsSymmetric())
            {
                throw new ArgumentException("Impossible to create symmetric matrix with given array");
            }
        }

        /// <summary>
        /// Changes element in the symmetric matrix
        /// </summary>
        /// <param name="i">First index</param>
        /// <param name="j">Second index</param>
        /// <param name="value">Value to change element to</param>
        public override void ChangeElement(int i, int j, T value)
        {
            base.ChangeElement(i, j, value);
            base.ChangeElement(j, i, value);
        }
    }
}
