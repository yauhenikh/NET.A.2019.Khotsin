using System.Collections.Generic;
using BookListServiceLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookTasks.Tests
{
    [TestClass]
    public class BookTasksTests
    {
        [DataTestMethod]
        [DynamicData(nameof(GetData_For_AdditionalToStringTest), DynamicDataSourceType.Method)]
        public void AdditionalToStringTest(IBook book, string expected)
        {
            // Arrange
            // Act
            string result = book.AdditionalToString();

            // Assert
            Assert.AreEqual(expected, result);
        }

        public static IEnumerable<object[]> GetData_For_AdditionalToStringTest()
        {
            Book clrViaCsharp = new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 59.99m);

            IBook clrViaCsharp_Author_Title = new BookToStringAuthor(new BookToStringTitle(clrViaCsharp));
            string clrViaCsharp_Author_Title_ToString = "Jeffrey Richter, CLR via C#";

            IBook clrViaCsharp_Author_Title_Publisher_Year = new BookToStringAuthor(new BookToStringTitle(new BookToStringPublisher(
                new BookToStringYearOfPublication(clrViaCsharp))));
            string clrViaCsharp_Author_Title_Publisher_Year_ToString = "Jeffrey Richter, CLR via C#, \"Microsoft Press\", 2012";

            IBook clrViaCsharp_ISBN_Author_Title_Publisher_Year_Pages = new BookToStringIsbn(new BookToStringAuthor(new BookToStringTitle(
                new BookToStringPublisher(new BookToStringYearOfPublication(new BookToStringNumberOfPages(clrViaCsharp))))));
            string clrViaCsharp_ISBN_Author_Title_Publisher_Year_Pages_ToString =
                "ISBN 13: 978-0-7356-6745-7, Jeffrey Richter, CLR via C#, \"Microsoft Press\", 2012, P. 826";

            IBook clrViaCsharp_ISBN_Author_Title_Publisher_Year_Pages_Price = new BookToStringIsbn(new BookToStringAuthor(new BookToStringTitle(
                new BookToStringPublisher(new BookToStringYearOfPublication(new BookToStringNumberOfPages(new BookToStringPrice(clrViaCsharp)))))));
            string clrViaCsharp_ISBN_Author_Title_Publisher_Year_Pages_Price_ToString =
                "ISBN 13: 978-0-7356-6745-7, Jeffrey Richter, CLR via C#, \"Microsoft Press\", 2012, P. 826, $59.99";

            Book twelveChairs = new Book("978 - 0810114845", "Ilya Ilf, Evgeny Petrov", "The Twelve Chairs",
                                         "Northwestern University Press", 1997, 395, 41.93m);

            IBook twelveChairs_Year_Title = new BookToStringYearOfPublication(new BookToStringAuthor(twelveChairs));
            string twelveChairs_Year_Title_ToString = "1997, Ilya Ilf, Evgeny Petrov";

            IBook twelveChairs_ISBN_Publisher = new BookToStringIsbn(new BookToStringPublisher(twelveChairs));
            string twelveChairs_ISBN_Publisher_ToString = "ISBN 13: 978 - 0810114845, \"Northwestern University Press\"";

            yield return new object[] { clrViaCsharp_Author_Title, clrViaCsharp_Author_Title_ToString };
            yield return new object[] { clrViaCsharp_Author_Title_Publisher_Year, clrViaCsharp_Author_Title_Publisher_Year_ToString };
            yield return new object[] { clrViaCsharp_ISBN_Author_Title_Publisher_Year_Pages, clrViaCsharp_ISBN_Author_Title_Publisher_Year_Pages_ToString };
            yield return new object[] { clrViaCsharp_ISBN_Author_Title_Publisher_Year_Pages_Price, clrViaCsharp_ISBN_Author_Title_Publisher_Year_Pages_Price_ToString };
            yield return new object[] { twelveChairs_Year_Title, twelveChairs_Year_Title_ToString };
            yield return new object[] { twelveChairs_ISBN_Publisher, twelveChairs_ISBN_Publisher_ToString };
        }

        [DataTestMethod]
        [DynamicData(nameof(GetData_For_ExtensionToStringTest), DynamicDataSourceType.Method)]
        public void ExtensionToStringTest(Book book, string cultureName, string expected)
        {
            // Arrange
            // Act
            string result = book.ToString(cultureName);

            // Assert
            Assert.AreEqual(expected, result);
        }

        public static IEnumerable<object[]> GetData_For_ExtensionToStringTest()
        {
            Book danceWithDragons = new Book("978-0553582017", "George R. R. Martin", "A Dance with Dragons",
                                             "Bantam", 2013, 1152, 7.59m);
            string cultureName_en_US = "en-US";
            string cultureName_de_DE = "de-DE";
            string danceWithDragons_en_US_ToString = "ISBN: 978-0553582017\nAuthor: George R. R. Martin\nTitle: A Dance with Dragons\n" +
                "Publisher: Bantam\nYear of publication: 2013\nNumber of pages: 1152\nPrice: $7.59";
            string danceWithDragons_de_DE_ToString = "ISBN: 978-0553582017\nAuthor: George R. R. Martin\nTitle: A Dance with Dragons\n" +
                "Publisher: Bantam\nYear of publication: 2013\nNumber of pages: 1152\nPrice: 7,59 €";

            Book gameOfThrones = new Book("978 - 0553593716", "George R. R. Martin", "A Game of Thrones",
                                          "Bantam", 2011, 864, 999.49m);
            string cultureName_ru_RU = "ru-RU";
            string cultureName_ja_JP = "ja-JP";
            string gameOfThrones_ru_RU_ToString = "ISBN: 978 - 0553593716\nAuthor: George R. R. Martin\nTitle: A Game of Thrones\n" +
                "Publisher: Bantam\nYear of publication: 2011\nNumber of pages: 864\nPrice: 999,49 ₽";
            string gameOfThrones_ja_JP_ToString = "ISBN: 978 - 0553593716\nAuthor: George R. R. Martin\nTitle: A Game of Thrones\n" +
                "Publisher: Bantam\nYear of publication: 2011\nNumber of pages: 864\nPrice: ¥999.49";

            yield return new object[] { danceWithDragons, cultureName_en_US, danceWithDragons_en_US_ToString };
            yield return new object[] { danceWithDragons, cultureName_de_DE, danceWithDragons_de_DE_ToString };
            yield return new object[] { gameOfThrones, cultureName_ru_RU, gameOfThrones_ru_RU_ToString };
            yield return new object[] { gameOfThrones, cultureName_ja_JP, gameOfThrones_ja_JP_ToString };
        }
    }
}
