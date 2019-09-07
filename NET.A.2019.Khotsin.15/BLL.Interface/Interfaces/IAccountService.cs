using System.Collections.Generic;

namespace BLL.Interface
{
    /// <summary>
    /// Represents interface for bank account service classes
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// Opens new bank account
        /// </summary>
        /// <param name="firstName">Owner's first name</param>
        /// <param name="lastName">Owner's last name</param>
        /// <param name="accountType">Type of account</param>
        /// <param name="accountNumberCreator">Given account number generator</param>
        void OpenAccount(string firstName, string lastName, AccountType accountType, IAccountNumberCreateService accountNumberCreator);

        /// <summary>
        /// Closes bank account
        /// </summary>
        /// <param name="account">Bank account to close</param>
        void CloseAcount(BankAccount account);

        /// <summary>
        /// Deposits into a bank account
        /// </summary>
        /// <param name="account">Bank account to deposit</param>
        /// <param name="deposit">Given deposit amount</param>
        void DepositAccount(BankAccount account, decimal deposit);

        /// <summary>
        /// Withdraws from a bank account
        /// </summary>
        /// <param name="account">Bank account to withdraw</param>
        /// <param name="withdrawal">Given withdrawal amount</param>
        void WithdrawAccount(BankAccount account, decimal withdrawal);

        /// <summary>
        /// Gets account by its id
        /// </summary>
        /// <param name="id">Given id</param>
        /// <returns>Bank account with given id</returns>
        BankAccount GetAccountById(int id);

        /// <summary>
        /// Getss all bank accounts in the repository
        /// </summary>
        /// <returns>Collection of all bank accounts in the repository</returns>
        IEnumerable<BankAccount> GetAllAccounts();
    }
}
