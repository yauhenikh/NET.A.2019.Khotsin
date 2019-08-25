using System.Collections.Generic;

namespace BookListServiceLibrary
{
    /// <summary>
    /// Class to compare books
    /// </summary>
    internal class BookComparer : IComparer<Book>
    {
        private readonly Tags _tag;

        /// <summary>
        /// Parametrized constructor
        /// </summary>
        /// <param name="tag"></param>
        public BookComparer(Tags tag)
        {
            _tag = tag;
        }

        /// <summary>
        /// Compares two books
        /// </summary>
        /// <param name="x">First book</param>
        /// <param name="y">Second book</param>
        /// <returns>An integer that indicates the relative values of the x and y parameters</returns>
        public int Compare(Book x, Book y)
        {
            var xValue = GetPropValue(x, _tag.ToString());
            var yValue = GetPropValue(y, _tag.ToString());

            if (xValue is string)
            {
                return xValue.ToString().CompareTo(yValue.ToString());
            }
            else
            {
                int xIntValue;
                int yIntValue;

                decimal xDecimalValue;
                decimal yDecimalValue;

                if (xValue is int)
                {
                    xIntValue = (int)xValue;
                    yIntValue = (int)yValue;

                    return xIntValue.CompareTo(yIntValue);
                }
                else
                {
                    xDecimalValue = (decimal)xValue;
                    yDecimalValue = (decimal)yValue;

                    return xDecimalValue.CompareTo(yDecimalValue);
                }
            }
        }

        /// <summary>
        /// Gets property value by its name
        /// </summary>
        /// <param name="book">Book to get property value</param>
        /// <param name="propName">Name of the property</param>
        /// <returns>Value of the property</returns>
        public static object GetPropValue(object book, string propName)
        {
            return book.GetType().GetProperty(propName).GetValue(book, null);
        }
    }
}
