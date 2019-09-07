using System.Collections.Generic;
using DAL.Interface;

namespace DAL.Fake
{
    /// <summary>
    /// Represents fake repository for bank accounts
    /// </summary>
    public class FakeRepository : IRepository
    {
        private readonly List<BankAccountDTO> _accounts;

        /// <summary>
        /// Default constructor
        /// </summary>
        public FakeRepository()
        {
            _accounts = new List<BankAccountDTO>();
        }

        /// <summary>
        /// Adds new bank account to fake repository
        /// </summary>
        /// <param name="account">Bank account DTO object to add</param>
        public void AddAccount(BankAccountDTO account)
        {
            _accounts.Add(account);
        }

        /// <summary>
        /// Updates bank account in fake repository
        /// </summary>
        /// <param name="account">Bank account DTO object to update</param>
        public void UpdateAccount(BankAccountDTO account)
        {
            BankAccountDTO oldAccount = _accounts.Find(acc => acc.Id == account.Id);

            if (oldAccount != null)
            {
                oldAccount.FirstName = account.FirstName;
                oldAccount.LastName = account.LastName;
                oldAccount.Balance = account.Balance;
                oldAccount.BonusPoints = account.BonusPoints;
                oldAccount.AccountType = account.AccountType;
            }
        }

        /// <summary>
        /// Removes bank account from fake repository
        /// </summary>
        /// <param name="account">Bank account DTO object to remove</param>
        public void RemoveAccount(BankAccountDTO account)
        {
            BankAccountDTO accountToRemove = _accounts.Find(acc => acc.Id == account.Id);
            _accounts.Remove(accountToRemove);
        }

        /// <summary>
        /// Gets bank account by its id
        /// </summary>
        /// <param name="id">Given id</param>
        /// <returns>Bank account DTO object with given id</returns>
        public BankAccountDTO GetAccountById(int id)
        {
            return _accounts.Find(acc => acc.Id == id);
        }

        /// <summary>
        /// Gets all bank accounts
        /// </summary>
        /// <returns>Collection of bank account DTO objects</returns>
        public IEnumerable<BankAccountDTO> GetAll()
        {
            foreach (BankAccountDTO account in _accounts)
            {
                yield return account;
            }
        }
    }
}
