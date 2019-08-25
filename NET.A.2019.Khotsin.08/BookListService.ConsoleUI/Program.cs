using BookListServiceLibrary;
using System;

namespace BookListServiceConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Book twelveChairs = new Book("978 - 0810114845", "Ilya Ilf, Evgeny Petrov", "The Twelve Chairs",
                                         "Northwestern University Press", 1997, 395, 41.93m);
            Book gameOfThrones = new Book("978 - 0553593716", "George R. R. Martin", "A Game of Thrones",
                                          "Bantam", 2011, 864, 9.49m);
            Book designPatterns = new Book("978-0596007126", "Eric Freeman, Elisabeth Robson, Bert Bates, Kathy Sierra",
                                           "Head First Design Patterns", "O'Reilly Media", 2004, 694, 32.35m);
            Book danceWithDragons = new Book("978-0553582017", "George R. R. Martin", "A Dance with Dragons",
                                             "Bantam", 2013, 1152, 7.59m);
            Book orwell1984 = new Book("1328869334", "George Orwell", "1984", "Houghton Mifflin Harcourt", 2017, 304, 15.81m);

            Console.WriteLine("Create service with memory storage");
            IStorage memoryStorage = new MemoryStorage();
            BookListService bookListServiceMemoryStorage = new BookListService(memoryStorage);

            Console.WriteLine("Add book \"The Twelve Chairs\"");
            bookListServiceMemoryStorage.AddBook(twelveChairs);

            Console.WriteLine("Add book \"A Game of Thrones\"");
            bookListServiceMemoryStorage.AddBook(gameOfThrones);

            Console.WriteLine();

            Console.WriteLine("Show all books in storage:\n");
            bookListServiceMemoryStorage.ShowAll();

            Console.WriteLine("Try to add \"The Twelve Chairs\" again");
            try
            {
                bookListServiceMemoryStorage.AddBook(twelveChairs);
            }
            catch (Exception  e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("\n\nCreate service with binary file storage");
            IStorage binaryFileStorage = new BinaryFileStorage("books.dat");
            BookListService bookListServiceBinaryFileStorage = new BookListService(binaryFileStorage);

            Console.WriteLine("Add book \"A Game of Thrones\"");
            bookListServiceBinaryFileStorage.AddBook(gameOfThrones);
            Console.WriteLine("Add book \"A Dance with Dragons\"");
            bookListServiceBinaryFileStorage.AddBook(danceWithDragons);
            Console.WriteLine("Add book \"1984\"");
            bookListServiceBinaryFileStorage.AddBook(orwell1984);
            Console.WriteLine("Add book \"Head First Design Patterns\"");
            bookListServiceBinaryFileStorage.AddBook(designPatterns);

            Console.WriteLine("\nList of books in binary file storage:\n");
            bookListServiceBinaryFileStorage.ShowAll();

            Console.WriteLine("\nFind books whose authors contains \"george\"\n");
            var list = bookListServiceBinaryFileStorage.FindBookByTag(Tags.Author, "george");
            foreach (var book in list)
            {
                Console.WriteLine(book);
                Console.WriteLine();
            }

            Console.WriteLine("\nSort books by number of pages");
            bookListServiceBinaryFileStorage.SortBooksByTag(Tags.NumberOfPages);
            Console.WriteLine("\nSorted list of books:\n");
            bookListServiceBinaryFileStorage.ShowAll();

            Console.WriteLine("\nRemove \"A Game of Thrones\"");
            bookListServiceBinaryFileStorage.RemoveBook(gameOfThrones);
            Console.WriteLine("\nRemove \"A Dance with Dragons\"");
            bookListServiceBinaryFileStorage.RemoveBook(danceWithDragons);

            Console.WriteLine("\nList of books:\n");
            bookListServiceBinaryFileStorage.ShowAll();

            Console.WriteLine("\nRemove \"1984\"");
            bookListServiceBinaryFileStorage.RemoveBook(orwell1984);
            Console.WriteLine("\nRemove \"Head First Design Patterns\"");
            bookListServiceBinaryFileStorage.RemoveBook(designPatterns);

            Console.ReadLine();
        }
    }
}
