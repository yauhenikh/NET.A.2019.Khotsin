namespace BookTasks
{
    /// <summary>
    /// Holds the additional string representation functionality
    /// </summary>
    public interface IBook
    {
        /// <summary>
        /// ISBN of the book
        /// </summary>
        string ISBN { get; }

        /// <summary>
        /// Author of the book
        /// </summary>
        string Author { get; }

        /// <summary>
        /// Title of the book
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Publisher of the book
        /// </summary>
        string Publisher { get; }

        /// <summary>
        /// Number of pages of the book
        /// </summary>
        int NumberOfPages { get; }

        /// <summary>
        /// Year of publication of the book
        /// </summary>
        int YearOfPublication { get; }

        /// <summary>
        /// Price of the book
        /// </summary>
        decimal Price { get; }

        /// <summary>
        /// Converts a book to its another string representation
        /// </summary>
        /// <returns>Another string that represents book</returns>
        string AdditionalToString();
    }
}
