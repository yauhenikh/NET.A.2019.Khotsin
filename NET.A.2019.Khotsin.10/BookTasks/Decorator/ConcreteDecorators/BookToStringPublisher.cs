namespace BookTasks
{
    /// <summary>
    /// Concrete BookToStringPublisher decorator
    /// </summary>
    public class BookToStringPublisher : BookToStringDecorator
    {
        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="book">Book to get publisher parameter</param>
        public BookToStringPublisher(IBook book) : base(book)
        {
            this._bookParameter = "\"" + book.Publisher + "\", ";
        }
    }
}
