namespace BookTasks
{
    /// <summary>
    /// Concrete BookToStringAuthor decorator
    /// </summary>
    public class BookToStringAuthor : BookToStringDecorator
    {
        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="book">Book to get author parameter</param>
        public BookToStringAuthor(IBook book) : base(book)
        {
            this._bookParameter = book.Author + ", ";
        }
    }
}
