using System.Collections.Generic;

namespace BookListServiceLibrary
{
    /// <summary>
    /// Represents book list service
    /// </summary>
    public class BookListService
    {
        private readonly IStorage _storage;

        /// <summary>
        /// Default constructor
        /// </summary>
        public BookListService()
        {
           this._storage = new MemoryStorage();
        }

        /// <summary>
        /// Parametrized constructor
        /// </summary>
        /// <param name="storage">Storage to contain books</param>
        public BookListService(IStorage storage)
        {
            this._storage = storage;
        }

        /// <summary>
        /// Adds new book to the storage
        /// </summary>
        /// <param name="book">Book to add</param>
        public void AddBook(Book book)
        {
            this._storage.AddBook(book);
        }

        /// <summary>
        /// Removes a book from the storage
        /// </summary>
        /// <param name="book">Book to remove</param>
        public void RemoveBook(Book book)
        {
            this._storage.RemoveBook(book);
        }

        /// <summary>
        /// Finds books by tag
        /// </summary>
        /// <param name="tag">Tag for searching</param>
        /// <param name="search">Search query string</param>
        /// <returns>List containing found books</returns>
        public IEnumerable<Book> FindBookByTag(Tags tag, string search)
        {
            return this._storage.FindBookByTag(tag, search);
        }

        /// <summary>
        /// Sorts books by tag
        /// </summary>
        /// <param name="tag">Tag for sorting</param>
        public void SortBooksByTag(Tags tag)
        {
            this._storage.SortBooksByTag(tag);
        }

        /// <summary>
        /// Shows all books
        /// </summary>
        public void ShowAll()
        {
            this._storage.ShowAll();
        }
    }
}
