namespace BookTasks
{
    /// <summary>
    /// Concrete BookToStringYearOfPublication decorator
    /// </summary>
    public class BookToStringYearOfPublication : BookToStringDecorator
    {
        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="book">Book to get year of publication parameter</param>
        public BookToStringYearOfPublication(IBook book) : base(book)
        {
            this._bookParameter = book.YearOfPublication + ", ";
        }
    }
}
