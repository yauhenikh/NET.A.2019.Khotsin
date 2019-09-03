using System.IO;
using BookListServiceLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookListServiceLoggerTests
{
    [TestClass]
    public class LoggerTests
    {
        [TestMethod]
        public void BookServiceLoggerTests()
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

            BookListService bookListServiceMemoryStorage = new BookListService(new MemoryStorage(), new SimpleLogger());
            string line;
            if (File.Exists("SimpleLogFile.log"))
            {
                File.Delete("SimpleLogFile.log");
            }

            // Act
            bookListServiceMemoryStorage.AddBook(twelveChairs);
            using (StreamReader reader = new StreamReader("SimpleLogFile.log"))
            {
                line = reader.ReadLine();
            }

            int index = line.IndexOf(' ', line.IndexOf(' ') + 1);
            line = line.Substring(index + 1).TrimEnd();

            // Assert
            Assert.AreEqual("Info Book \"The Twelve Chairs\" with ISBN 978 - 0810114845 added", line);

            // Act
            bookListServiceMemoryStorage.AddBook(gameOfThrones);
            using (StreamReader reader = new StreamReader("SimpleLogFile.log"))
            {
                line = reader.ReadLine();
                line = reader.ReadLine();
            }

            index = line.IndexOf(' ', line.IndexOf(' ') + 1);
            line = line.Substring(index + 1).TrimEnd();

            // Assert
            Assert.AreEqual("Info Book \"A Game of Thrones\" with ISBN 978 - 0553593716 added", line);

            // Act
            try
            {
                bookListServiceMemoryStorage.AddBook(twelveChairs);
            }
            catch
            {
            }

            using (StreamReader reader = new StreamReader("SimpleLogFile.log"))
            {
                line = reader.ReadLine();
                line = reader.ReadLine();
                line = reader.ReadLine();
            }

            index = line.IndexOf(' ', line.IndexOf(' ') + 1);
            line = line.Substring(index + 1).TrimEnd();

            // Assert
            Assert.AreEqual("Error The storage already contains book with the same ISBN", line);
        }
    }
}
