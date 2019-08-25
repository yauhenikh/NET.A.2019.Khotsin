using System.IO;

namespace BookListServiceLibrary
{
    /// <summary>
    /// Represents binary file storage
    /// </summary>
    public class BinaryFileStorage : AbstractStorage
    {
        private readonly string _filePath;

        /// <summary>
        /// Parametrized constructor
        /// </summary>
        /// <param name="filePath">Path to binary file</param>
        public BinaryFileStorage(string filePath)
        {
            this._filePath = filePath;
            this.Load(_filePath);
        }

        /// <summary>
        /// Load books from binary file
        /// </summary>
        /// <param name="filePath">Path to binary file</param>
        private void Load(string filePath)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.OpenOrCreate)))
            {
                while (reader.PeekChar() > -1)
                {
                    string isbn = reader.ReadString();
                    string author = reader.ReadString();
                    string title = reader.ReadString();
                    string publisher = reader.ReadString();
                    int yearOfPublication = reader.ReadInt32();
                    int numberOfPages = reader.ReadInt32();
                    decimal price = reader.ReadDecimal();

                    base.AddBook(new Book(isbn, author, title, publisher, yearOfPublication, numberOfPages, price));
                }
            }
        }

        /// <summary>
        /// Adds new book to binary file
        /// </summary>
        /// <param name="book">Book to add</param>
        public override void AddBook(Book book)
        {
            base.AddBook(book);
            using (BinaryWriter writer = new BinaryWriter(File.Open(_filePath, FileMode.OpenOrCreate)))
            {
                writer.Seek(0, SeekOrigin.End);

                writer.Write(book.ISBN);
                writer.Write(book.Author);
                writer.Write(book.Title);
                writer.Write(book.Publisher);
                writer.Write(book.YearOfPublication);
                writer.Write(book.NumberOfPages);
                writer.Write(book.Price);
            }
        }

        /// <summary>
        /// Removes a book from binary file
        /// </summary>
        /// <param name="book">Book to remove</param>
        public override void RemoveBook(Book book)
        {
            base.RemoveBook(book);
            using (BinaryWriter writer = new BinaryWriter(File.Open(_filePath, FileMode.Truncate)))
            {
                writer.Seek(0, SeekOrigin.End);

                foreach (Book bookInList in _books)
                {
                    writer.Write(bookInList.ISBN);
                    writer.Write(bookInList.Author);
                    writer.Write(bookInList.Title);
                    writer.Write(bookInList.Publisher);
                    writer.Write(bookInList.YearOfPublication);
                    writer.Write(bookInList.NumberOfPages);
                    writer.Write(bookInList.Price);
                }
            }
        }

        /// <summary>
        /// Sorts books by tag
        /// </summary>
        /// <param name="tag">Tag for sorting</param>
        public override void SortBooksByTag(Tags tag)
        {
            base.SortBooksByTag(tag);
            using (BinaryWriter writer = new BinaryWriter(File.Open(_filePath, FileMode.Truncate)))
            {
                writer.Seek(0, SeekOrigin.End);

                foreach (Book book in _books)
                {
                    writer.Write(book.ISBN);
                    writer.Write(book.Author);
                    writer.Write(book.Title);
                    writer.Write(book.Publisher);
                    writer.Write(book.YearOfPublication);
                    writer.Write(book.NumberOfPages);
                    writer.Write(book.Price);
                }
            }
        }
    }
}
