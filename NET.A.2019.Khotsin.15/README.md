Develop a type system to work with a bank account. The status of the account is determined by its id, information about the account owner (first name, last name), the balnce on the account and some bonus points. Bonus points increase/decrease each time you deposit/withdraw. Bonus points depend on the balance "cost" and the deposit "cost". Balance "cost" and the deposit "cost" are integers and depend on the account type (Base, Gold, Platinum). Implement the following features: deposit into the account, withdraw from the account, create a new account, close an account. You can use the fake implementation of the repository as a wrapper class for the List <Account> collection to store information about accounts. Develop console application. Use Ninject-framework as dependency resolver. Implement tests for testing BLL-layer (use NUnit and Moq frameworks).
- [Data access layer interface project](DAL.Interface)
- [Data access layer fake repository project](DAL.Fake)
- [Data access layer repository project](DAL)
- [Business logic layer interface project](BLL.Interface)
- [Business logic layer project](BLL)
- [Dependency resolver project](DependencyResolver)
- [Business logic layer tests project](BLL.Tests)
- [Console UI project](ConsoleUI)
