using System;
using System.Collections.Generic;
using BinarySearchLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinarySearchTests
{
    [TestClass]
    public class BinarySearchTests
    {
        [TestMethod]
        [DataRow(new int[] { 5, 2, 3, 1, 6, int.MinValue, 7, int.MinValue }, 3, 2)]
        [DataRow(new int[] { 1, 1000, 2, 5, 3, 7, int.MinValue }, 7, 5)]
        [DataRow(new int[] { 1, 1000, 2, 5, 3, 7, int.MinValue }, int.MaxValue, null)]
        public void GenericBinarySearchTests_ForIntegers(IEnumerable<int> list, int key, int? expected)
        {
            // Arrange
            // Act
            var result = BinarySearch.Search(list, key);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(new string[] { "Head First", "Game Of Thrones", ".NET Core" }, ".NET Core", 2)]
        [DataRow(new string[] { "Head First", "Game Of Thrones", ".NET Core" }, "Twelve Chairs", null)]
        [DataRow(new string[] { "Head First", "Game Of Thrones", ".NET Core" }, ".NET CORE", null)]
        public void GenericBinarySearchTests_ForStrings(IEnumerable<string> list, string key, int? expected)
        {
            // Arrange
            // Act
            var result = BinarySearch.Search(list, key);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(new double[] { 2.0, 3.44, 5.22, 1.22 }, 0.44, null)]
        [DataRow(new double[] { 2.0, 3.44, 5.22, 1.22 }, 1.22, 3)]
        [DataRow(new double[] { 0, 1, 2, 3 }, 0, 0)]
        public void GenericBinarySearchTests_ForDoubles(IEnumerable<double> list, double key, int? expected)
        {
            // Arrange
            // Act
            var result = BinarySearch.Search(list, key);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
