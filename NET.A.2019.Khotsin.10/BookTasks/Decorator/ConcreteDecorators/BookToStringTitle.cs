namespace BookTasks
{
    /// <summary>
    /// Concrete BookToStringTitle decorator
    /// </summary>
    public class BookToStringTitle : BookToStringDecorator
    {
        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="book">Book to get title parameter</param>
        public BookToStringTitle(IBook book) : base(book)
        {
            this._bookParameter = book.Title + ", ";
        }
    }
}
