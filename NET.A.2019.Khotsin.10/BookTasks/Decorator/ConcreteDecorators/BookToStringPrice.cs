using System.Globalization;
using System.Threading;

namespace BookTasks
{
    /// <summary>
    /// Concrete BookToStringPrice decorator
    /// </summary>
    public class BookToStringPrice : BookToStringDecorator
    {
        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="book">Book to get price parameter</param>
        public BookToStringPrice(IBook book) : base(book)
        {
            CultureInfo ci = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = ci;
            this._bookParameter = $"{book.Price:C2}, ";
        }
    }
}
