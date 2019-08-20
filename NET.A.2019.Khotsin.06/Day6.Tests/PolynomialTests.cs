using Day6.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day6.Tests
{
    [TestClass]
    public class PolynomialTests
    {
        [TestMethod]
        [DataRow(3, new double[] { 0, 1, 2, 3 })]
        [DataRow(3, new double[] { 0, 1, 2, 3, 0, 0 })]
        [DataRow(2, new double[] { 0, 0, 2, 0 })]
        [DataRow(0, new double[] { -0.22, 0, 0, 0 })]
        [DataRow(0, new double[] { 0, 0, 0, 0 })]
        public void ConstructorTest(int expected, params double[] coeffs)
        {
            // Arrange
            Polynomial polynomial = new Polynomial(coeffs);

            // Act
            int actual = polynomial.HighestDegree;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("5", new double[] { 5, 0 })]
        [DataRow("7x-5", new double[] { -5, 7 })]
        [DataRow("3x^2-2x+1", new double[] { 1, -2, 3 })]
        [DataRow("9.99x^4+8x^3-0.44", new double[] { -0.44, 0, 0, 8, 9.99 })]
        [DataRow("-6x^3", new double[] { 0, 0, 0, -6, 0 })]
        [DataRow("x-2", new double[] { -2, 1 })]
        [DataRow("x^2-3", new double[] { -3, 0, 1 })]
        public void ToStringTest(string expected, params double[] coeffs)
        {
            // Arrange
            Polynomial polynomial = new Polynomial(coeffs);

            // Act
            string actual = polynomial.ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(true, new double[] { 5, 0, 1 })]
        [DataRow(false, new double[] { 4, 0, 1 })]
        [DataRow(true, new double[] { 5, 0, 1, 0 })]
        [DataRow(true, new double[] { 5, 0, 1, 0, 0 })]
        public void EqualsTest(bool expected, params double[] coeffs)
        {
            // Arrange
            Polynomial polynomial1 = new Polynomial(coeffs);
            Polynomial polynomial2 = new Polynomial(5, 0, 1);

            // Act
            bool actual = polynomial1.Equals(polynomial2);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(false, new double[] { -1, 2, 3 })]
        [DataRow(false, new double[] { -1, 0, 2, 3, 4 })]
        [DataRow(true, new double[] { -1, 0, 2, 3, 0 })]
        [DataRow(true, new double[] { -1, 0, 2, 3, 0, 0, 0 })]
        public void EqualityOperatorTest(bool expected, params double[] coeffs)
        {
            // Arrange
            Polynomial polynomial1 = new Polynomial(coeffs);
            Polynomial polynomial2 = new Polynomial(-1, 0, 2, 3);

            // Act
            bool actual = polynomial1 == polynomial2;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(true, new double[] { -1, 2, 3 })]
        [DataRow(true, new double[] { -1, 0, 2, 3, 4 })]
        [DataRow(false, new double[] { -1, -1, 2, 0 })]
        [DataRow(false, new double[] { -1, -1, 2 })]
        public void InEqualityOperatorTest(bool expected, params double[] coeffs)
        {
            // Arrange
            Polynomial polynomial1 = new Polynomial(coeffs);
            Polynomial polynomial2 = new Polynomial(-1, -1, 2);

            // Act
            bool actual = polynomial1 != polynomial2;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(1075577007, new double[] { 1, 2, 3, 4, 5 })]
        [DataRow(388648421, new double[] { 0, -8.22 })]
        [DataRow(388648389, new double[] { -8.22 })]
        [DataRow(1075577007, new double[] { 1, 2, 3, 4, 5, 0, 0, 0 })]
        public void GetHashCodeTest(int expected, params double[] coeffs)
        {
            // Arrange
            Polynomial polynomial = new Polynomial(coeffs);

            // Act
            int actual = polynomial.GetHashCode();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("5x^2+x", new double[] { 1, 2, 3 })]
        [DataRow("2x^2-1.22x-1", new double[] { 0, -0.22 })]
        [DataRow("2x^2-x-23.22", new double[] { -22.22 })]
        [DataRow("5x^4+4x^3+5x^2+x-2", new double[] { -1, 2, 3, 4, 5, 0, 0, 0 })]
        public void OperatorPlusTest(string expected, params double[] coeffs)
        {
            // Arrange
            Polynomial polynomial1 = new Polynomial(coeffs);
            Polynomial polynomial2 = new Polynomial(-1, -1, 2);

            // Act
            string actual = (polynomial1 + polynomial2).ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("x^2+3x+2", new double[] { 1, 2, 3 })]
        [DataRow("-2x^2+0.78x+1", new double[] { 0, -0.22 })]
        [DataRow("-2x^2+x-21.22", new double[] { -22.22 })]
        [DataRow("5x^4+4x^3+x^2+3x", new double[] { -1, 2, 3, 4, 5, 0, 0, 0 })]
        public void OperatorMinusTest(string expected, params double[] coeffs)
        {
            // Arrange
            Polynomial polynomial1 = new Polynomial(coeffs);
            Polynomial polynomial2 = new Polynomial(-1, -1, 2);

            // Act
            string actual = (polynomial1 - polynomial2).ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("3.03x^2+2.02x+1.01", 1.01, new double[] { 1, 2, 3 })]
        [DataRow("-0.44x", 2, new double[] { 0, -0.22 })]
        [DataRow("22.22", -1, new double[] { -22.22 })]
        [DataRow("5.5x^4+4.4x^3+3.3x^2+2.2x-1.1", 1.1, new double[] { -1, 2, 3, 4, 5, 0, 0, 0 })]
        public void OperatorMultiplyPolynomialByNumberTest(string expected, double number, params double[] coeffs)
        {
            // Arrange
            Polynomial polynomial = new Polynomial(coeffs);

            // Act
            string actual = (polynomial * number).ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("3.03x^2+2.02x+1.01", 1.01, new double[] { 1, 2, 3 })]
        [DataRow("-0.44x", 2, new double[] { 0, -0.22 })]
        [DataRow("22.22", -1, new double[] { -22.22 })]
        [DataRow("5.5x^4+4.4x^3+3.3x^2+2.2x-1.1", 1.1, new double[] { -1, 2, 3, 4, 5, 0, 0, 0 })]
        public void OperatorMultiplyNumberByPolynomialTest(string expected, double number, params double[] coeffs)
        {
            // Arrange
            Polynomial polynomial = new Polynomial(coeffs);

            // Act
            string actual = (polynomial * number).ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("6x^4+x^3-3x^2-3x-1", new double[] { 1, 2, 3 })]
        [DataRow("-0.44x^3+0.22x^2+0.22x", new double[] { 0, -0.22 })]
        [DataRow("-44.44x^2+22.22x+22.22", new double[] { -22.22 })]
        [DataRow("10x^6+3x^5-3x^4-3x^3-7x^2-x+1", new double[] { -1, 2, 3, 4, 5, 0, 0, 0 })]
        public void OperatorMultiplyPolynomialByPolynomialTest(string expected, params double[] coeffs)
        {
            // Arrange
            Polynomial polynomial1 = new Polynomial(coeffs);
            Polynomial polynomial2 = new Polynomial(-1, -1, 2);

            // Act
            string actual = (polynomial1 * polynomial2).ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [DataRow("39.96x^3+24x^2", new double[] { -0.44, 0, 0, 8, 9.99 })]
        [DataRow("-18x^2", new double[] { 0, 0, 0, -6, 0 })]
        [DataRow("1", new double[] { -2, 1 })]
        [DataRow("2x", new double[] { -3, 0, 1 })]
        public void DerivativeTests(string expected, params double[] coeffs)
        {
            // Arrange
            Polynomial polynomial = new Polynomial(coeffs);

            // Act
            string actual = polynomial.Derivative().ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [DataRow(1, 2, new double[] { -3, 0, 1 })]
        [DataRow(5.2592, new double[] { 1, 0, 0, -1, 2 })]
        [DataRow(-22.22, 0, new double[] { -22.22 })]
        [DataRow(504030199, 100, new double[] { -1, 2, 3, 4, 5, 0, 0, 0 })]
        public void CalculateTests(double expected, double number, params double[] coeffs)
        {
            // Arrange
            Polynomial polynomial = new Polynomial(coeffs);

            // Act
            double actual = polynomial.Calculate(number);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
