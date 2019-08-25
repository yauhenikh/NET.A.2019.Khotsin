using System.Text.RegularExpressions;

namespace BookListServiceLibrary
{
    /// <summary>
    /// Class for validation
    /// </summary>
    internal static class Validator
    {
        /// <summary>
        /// Determines if isbn value is valid
        /// </summary>
        /// <param name="isbn">Given isbn</param>
        /// <returns>True, if isbn value is valid</returns>
        internal static bool IsIsbnValid(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn))
            {
                return false;
            }

            bool isValid = false;

            isbn = isbn.Replace("-", "").Replace(" ", "");

            if (isbn.Length == 10)
            {
                if (Regex.IsMatch(isbn, @"^\d{9}[\dX]$"))
                {
                    int sum = (isbn[0] - '0') * 1 + (isbn[1] - '0') * 2 + (isbn[2] - '0') * 3 +
                              (isbn[3] - '0') * 4 + (isbn[4] - '0') * 5 + (isbn[5] - '0') * 6 +
                              (isbn[6] - '0') * 7 + (isbn[7] - '0') * 8 + (isbn[8] - '0') * 9;
                    sum += (isbn[9] == 'X' ? 10 : (isbn[9] - '0')) * 10;

                    isValid = sum % 11 == 0;
                }
            }
            else if (isbn.Length == 13)
            {
                if (Regex.IsMatch(isbn, @"^\d{13}$"))
                {
                    int sum = (isbn[0] - '0') + (isbn[1] - '0') * 3 + (isbn[2] - '0') + (isbn[3] - '0') * 3 +
                              (isbn[4] - '0') + (isbn[5] - '0') * 3 + (isbn[6] - '0') + (isbn[7] - '0') * 3 +
                              (isbn[8] - '0') + (isbn[9] - '0') * 3 + (isbn[10] - '0') + (isbn[11] - '0') * 3 +
                              (isbn[12] - '0');

                    isValid = sum % 10 == 0;
                }
            }

            return isValid;
        }

        /// <summary>
        /// Determines if author is valid
        /// </summary>
        /// <param name="author">Given author</param>
        /// <returns>True, if author is valid</returns>
        internal static bool IsAuthorValid(string author)
        {
            if (author == null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Determines if title is valid
        /// </summary>
        /// <param name="title">Given title</param>
        /// <returns>True, if title is valid</returns>
        internal static bool IsTitleValid(string title)
        {
            if (title == null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Determines if publisher is valid
        /// </summary>
        /// <param name="publisher">Given publisher</param>
        /// <returns>True, if publisher is valid</returns>
        internal static bool IsPublisherValid(string publisher)
        {
            if (publisher == null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Determines if year of publication is valid
        /// </summary>
        /// <param name="year">Given year of publication</param>
        /// <returns>True, if year of publication is valid</returns>
        internal static bool IsYearValid(int year)
        {
            if (year < 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Determines if number of pages is valid
        /// </summary>
        /// <param name="numberOfPages">Given number of pages</param>
        /// <returns>True, if number of pages is valid</returns>
        internal static bool IsNumberOfPagesValid(int numberOfPages)
        {
            if (numberOfPages <= 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Determines if price is valid
        /// </summary>
        /// <param name="price">Given price</param>
        /// <returns>True, if price is valid</returns>
        internal static bool IsPriceValid(decimal price)
        {
            if (price < 0)
            {
                return false;
            }

            return true;
        }
    }
}
