using Day4.Library;
using NUnit.Framework;
using System;

namespace Day4.Tests
{
    public class GcdCalculationTests
    {
        [TestCase(10, 20, 30, 40, 60, 100)]
        [TestCase(64, 1024, 320, 1024, -1024, 7000000)]
        [TestCase(5, -5, 100, 20)]
        public void GcdEuclidsAlgorithmTests(int expected, params int[] numbers)
        {
            // Arrange
            double executionTime;

            // Act
            int gcd = GcdCalculation.GcdEuclidsAlgorithm(out executionTime, numbers);

            // Assert
            Assert.AreEqual(expected, gcd);
            Assert.Less(executionTime, 100);
        }

        [TestCase(10, 50)]
        [TestCase(10, null)]
        public void GcdEuclidsAlgorithmTests_ArgumentException(int expected, params int[] numbers)
        {
            // Arrange
            double executionTime;

            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => GcdCalculation.GcdEuclidsAlgorithm(out executionTime, numbers));
        }

        [TestCase(25, -100, 75)]
        [TestCase(6, 12, 18, 36)]
        [TestCase(1, 17, 19, 16)]
        public void GcdSteinsAlgorithmTests(int expected, params int[] numbers)
        {
            // Arrange
            double executionTime;

            // Act
            int gcd = GcdCalculation.GcdSteinsAlgorithm(out executionTime, numbers);

            // Assert
            Assert.AreEqual(expected, gcd);
            Assert.Less(executionTime, 100);
        }

        [TestCase(9, 9)]
        [TestCase(1, null)]
        public void GcdSteinsAlgorithmTests_ArgumentException(int expected, params int[] numbers)
        {
            // Arrange
            double executionTime;

            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => GcdCalculation.GcdEuclidsAlgorithm(out executionTime, numbers));
        }
    }
}
