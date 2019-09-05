using System.Collections.Generic;
using System.Linq;
using CustomQueueLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CustomQueueTests
{
    [TestClass]
    public class CustomQueueTests
    {
        [TestMethod]
        public void ConstructorWithoutParametersTest_Count_Should_Be_0()
        {
            // Arrange
            CustomQueue<int> queue = new CustomQueue<int>();

            // Act
            var result = queue.Count;

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [DataRow(new double[] { 5, 4, 3, 1 }, 4)]
        [DataRow(new double[] { 1.1, 0.3333 }, 2)]
        [DataRow(new double[] { }, 0)]
        public void ConstructorWithParameterTests(IEnumerable<double> collection, int expected)
        {
            // Arrange
            CustomQueue<double> queue = new CustomQueue<double>(collection);

            // Act
            var result = queue.Count;

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(new char[] { '1', 'a' }, 'q', new char[] { '1', 'a', 'q' })]
        [DataRow(new char[] { }, 'a', new char[] { 'a' })]
        public void EnqueueTests(IEnumerable<char> collection, char value, IEnumerable<char> expected)
        {
            // Arrange
            CustomQueue<char> queue = new CustomQueue<char>(collection);

            // Act
            queue.Enqueue(value);

            // Assert
            CollectionAssert.AreEqual(expected.ToArray(), queue.ToArray());
        }

        [TestMethod]
        [DataRow(new sbyte[] { sbyte.MaxValue, 1, 3, -5 }, sbyte.MaxValue, new sbyte[] { 1, 3, -5 })]
        [DataRow(new sbyte[] { 0 }, (sbyte)0, new sbyte[] { })]
        public void DequeueTests(IEnumerable<sbyte> collection, sbyte value, IEnumerable<sbyte> expected)
        {
            // Arrange
            CustomQueue<sbyte> queue = new CustomQueue<sbyte>(collection);

            // Act
            var result = queue.Dequeue();

            // Assert
            Assert.AreEqual(value, result);
            CollectionAssert.AreEqual(expected.ToArray(), queue.ToArray());
        }

        [TestMethod]
        [DataRow(new string[] { "aaa", "bbbbb", "ccasd" }, "aaa")]
        [DataRow(new string[] { null, "aaa" }, null)]
        public void PeekTests(IEnumerable<string> collection, string expected)
        {
            // Arrange
            CustomQueue<string> queue = new CustomQueue<string>(collection);

            // Act
            var result = queue.Dequeue();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetEnumeratorTests()
        {
            // Arrange
            int[] sourceArray = new int[] { 6, 5, 4 };
            CustomQueue<int> queue = new CustomQueue<int>(sourceArray);
            List<int> result = new List<int>();

            // Act
            foreach (var item in queue)
            {
                result.Add(item);
            }

            // Assert
            CollectionAssert.AreEqual(sourceArray, result);
        }
    }
}
