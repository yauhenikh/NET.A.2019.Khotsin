1. Develop the Book class (ISBN, author, title, publisher, year of publication, number of pages, price), override the necessary methods of the Object class. Implement equivalence and order relations (using appropriate interfaces) for class objects. Develop the BookListService class (as a service for working with a collection of books) with AddBook functionality, RemoveBook, FindBookByTag, SortBooksByTag (sort the list of books by a given criterion). Develop console application. Use binary file as storage (use only BinaryWriter, BinaryReader classes).
- [Class library project](BookListService.Library)
- [Console UI project](BookListService.ConsoleUI)
2. Develop a type system to work with a bank account. The status of the account is determined by its id, information about the account owner (first name, last name), the balnce on the account and some bonus points. Bonus points increase/decrease each time you deposit/withdraw. Bonus points depend on the balance “cost” and the deposit “cost”. Balance “cost” and the deposit “cost” are integers and depend on the account type (Base, Gold, Platinum). Implement the following features:
- deposit into the account;
- withdraw from the account;
- create a new account;
- close an account.
Use binary file as storage. Develop console application
