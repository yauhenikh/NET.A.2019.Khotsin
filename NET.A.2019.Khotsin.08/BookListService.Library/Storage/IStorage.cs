using System.Collections.Generic;

namespace BookListServiceLibrary
{
    /// <summary>
    /// Interface for storage classes
    /// </summary>
    public interface IStorage
    {
        /// <summary>
        /// Adds new book to the storage
        /// </summary>
        /// <param name="book">Book to add</param>
        void AddBook(Book book);

        /// <summary>
        /// Removes a book from the storage
        /// </summary>
        /// <param name="book">Book to remove</param>
        void RemoveBook(Book book);

        /// <summary>
        /// Finds books by tag
        /// </summary>
        /// <param name="tag">Tag for searching</param>
        /// <param name="search">Search query string</param>
        /// <returns>List containing found books</returns>
        IEnumerable<Book> FindBookByTag(Tags tag, string search);

        /// <summary>
        /// Sorts books by tag
        /// </summary>
        /// <param name="tag">Tag for sorting</param>
        void SortBooksByTag(Tags tag);

        /// <summary>
        /// Shows all books
        /// </summary>
        void ShowAll();
    }
}
