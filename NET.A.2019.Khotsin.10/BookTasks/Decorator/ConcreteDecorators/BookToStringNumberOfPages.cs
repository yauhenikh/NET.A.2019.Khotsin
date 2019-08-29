namespace BookTasks
{
    /// <summary>
    /// Concrete BookToStringNumberOfPages decorator
    /// </summary>
    public class BookToStringNumberOfPages : BookToStringDecorator
    {
        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="book">Book to get number of pages parameter</param>
        public BookToStringNumberOfPages(IBook book) : base(book)
        {
            this._bookParameter = "P. " + book.NumberOfPages + ", ";
        }
    }
}
