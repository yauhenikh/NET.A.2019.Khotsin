using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EuclidsAlgorithm.Tests
{
    [TestClass]
    public class EuclidsAlgorithmTests
    {
        [TestMethod]
        [DataRow(10, new int[] { 20, 30, 40, 60, 100 })]
        [DataRow(64, new int[] { 1024, 320, 1024, -1024, 7000000 })]
        [DataRow(5, new int[] { -5, 100, 20 })]
        public void GcdEuclidsAlgorithmTests(int expected, params int[] numbers)
        {
            // Arrange
            double executionTime;

            // Act
            int gcd = EuclidsAlgorithmRefactoring.GcdEuclidsAlgorithm(out executionTime, numbers);

            // Assert
            Assert.AreEqual(expected, gcd);
            Assert.IsTrue(executionTime < 100);
        }

        [TestMethod]
        [DataRow(10, new int[] { 50 })]
        [DataRow(10, null)]
        public void GcdEuclidsAlgorithmTests_ArgumentException(int expected, params int[] numbers)
        {
            // Arrange
            double executionTime;

            // Act
            // Assert
            Assert.ThrowsException<ArgumentException>(() => EuclidsAlgorithmRefactoring.GcdEuclidsAlgorithm(out executionTime, numbers));
        }

        [TestMethod]
        [DataRow(25, new int[] { -100, 75 })]
        [DataRow(6, new int[] { 12, 18, 36 })]
        [DataRow(1, new int[] { 17, 19, 16 })]
        public void GcdSteinsAlgorithmTests(int expected, params int[] numbers)
        {
            // Arrange
            double executionTime;

            // Act
            int gcd = EuclidsAlgorithmRefactoring.GcdSteinsAlgorithm(out executionTime, numbers);

            // Assert
            Assert.AreEqual(expected, gcd);
            Assert.IsTrue(executionTime < 100);
        }

        [TestMethod]
        [DataRow(9, new int[] { 9 })]
        [DataRow(1, null)]
        public void GcdSteinsAlgorithmTests_ArgumentException(int expected, params int[] numbers)
        {
            // Arrange
            double executionTime;

            // Act
            // Assert
            Assert.ThrowsException<ArgumentException>(() => EuclidsAlgorithmRefactoring.GcdEuclidsAlgorithm(out executionTime, numbers));
        }
    }
}
