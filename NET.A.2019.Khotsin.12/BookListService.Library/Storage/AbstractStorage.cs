using System;
using System.Collections.Generic;

namespace BookListServiceLibrary
{
    /// <summary>
    /// Abstract storage class
    /// </summary>
    public abstract class AbstractStorage : IStorage
    {
        protected readonly List<Book> _Books;

        /// <summary>
        /// Constructor
        /// </summary>
        public AbstractStorage()
        {
            this._Books = new List<Book>();
        }

        /// <summary>
        /// Adds new book to list
        /// </summary>
        /// <param name="book">Book to add</param>
        public virtual void AddBook(Book book)
        {
            if (this._Books.Contains(book))
            {
                throw new ArgumentException("The storage already contains book with the same ISBN");
            }

            this._Books.Add(book);
        }

        /// <summary>
        /// Removes a book from the list
        /// </summary>
        /// <param name="book">Book to remove</param>
        public virtual void RemoveBook(Book book)
        {
            if (!this._Books.Contains(book))
            {
                throw new ArgumentException("The storage doesn't contain given book");
            }

            this._Books.Remove(book);
        }

        /// <summary>
        /// Show all books in the list
        /// </summary>
        public virtual void ShowAll()
        {
            foreach (Book book in this._Books)
            {
                Console.WriteLine(book);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Finds books by tag
        /// </summary>
        /// <param name="tag">Tag for searching</param>
        /// <param name="search">Search query string</param>
        /// <returns>List containing found books</returns>
        public virtual IEnumerable<Book> FindBookByTag(Tags tag, string search)
        {
            foreach (var book in this._Books)
            {
                string value = BookComparer.GetPropValue(book, tag.ToString()).ToString();

                if (value.IndexOf(search, StringComparison.InvariantCultureIgnoreCase) > -1)
                {
                    yield return book;
                }
            }
        }

        /// <summary>
        /// Sorts books by tag
        /// </summary>
        /// <param name="tag">Tag for sorting</param>
        public virtual void SortBooksByTag(Tags tag)
        {
            this._Books.Sort(new BookComparer(tag));
        }
    }
}
