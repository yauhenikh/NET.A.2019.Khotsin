namespace BookTasks
{
    /// <summary>
    /// Abstract decorator
    /// </summary>
    public abstract class BookToStringDecorator : IBook
    {
        #region Fields

        protected string _bookParameter;
        private IBook _book;

        #endregion

        #region Constructor

        /// <summary>
        /// Parametrized constructor
        /// </summary>
        /// <param name="book">Book to create decorator</param>
        public BookToStringDecorator(IBook book)
        {
            _book = book;
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
                return _book.ISBN;
            }
        }

        /// <summary>
        /// Author of the book
        /// </summary>
        public string Author
        {
            get
            {
                return _book.Author;
            }
        }

        /// <summary>
        /// Title of the book
        /// </summary>
        public string Title
        {
            get
            {
                return _book.Title;
            }
        }

        /// <summary>
        /// Publisher of the book
        /// </summary>
        public string Publisher
        {
            get
            {
                return _book.Publisher;
            }
        }

        /// <summary>
        /// Number of pages of the book
        /// </summary>
        public int NumberOfPages
        {
            get
            {
                return _book.NumberOfPages;
            }
        }

        /// <summary>
        /// Year of publication of the book
        /// </summary>
        public int YearOfPublication
        {
            get
            {
                return _book.YearOfPublication;
            }
        }

        /// <summary>
        /// Price of the book
        /// </summary>
        public decimal Price
        {
            get
            {
                return _book.Price;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Converts a book to its another string representation
        /// </summary>
        /// <returns>Another string that represents book</returns>
        public string AdditionalToString()
        {
            string result = _bookParameter + _book.AdditionalToString();
            if (result.Length >= 2 && result.Substring(result.Length - 2) == ", ")
            {
                result = result.Substring(0, result.Length - 2);
            }

            return result;
        }

        #endregion
    }
}
