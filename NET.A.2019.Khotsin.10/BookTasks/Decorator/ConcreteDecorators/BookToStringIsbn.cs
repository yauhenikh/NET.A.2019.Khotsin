namespace BookTasks
{
    public class BookToStringIsbn : BookToStringDecorator
    {
        public BookToStringIsbn(IBook book) : base(book)
        {
            string prefix = string.Empty;

            if (book.ISBN.Replace("-", string.Empty).Replace(" ", string.Empty).Length == 13)
            {
                prefix = "ISBN 13: ";
            } 
            else
            {
                prefix = "ISBN 10: ";
            }

            this._bookParameter = prefix + book.ISBN + ", ";
        }
    }
}
