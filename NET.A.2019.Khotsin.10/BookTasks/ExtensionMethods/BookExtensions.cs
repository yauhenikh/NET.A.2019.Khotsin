using System.Globalization;
using System.Threading;
using BookListServiceLibrary;

namespace BookTasks
{
    /// <summary>
    /// Extension methods for Book class
    /// </summary>
    public static class BookExtensions
    {
        /// <summary>
        /// Converts a book to its string representation with specified culture parameter
        /// </summary>
        /// <param name="book">Parameter specifies which type (Book in this case) the method operates on</param>
        /// <param name="cultureName">Culture, specified by name</param>
        /// <returns>String that represents book</returns>
        public static string ToString(this Book book, string cultureName)
        {
            CultureInfo ci = new CultureInfo(cultureName);
            Thread.CurrentThread.CurrentCulture = ci;

            return $"ISBN: {book.ISBN}\n" +
                   $"Author: {book.Author}\n" +
                   $"Title: {book.Title}\n" +
                   $"Publisher: {book.Publisher}\n" +
                   $"Year of publication: {book.YearOfPublication}\n" +
                   $"Number of pages: {book.NumberOfPages}\n" +
                   $"Price: {book.Price:C2}";
        }
    }
}
