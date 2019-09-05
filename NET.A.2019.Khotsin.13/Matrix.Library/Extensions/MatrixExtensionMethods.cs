using System;

namespace Matrix.Library
{
    /// <summary>
    /// Represents class containing extension methods for matrix classes
    /// </summary>
    public static class MatrixExtensionMethods
    {
        /// <summary>
        /// Adds two matrices
        /// </summary>
        /// <typeparam name="T">Specifies the element type of the matrices</typeparam>
        /// <param name="first">First matrix</param>
        /// <param name="second">Second matrix</param>
        /// <returns>Matrix, representing sum of two matrices</returns>
        public static SquareMatrix<T> Add<T>(this SquareMatrix<T> first, SquareMatrix<T> second)
        {
            if (first.Order != second.Order)
            {
                throw new ArgumentException("Impossible to add matrices with different orders");
            }

            T[,] temp = new T[first.Order, first.Order];

            for (int i = 0; i < first.Order; i++)
            {
                for (int j = 0; j < first.Order; j++)
                {
                    dynamic firstOperand = first[i, j];
                    dynamic secondOperand = second[i, j];
                    temp[i, j] = firstOperand + secondOperand;
                }
            }

            return new SquareMatrix<T>(temp);
        }
    }
}
