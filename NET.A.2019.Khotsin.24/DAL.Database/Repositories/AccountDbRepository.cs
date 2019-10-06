using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Database.Context;
using DAL.Database.Models;
using DAL.Interface;

namespace DAL.Database.Repositories
{
    /// <summary>
    /// Represents database repository for bank accounts
    /// </summary>
    public class AccountDbRepository : IRepository
    {
        private AccountContext context;

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="context">Given data context used to interact with the database</param>
        public AccountDbRepository(AccountContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Adds new bank account to the database
        /// </summary>
        /// <param name="account">Bank account DTO object to add</param>
        public void AddAccount(BankAccountDTO account)
        {
            var accountOwners = context.AccountOwners.ToList();
            var accountOwner = accountOwners.Find(owner => owner.FirstName == account.FirstName && owner.LastName == account.LastName);

            if (accountOwner == null)
            {
                accountOwner = new AccountOwner
                {
                    FirstName = account.FirstName,
                    LastName = account.LastName
                };

                context.AccountOwners.Add(accountOwner);
                context.SaveChanges();
            }

            string accountType = account.AccountType;
            if (accountType.Substring(0, 3) != "BLL")
            {
                accountType = "BLL.Interface." + accountType + "Account";
            }

            accountType = accountType.Substring(14);
            accountType = accountType.Remove(accountType.Length - 7);

            var accountTypes = context.AccountTypes.ToList();
            var accountTypeDB = accountTypes.Find(accType => accType.Name == accountType);

            Account newAccount = new Account
            {
                Id = account.Id,
                Balance = account.Balance,
                BonusPoints = account.BonusPoints,
                AccountOwner = accountOwner,
                AccountType = accountTypeDB
            };

            context.Accounts.Add(newAccount);
            context.SaveChanges();
        }

        /// <summary>
        /// Gets bank account by its id
        /// </summary>
        /// <param name="id">Given id</param>
        /// <returns>Bank account DTO object with given id</returns>
        public BankAccountDTO GetAccountById(int id)
        {
            var foundAccount = context.Accounts.Find(id);

            if (foundAccount == null)
            {
                return null;
            }

            return new BankAccountDTO(
                foundAccount.Id,
                foundAccount.AccountOwner.FirstName,
                foundAccount.AccountOwner.LastName,
                foundAccount.Balance,
                foundAccount.BonusPoints,
                foundAccount.AccountType.Name);
        }

        /// <summary>
        /// Gets all bank accounts
        /// </summary>
        /// <returns>Collection of bank account DTO objects</returns>
        public IEnumerable<BankAccountDTO> GetAll()
        {
            var accounts = context.Accounts;

            foreach (var acc in accounts)
            {
                yield return new BankAccountDTO(acc.Id, acc.AccountOwner.FirstName, acc.AccountOwner.LastName, acc.Balance, acc.BonusPoints, acc.AccountType.Name);
            }
        }

        /// <summary>
        /// Removes bank account from database
        /// </summary>
        /// <param name="account">Bank account DTO object to remove</param>
        public void RemoveAccount(BankAccountDTO account)
        {
            var foundAccount = context.Accounts.Find(account.Id);

            if (foundAccount == null)
            {
                throw new ArgumentException("The database doesn't contain given account");
            }

            context.Accounts.Remove(foundAccount);
            context.Entry(foundAccount).State = EntityState.Deleted;
            context.SaveChanges();
        }

        /// <summary>
        /// Updates bank account in database
        /// </summary>
        /// <param name="account">Bank account DTO object to update</param>
        public void UpdateAccount(BankAccountDTO account)
        {
            var foundAccount = context.Accounts.Find(account.Id);

            if (foundAccount == null)
            {
                throw new ArgumentException("The database doesn't contain given account");
            }

            foundAccount.Balance = account.Balance;
            foundAccount.BonusPoints = account.BonusPoints;

            context.Entry(foundAccount).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
