using System;
using System.Collections.Generic;
using System.Linq;
using FibonacciNumbersGenerator.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FibonacciNumbersGenerator.Tests
{
    [TestClass]
    public class FibonacciGeneratorTests
    {
        [TestMethod]
        [DataRow(3, new[] { 0, 1, 1 })]
        [DataRow(1, new[] { 0 })]
        [DataRow(10, new[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 })]
        public void GenerateFibonacciSequenceTests(int count, IEnumerable<int> expected)
        {
            // Arrange
            // Act
            var result = FibonacciGenerator.GenerateFibonacciSequence(count);

            // Assert
            CollectionAssert.AreEqual(expected.ToArray(), result.ToArray());
        }

        [TestMethod]
        [DataRow(0, new[] { 0 })]
        [DataRow(-100, new[] { 0 })]
        public void GenerateFibonacciSequenceTests_ArgumentException(int count, IEnumerable<int> expected)
        {
            // Arrange
            // Act
            // Assert
            Assert.ThrowsException<ArgumentException>(() => FibonacciGenerator.GenerateFibonacciSequence(count).ToArray());
        }

        [TestMethod]
        [DataRow(48, new[] { 0, 1, 1 })]
        [DataRow(int.MaxValue, new[] { 0, 1, 1 })]
        public void GenerateFibonacciSequenceTests_OverflowException(int count, IEnumerable<int> expected)
        {
            // Arrange
            // Act
            // Assert
            Assert.ThrowsException<OverflowException>(() => FibonacciGenerator.GenerateFibonacciSequence(count).ToArray());
        }
    }
}
