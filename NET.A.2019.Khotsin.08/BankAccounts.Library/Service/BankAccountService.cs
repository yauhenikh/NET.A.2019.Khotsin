namespace BankAccounts.Library
{
    /// <summary>
    /// Represents bank accounts service
    /// </summary>
    public class BankAccountService
    {
        private readonly IStorage _storage;

        /// <summary>
        /// Parametrized constructor
        /// </summary>
        /// <param name="storage">Storage to contain bank accounts</param>
        public BankAccountService(IStorage storage)
        {
            this._storage = storage;
        }

        /// <summary>
        /// Opens new bank account
        /// </summary>
        /// <param name="account">Bank account to open</param>
        public void OpenAccount(BankAccount account)
        {
            this._storage.AddAccount(account);
        }

        /// <summary>
        /// Closes bank account
        /// </summary>
        /// <param name="account">Bank account to close</param>
        public void CloseAccount(BankAccount account)
        {
            this._storage.RemoveAccount(account);
        }

        /// <summary>
        /// Deposits into a bank account
        /// </summary>
        /// <param name="account">Bank account to deposit</param>
        /// <param name="deposit">Given deposit amount</param>
        public void Deposit(BankAccount account, decimal deposit)
        {
            this._storage.DepositIntoAccount(account, deposit);
        }

        /// <summary>
        /// Withdraws from a bank account
        /// </summary>
        /// <param name="account">Bank account to withdraw</param>
        /// <param name="withdrawal">Given withdrawal amount</param>
        public void Withdraw(BankAccount account, decimal withdrawal)
        {
            this._storage.WithdrawFromAccount(account, withdrawal);
        }

        /// <summary>
        /// Shows all bank accounts in the storage
        /// </summary>
        public void ShowAccounts()
        {
            this._storage.ShowAll();
        }
    }
}
