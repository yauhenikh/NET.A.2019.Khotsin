using System;
using System.Collections.Generic;
using Matrix.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Matrix.Tests
{
    [TestClass]
    public class MatrixTests
    {
        [TestMethod]
        public void CreateSquareMatrixTest()
        {
            // Arrange
            double[,] array = new double[2, 2]
            {
                { 1.22, 3.2 },
                { 4.22, 2 }
            };

            // Act
            SquareMatrix<double> matrix = new SquareMatrix<double>(array);

            // Assert
            Assert.AreEqual(2, matrix.Order);
        }

        [TestMethod]
        public void CreateSymmetricMatrixTest_ArgumentException()
        {
            // Arrange
            int[,] array = new int[2, 2]
            {
                { 0, 1 },
                { 2, 0 }
            };

            // Act
            // Assert
            Assert.ThrowsException<ArgumentException>(() => new SymmetricMatrix<int>(array));
        }

        [TestMethod]
        public void CreateDiagonalMatrixTest_ArgumentException()
        {
            // Arrange
            float[,] array = new float[2, 2]
            {
                { 0, 1.0f },
                { 0.0f, 0 }
            };

            // Act
            // Assert
            Assert.ThrowsException<ArgumentException>(() => new DiagonalMatrix<float>(array));
        }

        [TestMethod]
        public void TransposeTest()
        {
            // Arrange
            int[,] array = new int[4, 4]
            {
                { 1, 0, 0, 0 },
                { 0, 5, 0, 0 },
                { 0, 0, 9, 0 },
                { 0, 0, 12, 0 }
            };
            int[,] expectedArray = new int[4, 4]
            {
                { 1, 0, 0, 0 },
                { 0, 5, 0, 0 },
                { 0, 0, 9, 12 },
                { 0, 0, 0, 0 }
            };

            SquareMatrix<int> matrix = new SquareMatrix<int>(array);
            SquareMatrix<int> expectedMatrix = new SquareMatrix<int>(expectedArray);

            // Act
            matrix.Transpose();

            // Assert
            for (int i = 0; i < matrix.Order; i++)
            {
                for (int j = 0; j < matrix.Order; j++)
                {
                    Assert.AreEqual(expectedMatrix[i, j], matrix[i, j]);
                }
            }
        }

        [TestMethod]
        public void ElementChangedTest()
        {
            // Arrange
            short[,] array = new short[4, 4]
            {
                { 1, 1, 1, 4 },
                { 1, 1, 1, 3 },
                { 1, 1, 1, 2 },
                { 4, 3, 2, 1 }
            };
            SymmetricMatrix<short> matrix = new SymmetricMatrix<short>(array);
            List<string> receivedEvents = new List<string>();

            // Act
            matrix.ElementChanged += delegate(object sender, ElementChangedEventArgs e)
            {
                receivedEvents.Add(e.Message);
            };

            matrix.ChangeElement(0, 2, 5);

            // Assert
            Assert.AreEqual(2, receivedEvents.Count);
            Assert.AreEqual("Element [0, 2] changed to 5", receivedEvents[0]);
            Assert.AreEqual("Element [2, 0] changed to 5", receivedEvents[1]);
        }

        [TestMethod]
        public void AddTest()
        {
            // Arrange
            int[,] array1 = new int[4, 4]
            {
                { 1, 1, 1, 4 },
                { 1, 1, 1, 3 },
                { 1, 1, 1, 2 },
                { 4, 3, 2, 1 }
            };

            int[,] array2 = new int[4, 4]
            {
                { 1, 0, 0, 0 },
                { 0, 3, 0, 0 },
                { 0, 0, 2, 0 },
                { 0, 0, 0, 4 }
            };

            int[,] expectedArray = new int[4, 4]
            {
                { 2, 1, 1, 4 },
                { 1, 4, 1, 3 },
                { 1, 1, 3, 2 },
                { 4, 3, 2, 5 }
            };

            SymmetricMatrix<int> matrix1 = new SymmetricMatrix<int>(array1);
            DiagonalMatrix<int> matrix2 = new DiagonalMatrix<int>(array2);
            SquareMatrix<int> expectedMatrix = new SquareMatrix<int>(expectedArray);

            // Act
            var result = matrix1.Add(matrix2);

            // Assert
            for (int i = 0; i < result.Order; i++)
            {
                for (int j = 0; j < result.Order; j++)
                {
                    Assert.AreEqual(expectedMatrix[i, j], result[i, j]);
                }
            }
        }
    }
}
