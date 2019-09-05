using System;

namespace Matrix.Library
{
    /// <summary>
    /// Represents diagonal matrix
    /// </summary>
    /// <typeparam name="T">Specifies the element type of the diagonal matrix</typeparam>
    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="order">Given order of the diagonal matrix</param>
        public DiagonalMatrix(int order) : base(order)
        {
        }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="array">Given 2d array to create diagonal matrix</param>
        public DiagonalMatrix(T[,] array) : base(array)
        {
            if (!this.IsDiagonal())
            {
                throw new ArgumentException("Impossible to create diagonal matrix with given array");
            }
        }

        /// <summary>
        /// Changes element in the diagonal matrix
        /// </summary>
        /// <param name="i">First index</param>
        /// <param name="j">Second index</param>
        /// <param name="value">Value to change element to</param>
        public override void ChangeElement(int i, int j, T value)
        {
            if (i != j)
            {
                throw new ArgumentException("Impossible to change element outside the main diagonal");
            }

            base.ChangeElement(i, j, value);
        }
    }
}
