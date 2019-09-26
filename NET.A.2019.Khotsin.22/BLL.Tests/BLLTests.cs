using System;
using System.Collections.Generic;
using System.Linq;
using BLL;
using BLL.Interface;
using DAL.Interface;
using Moq;
using NUnit.Framework;

namespace Tests
{
    public class BLLTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetAllAccountsTest()
        {
            // Arrange
            var data = new[]
            {
                new BankAccountDTO(3, "Jonathan", "Swift", 50.0m, 25, AccountType.Silver.ToString()),
                new BankAccountDTO(5, "James", "Joyce", 100.0m, 30, AccountType.Base.ToString())
            };

            var mock = new Mock<IRepository>();
            mock.Setup(a => a.GetAll()).Returns(data);

            // Act
            var actual = new AccountService(mock.Object).GetAllAccounts().Count();
            var expected = data.Count();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OpenAccountTest()
        {
            // Arrange
            var data = new List<BankAccountDTO>();

            var account = new BankAccountDTO(1, "Harry", "Potter", 0.0m, 0, (AccountType.Silver).ToString());

            var mockRepository = new Mock<IRepository>();
            var mockNumberGenerator = new Mock<IAccountNumberCreateService>();

            mockRepository.Setup(a => a.AddAccount(It.IsAny<BankAccountDTO>())).Callback(() => data.Add(account));
            mockNumberGenerator.Setup(a => a.GenerateNumber(It.IsAny<int>())).Returns(1);

            // Act
            var service = new AccountService(mockRepository.Object);
            service.OpenAccount(account.FirstName, account.LastName, AccountType.Silver, mockNumberGenerator.Object);

            var actual = data.Count;
            var expected = 1;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CloseAccountTest()
        {
            // Arrange
            var data = new List<BankAccountDTO>();

            var accountSwift = new BankAccountDTO(3, "Jonathan", "Swift", 50.0m, 25, (AccountType.Silver).ToString());

            data.Add(accountSwift);

            var mock = new Mock<IRepository>();
            mock.Setup(a => a.RemoveAccount(It.IsAny<BankAccountDTO>())).Callback(() => data.Remove(accountSwift));

            // Act
            var service = new AccountService(mock.Object);
            service.CloseAcount(BankAccountMapper.DTOToBancAcc(accountSwift));

            var actual = data.Count;
            var expected = 0;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DepositAccountTest()
        {
            // Arrange
            var data = new List<BankAccountDTO>();
            
            var account = new BankAccountDTO(6, "Harry", "Potter", 50.0m, 25, (AccountType.Silver).ToString());
            var expected = account.Balance;

            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(a => a.UpdateAccount(It.IsAny<BankAccountDTO>())).Callback(() => account.Balance += 10.0m);

            // Act
            var service = new AccountService(mockRepository.Object);
            service.DepositAccount(BankAccountMapper.DTOToBancAcc(account), 10.0m);

            expected += 10.0m;
            var actual = account.Balance;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void WithdrawAccountTest()
        {
            // Arrange
            var data = new List<BankAccountDTO>();
            
            var account = new BankAccountDTO(6, "Harry", "Potter", 50.0m, 25, (AccountType.Silver).ToString());
            var expected = account.Balance;

            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(a => a.UpdateAccount(It.IsAny<BankAccountDTO>())).Callback(() => account.Balance -= 10.0m);

            // Act
            var service = new AccountService(mockRepository.Object);
            service.WithdrawAccount(BankAccountMapper.DTOToBancAcc(account), 10.0m);

            expected -= 10.0m;
            var actual = account.Balance;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetAccountByIdTest()
        {
            // Arrange
            var data = new[]
            {
                new BankAccountDTO(3, "Jonathan", "Swift", 50.0m, 25, AccountType.Silver.ToString()),
                new BankAccountDTO(5, "James", "Joyce", 100.0m, 30, AccountType.Base.ToString())
            };

            var mock = new Mock<IRepository>();
            mock.Setup(a => a.GetAll()).Returns(data);

            // Act
            var service = new AccountService(mock.Object);
            var acc = service.GetAccountById(3);
            var result = BankAccountMapper.BankAccToDTO(acc);

            string expectedAccountType = data[0].AccountType;
            string actualAccountType = result.AccountType;

            if (expectedAccountType.Substring(0, 3) != "BLL")
            {
                expectedAccountType = "BLL.Interface." + expectedAccountType + "Account";
            }

            if (actualAccountType.Substring(0, 3) != "BLL")
            {
                actualAccountType = "BLL.Interface." + actualAccountType + "Account";
            }

            // Assert
            Assert.AreEqual(data[0].Id, result.Id);
            Assert.AreEqual(data[0].FirstName, result.FirstName);
            Assert.AreEqual(data[0].LastName, result.LastName);
            Assert.AreEqual(data[0].Balance, result.Balance);
            Assert.AreEqual(expectedAccountType, actualAccountType);
            Assert.AreEqual(data[0].BonusPoints, result.BonusPoints);
        }
    }
}