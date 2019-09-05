using System.Linq;
using BinarySearchTreeLibrary;
using BookListServiceLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinarySearchTree.Tests
{
    [TestClass]
    public class BinarySearchTreeTests
    {
        [TestMethod]
        public void AddTest_PreOrderTraversal()
        {
            // Arrange
            int[] array = new int[] { 7, 9, 8, 1 };
            BinarySearchTree<int> tree = new BinarySearchTree<int>(array);
            int itemToAdd = 5;

            int[] expectedArray = new int[] { 7, 1, 5, 9, 8 };

            // Act
            tree.Add(itemToAdd);

            // Assert
            CollectionAssert.AreEqual(expectedArray, tree.PreOrderTraversal().ToArray());
        }

        [TestMethod]
        public void RemoveTest_InOrderTraversal()
        {
            // Arrange
            int[] array = new int[] { 7, 9, 8, 1 };
            BinarySearchTree<int> tree = new BinarySearchTree<int>(array);
            int itemToRemove = 7;

            int[] expectedArray = new int[] { 1, 8, 9 };

            // Act
            tree.Remove(itemToRemove);

            // Assert
            CollectionAssert.AreEqual(expectedArray, tree.InOrderTraversal().ToArray());
        }

        [TestMethod]
        public void Int32DefaultComparer_PostOrderTraversalTest()
        {
            // Arrange
            int[] array = new int[] { 7, 9, 8, 1 };
            BinarySearchTree<int> tree = new BinarySearchTree<int>(array);

            int[] expectedArray = new int[] { 1, 8, 9, 7 };

            // Act
            var result = tree.PostOrderTraversal();

            // Assert
            CollectionAssert.AreEqual(expectedArray, result.ToArray());
        }

        [TestMethod]
        public void Int32CustomComparer_PreOrderTraversalTest()
        {
            // Arrange
            int[] array = new int[] { -100, 9, -2000, 12 };
            BinarySearchTree<int> tree = new BinarySearchTree<int>(array, new CustomInt32Comparer());

            int[] expectedArray = new int[] { -100, 9, 12, -2000 };

            // Act
            var result = tree.PreOrderTraversal();

            // Assert
            CollectionAssert.AreEqual(expectedArray, result.ToArray());
        }

        [TestMethod]
        public void StringDefaultComparer_InOrderTraversalTest()
        {
            // Arrange
            string[] array = new string[] { "C#", ".NET Core", "BST", "Tree" };
            BinarySearchTree<string> tree = new BinarySearchTree<string>(array);

            string[] expectedArray = new string[] { ".NET Core", "BST", "C#", "Tree" };

            // Act
            var result = tree.InOrderTraversal();

            // Assert
            CollectionAssert.AreEqual(expectedArray, result.ToArray());
        }

        [TestMethod]
        public void StringCustomComparer_PostOrderTraversalTest()
        {
            // Arrange
            string[] array = new string[] { "C#", ".NET Core", "BST", "Tree" };
            BinarySearchTree<string> tree = new BinarySearchTree<string>(array, new CustomStringComparer());

            string[] expectedArray = new string[] { "Tree", "BST", ".NET Core", "C#" };

            // Act
            var result = tree.PostOrderTraversal();

            // Assert
            CollectionAssert.AreEqual(expectedArray, result.ToArray());
        }

        [TestMethod]
        public void BookDefaultComparer_PreOrderTraversalTest()
        {
            // Arrange
            Book twelveChairs = new Book(
                "978 - 0810114845",
                "Ilya Ilf, Evgeny Petrov",
                "The Twelve Chairs",
                "Northwestern University Press",
                1997,
                395,
                41.93m);
            Book gameOfThrones = new Book(
                "978 - 0553593716",
                "George R. R. Martin",
                "A Game of Thrones",
                "Bantam",
                2011,
                864,
                9.49m);
            Book designPatterns = new Book(
                "978-0596007126",
                "Eric Freeman, Elisabeth Robson, Bert Bates, Kathy Sierra",
                "Head First Design Patterns",
                "O'Reilly Media",
                2004,
                694,
                32.35m);
            Book danceWithDragons = new Book(
                "978-0553582017",
                "George R. R. Martin",
                "A Dance with Dragons",
                "Bantam",
                2013,
                1152,
                7.59m);

            BinarySearchTree<Book> tree = new BinarySearchTree<Book>();
            tree.Add(twelveChairs);
            tree.Add(gameOfThrones);
            tree.Add(designPatterns);
            tree.Add(danceWithDragons);

            Book[] expectedArray = new Book[] { twelveChairs, gameOfThrones, danceWithDragons, designPatterns };

            // Act
            var result = tree.PreOrderTraversal();

            // Assert
            CollectionAssert.AreEqual(expectedArray, result.ToArray());
        }

        [TestMethod]
        public void BookCustomComparer_InOrderTraversalTest()
        {
            // Arrange
            Book twelveChairs = new Book(
                "978 - 0810114845",
                "Ilya Ilf, Evgeny Petrov",
                "The Twelve Chairs",
                "Northwestern University Press",
                1997,
                395,
                41.93m);
            Book gameOfThrones = new Book(
                "978 - 0553593716",
                "George R. R. Martin",
                "A Game of Thrones",
                "Bantam",
                2011,
                864,
                9.49m);
            Book designPatterns = new Book(
                "978-0596007126",
                "Eric Freeman, Elisabeth Robson, Bert Bates, Kathy Sierra",
                "Head First Design Patterns",
                "O'Reilly Media",
                2004,
                694,
                32.35m);
            Book danceWithDragons = new Book(
                "978-0553582017",
                "George R. R. Martin",
                "A Dance with Dragons",
                "Bantam",
                2013,
                1152,
                7.59m);

            BinarySearchTree<Book> tree = new BinarySearchTree<Book>(new CustomBookComparer());
            tree.Add(twelveChairs);
            tree.Add(gameOfThrones);
            tree.Add(designPatterns);
            tree.Add(danceWithDragons);

            Book[] expectedArray = new Book[] { twelveChairs, designPatterns, gameOfThrones, danceWithDragons };

            // Act
            var result = tree.InOrderTraversal();

            // Assert
            CollectionAssert.AreEqual(expectedArray, result.ToArray());
        }

        [TestMethod]
        public void PointCustomComparer_PostOrderTraversalTest()
        {
            // Arrange
            Point point1 = new Point(3, 4);
            Point point2 = new Point(5, 12);
            Point point3 = new Point(2, 2);

            BinarySearchTree<Point> tree = new BinarySearchTree<Point>(new CustomPointComparer());
            tree.Add(point1);
            tree.Add(point2);
            tree.Add(point3);

            Point[] expectedArray = new Point[] { point3, point2, point1 };

            // Act
            var result = tree.PostOrderTraversal();

            // Assert
            CollectionAssert.AreEqual(expectedArray, result.ToArray());
        }
    }
}
