using System;
using System.Globalization;
using System.Threading;
using BookTasks;

namespace BookListServiceLibrary
{
    /// <summary>
    /// Represents book
    /// </summary>
    public class Book : IComparable, IBook
    {
        #region Fields

        private string _isbn;
        private string _author;
        private string _title;
        private string _publisher;
        private int _yearOfPublication;
        private int _numberOfPages;
        private decimal _price;

        #endregion

        #region Constructor

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="isbn">Given ISBN</param>
        /// <param name="author">Given author</param>
        /// <param name="title">Given title</param>
        /// <param name="publisher">Given publisher</param>
        /// <param name="yearOfPublication">Given year of publication</param>
        /// <param name="numberOfPages">Given number of pages</param>
        /// <param name="price">Given price</param>
        public Book(string isbn, string author, string title, string publisher, int yearOfPublication, int numberOfPages, decimal price)
        {
            this.ISBN = isbn;
            this.Author = author;
            this.Title = title;
            this.Publisher = publisher;
            this.YearOfPublication = yearOfPublication;
            this.NumberOfPages = numberOfPages;
            this.Price = price;
        }

        #endregion

        #region Properties

        /// <summary>
        /// ISBN of the book
        /// </summary>
        public string ISBN
        {
            get
            {
                return this._isbn;
            }

            set
            {
                if (!Validator.IsIsbnValid(value))
                {
                    throw new ArgumentException("Invalid ISBN value");
                }

                this._isbn = value;
            }
        }

        /// <summary>
        /// Author of the book
        /// </summary>
        public string Author
        {
            get
            {
                return this._author;
            }

            set
            {
                if (!Validator.IsAuthorValid(value))
                {
                    throw new ArgumentException("Invalid author value");
                }

                this._author = value;
            }
        }

        /// <summary>
        /// Title of the book
        /// </summary>
        public string Title
        {
            get
            {
                return this._title;
            }

            set
            {
                if (!Validator.IsTitleValid(value))
                {
                    throw new ArgumentException("Invalid title value");
                }

                this._title = value;
            }
        }

        /// <summary>
        /// Publisher of the book
        /// </summary>
        public string Publisher
        {
            get
            {
                return this._publisher;
            }

            set
            {
                if (!Validator.IsPublisherValid(value))
                {
                    throw new ArgumentException("Invalid publisher value");
                }

                this._publisher = value;
            }
        }

        /// <summary>
        /// Year of publication of the book
        /// </summary>
        public int YearOfPublication
        {
            get
            {
                return this._yearOfPublication;
            }

            set
            {
                if (!Validator.IsYearValid(value))
                {
                    throw new ArgumentException("Invalid year of publication value");
                }

                this._yearOfPublication = value;
            }
        }

        /// <summary>
        /// Number of pages of the book
        /// </summary>
        public int NumberOfPages
        {
            get
            {
                return this._numberOfPages;
            }

            set
            {
                if (!Validator.IsNumberOfPagesValid(value))
                {
                    throw new ArgumentException("Invalid number of pages value");
                }

                this._numberOfPages = value;
            }
        }

        /// <summary>
        /// Price of the book
        /// </summary>
        public decimal Price
        {
            get
            {
                return this._price;
            }

            set
            {
                if (!Validator.IsPriceValid(value))
                {
                    throw new ArgumentException("Invalid price value");
                }

                this._price = value;
            }
        }

        #endregion

        #region Override System.Object Methods

        /// <summary>
        /// Converts a book to its string representation
        /// </summary>
        /// <returns>String that represents book</returns>
        public override string ToString()
        {
            CultureInfo ci = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = ci;

            return $"ISBN: {this.ISBN}\n" +
                   $"Author: {this.Author}\n" +
                   $"Title: {this.Title}\n" +
                   $"Publisher: {this.Publisher}\n" +
                   $"Year of publication: {this.YearOfPublication}\n" +
                   $"Number of pages: {this.NumberOfPages}\n" +
                   $"Price: {this.Price:C2}";
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current book
        /// </summary>
        /// <param name="obj">The object to compare with the current book</param>
        /// <returns>True, if the specified object is equal to the current book</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }

            Book book = (Book)obj;

            return this.ISBN.Replace("-", string.Empty).Replace(" ", string.Empty) == book.ISBN.Replace("-", string.Empty).Replace(" ", string.Empty);
        }

        /// <summary>
        /// Gets a hash code for the current book
        /// </summary>
        /// <returns>A hash code for the current book</returns>
        public override int GetHashCode()
        {
            return this.ISBN.GetHashCode();
        }

        #endregion

        #region Overload Equality Operators

        /// <summary>
        /// Checks if two books are equal
        /// </summary>
        /// <param name="obj1">First book</param>
        /// <param name="obj2">Second book</param>
        /// <returns>True if books are equal</returns>
        public static bool operator ==(Book obj1, Book obj2)
        {
            return obj1.Equals(obj2);
        }

        /// <summary>
        /// Checks if two books are not equal
        /// </summary>
        /// <param name="obj1">First book</param>
        /// <param name="obj2">Second book</param>
        /// <returns>True if books are not equal</returns>
        public static bool operator !=(Book obj1, Book obj2)
        {
            return !obj1.Equals(obj2);
        }

        #endregion

        #region Implement IComparable Interface

        /// <summary>
        /// Compares the current book with another object
        /// </summary>
        /// <param name="obj">An object to compare with this book</param>
        /// <returns>A value that indicates the relative order of the objects being compared</returns>
        public int CompareTo(object obj)
        {
            Book book = obj as Book;

            if (book != null)
            {
                return this.Title.CompareTo(book.Title);
            }
            else
            {
                throw new ArgumentException("Impossible to compare two objects");
            }
        }

        #endregion

        #region Additional Methods

        /// <summary>
        /// Converts a book to its another string representation
        /// </summary>
        /// <returns>Another string that represents book</returns>
        public string AdditionalToString()
        {
            return string.Empty;
        }

        #endregion
    }
}
