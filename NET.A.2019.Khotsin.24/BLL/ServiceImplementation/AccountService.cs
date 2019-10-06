using System;
using System.Collections.Generic;
using BLL.Interface;
using DAL.Interface;

namespace BLL
{
    /// <summary>
    /// Represents service class to work with bank accounts
    /// </summary>
    public class AccountService : IAccountService
    {
        private readonly IRepository _repository;

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="repository">Repository to contain bank accounts</param>
        public AccountService(IRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Number of accounts in repository
        /// </summary>
        public int Count
        {
            get
            {
                return GetCount();
            }
        }

        /// <summary>
        /// Maximum id of accounts in repository
        /// </summary>
        public int Max
        {
            get
            {
                return GetMax();
            }
        }

        /// <summary>
        /// Opens new bank account
        /// </summary>
        /// <param name="firstName">Owner's first name</param>
        /// <param name="lastName">Owner's last name</param>
        /// <param name="accountType">Type of account</param>
        /// <param name="accountNumberCreator">Given account number generator</param>
        public void OpenAccount(string firstName, string lastName, AccountType accountType, IAccountNumberCreateService accountNumberCreator)
        {
            int id = accountNumberCreator.GenerateNumber(Max);
            _repository.AddAccount(new BankAccountDTO(id, firstName, lastName, 0.0m, 0, accountType.ToString()));
        }

        /// <summary>
        /// Closes bank account
        /// </summary>
        /// <param name="account">Bank account to close</param>
        public void CloseAcount(BankAccount account)
        {
            BankAccountDTO accToRemove = BankAccountMapper.BankAccToDTO(account);
            _repository.RemoveAccount(accToRemove);
        }

        /// <summary>
        /// Deposits into a bank account
        /// </summary>
        /// <param name="account">Bank account to deposit</param>
        /// <param name="deposit">Given deposit amount</param>
        public void DepositAccount(BankAccount account, decimal deposit)
        {
            account.Deposit(deposit);
            BankAccountDTO accToUpdate = BankAccountMapper.BankAccToDTO(account);
            _repository.UpdateAccount(accToUpdate);
        }

        /// <summary>
        /// Withdraws from a bank account
        /// </summary>
        /// <param name="account">Bank account to withdraw</param>
        /// <param name="withdrawal">Given withdrawal amount</param>
        public void WithdrawAccount(BankAccount account, decimal withdrawal)
        {
            account.Withdraw(withdrawal);
            BankAccountDTO accToUpdate = BankAccountMapper.BankAccToDTO(account);
            _repository.UpdateAccount(accToUpdate);
        }

        /// <summary>
        /// Gets account by its id
        /// </summary>
        /// <param name="id">Given id</param>
        /// <returns>Bank account with given id</returns>
        public BankAccount GetAccountById(int id)
        {
            var accounts = _repository.GetAll();

            foreach (var acc in accounts)
            {
                if (acc.Id == id)
                {
                    return BankAccountMapper.DTOToBancAcc(acc);
                }
            }

            return null;
        }

        /// <summary>
        /// Getss all bank accounts in the repository
        /// </summary>
        /// <returns>Collection of all bank accounts in the repository</returns>
        public IEnumerable<BankAccount> GetAllAccounts()
        {
            var accounts = _repository.GetAll();

            foreach (var acc in accounts)
            {
                yield return BankAccountMapper.DTOToBancAcc(acc);
            }
        }

        /// <summary>
        /// Gets number of accounts in repository
        /// </summary>
        /// <returns>Number of accounts in repository</returns>
        private int GetCount()
        {
            int count = 0;

            foreach (var acc in GetAllAccounts())
            {
                count++;
            }

            return count;
        }

        /// <summary>
        /// Gets maximum id of accounts in repository
        /// </summary>
        /// <returns>Maximum id of accounts in repository</returns>
        private int GetMax()
        {
            int max = 0;

            foreach (var acc in GetAllAccounts())
            {
                if (acc.Id > max)
                {
                    max = acc.Id;
                }
            }

            return max;
        }
    }
}
