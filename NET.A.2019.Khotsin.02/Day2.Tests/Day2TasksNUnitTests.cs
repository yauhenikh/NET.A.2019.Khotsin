using Day2.Library;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Day2.Tests
{
    class Day2TasksNUnitTests
    {
        #region Insert Number Tests

        [TestCase(9, 8, 0, 0, 8)]
        [TestCase(8, 15, 3, 5, 56)]
        [TestCase(5, 3, 2, 3, 13)]
        public void InsertNumberShouldReturnExpectedValue(int numberSource, int numberIn, int i, int j, int expected)
        {
            // Arrange
            // Act
            int actual = Day2Tasks.InsertNumber(numberSource, numberIn, i, j);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Find Next Bigger Number Tests

        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(10, ExpectedResult = -1)]
        [TestCase(20, ExpectedResult = -1)]
        public int FindNextBiggerNumberShouldReturnExpectedValue(int numberSource)
        {
            // Arrange
            // Act
            // Assert
            return Day2Tasks.FindNextBiggerNumber(numberSource);
        }

        #endregion

        #region Find Next Bigger Number With Execution Time Task

        [Test]
        public void FindNextBiggerNumberWithExecutionTimeUsingDateTime_TimeShouldNotBeVeryLarge()
        {
            // Arrange
            double executionTime;

            // Act
            int biggerNumber = Day2Tasks.FindNextBiggerNumberWithExecutionTimeUsingDateTime(14324, out executionTime);

            // Assert
            Assert.AreEqual(14342, biggerNumber);
            Assert.Less(executionTime, 100);
        }

        [Test]
        public void FindNextBiggerNumberWithExecutionTimeUsingStopwatch_TimeShouldNotBeVeryLarge()
        {
            // Arrange
            double executionTime;

            // Act
            int biggerNumber = Day2Tasks.FindNextBiggerNumberWithExecutionTimeUsingDateTime(2465, out executionTime);

            // Assert
            Assert.AreEqual(2546, biggerNumber);
            Assert.Less(executionTime, 100);
        }

        #endregion

        #region Filter Digit Tests

        [TestCase(7, new int[] { 7, 70, 17 }, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17)]
        [TestCase(5, new int[] { 5, 1115, 55 }, 1, 5, 6, 7, 68, 1115, 17, 55)]
        [TestCase(0, new int[] { 10, 20, 10, 100 }, 10, 20, 1, 2, 3, 10, 100)]
        public void FilterDigitShouldReturnExpectedValue(int digit, IEnumerable<int> expected, params int[] numberList)
        {
            // Arrange
            // Act
            var actual = Day2Tasks.FilterDigit(digit, numberList);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        #endregion

        #region Find Nth Root Tests

        [TestCase(1, 5, 0.0001, ExpectedResult = 1)]
        [TestCase(0.001, 3, 0.0001, ExpectedResult = 0.1)]
        [TestCase(0.04100625, 4, 0.0001, ExpectedResult = 0.45)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.0279936, 7, 0.0001, ExpectedResult = 0.6)]
        [TestCase(0.0081, 4, 0.1, ExpectedResult = 0.3)]
        [TestCase(-0.008, 3, 0.1, ExpectedResult = -0.2)]
        [TestCase(0.004241979, 9, 0.00000001, ExpectedResult = 0.545)]
        public double FindNthRootShouldReturnExpectedValue(double numberSource, int degree, double precision)
        {
            // Arrange
            // Act
            // Assert
            return Day2Tasks.FindNthRoot(numberSource, degree, precision);
        }

        [TestCase(8, 15, -7, -5)]
        [TestCase(8, 15, -0.6, -0.1)]
        public void FindNthRoot_ArgumentOutOfRangeException(double number, int degree, double precision, double expected)
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => Day2Tasks.FindNthRoot(number, degree, precision));
        }

        #endregion
    }
}
