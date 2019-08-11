using Day2.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Day2TasksMSTestTests
    {
        [TestMethod]
        [DataRow(15, 15, 0, 0, 15)]
        [DataRow(8, 15, 0, 0, 9)]
        [DataRow(8, 15, 3, 8, 120)]
        public void InsertNumberShouldReturnExpectedValue(int numberSource, int numberIn, int i, int j, int expected)
        {
            // Arrange
            // Act
            int actual = Day2Tasks.InsertNumber(numberSource, numberIn, i, j);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}