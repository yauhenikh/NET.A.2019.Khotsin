namespace BankAccounts.Library
{
    /// <summary>
    /// Interface for storage classes
    /// </summary>
    public interface IStorage
    {
        /// <summary>
        /// Adds new bank account to the storage
        /// </summary>
        /// <param name="account">Bank account to add</param>
        void AddAccount(BankAccount account);

        /// <summary>
        /// Removes a bank account from the storage
        /// </summary>
        /// <param name="account">Bank account to remove</param>
        void RemoveAccount(BankAccount account);

        /// <summary>
        /// Deposit into a bank account and save changes
        /// </summary>
        /// <param name="account">Bank account to deposit</param>
        /// <param name="deposit">Given deposit amount</param>
        void DepositIntoAccount(BankAccount account, decimal deposit);

        /// <summary>
        /// Withdraw from a bank account and save changes
        /// </summary>
        /// <param name="account">Bank account to withdraw</param>
        /// <param name="withdrawal">Given withdrawal amount</param>
        void WithdrawFromAccount(BankAccount account, decimal withdrawal);

        /// <summary>
        /// Show all books in the list
        /// </summary>
        void ShowAll();
    }
}