using System;
using System.Collections.Generic;

namespace BookListServiceLibrary
{
    /// <summary>
    /// Represents book list service
    /// </summary>
    public class BookListService
    {
        private readonly IStorage _storage;
        private readonly ILogger _logger;

        /// <summary>
        /// Default constructor
        /// </summary>
        public BookListService()
        {
           this._storage = new MemoryStorage();
           this._logger = new SimpleLogger();
        }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="storage">Storage to contain books</param>
        public BookListService(IStorage storage)
        {
            this._storage = storage;
            this._logger = new SimpleLogger();
        }

        /// <summary>
        /// Constructor with 2 parameters
        /// </summary>
        /// <param name="storage">Storage to contain books</param>
        /// <param name="logger">Logger to log messages</param>
        public BookListService(IStorage storage, ILogger logger)
            : this(storage)
        {
            this._logger = logger;
        }

        /// <summary>
        /// Adds new book to the storage
        /// </summary>
        /// <param name="book">Book to add</param>
        public void AddBook(Book book)
        {
            try
            {
                this._storage.AddBook(book);
                _logger.Info($"Book \"{book.Title}\" with ISBN {book.ISBN} added");
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Removes a book from the storage
        /// </summary>
        /// <param name="book">Book to remove</param>
        public void RemoveBook(Book book)
        {
            try
            {
                this._storage.RemoveBook(book);
                _logger.Info($"Book \"{book.Title}\" with ISBN {book.ISBN} removed");
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Finds books by tag
        /// </summary>
        /// <param name="tag">Tag for searching</param>
        /// <param name="search">Search query string</param>
        /// <returns>List containing found books</returns>
        public IEnumerable<Book> FindBookByTag(Tags tag, string search)
        {
            _logger.Info($"Searching books by tag: \"{tag}\" and search string: \"{search}\"");

            return this._storage.FindBookByTag(tag, search);
        }

        /// <summary>
        /// Sorts books by tag
        /// </summary>
        /// <param name="tag">Tag for sorting</param>
        public void SortBooksByTag(Tags tag)
        {
            _logger.Info($"Sorting books by tag: \"{tag}\"");

            this._storage.SortBooksByTag(tag);
        }

        /// <summary>
        /// Shows all books
        /// </summary>
        public void ShowAll()
        {
            _logger.Info($"Showing all books");

            this._storage.ShowAll();
        }
    }
}
