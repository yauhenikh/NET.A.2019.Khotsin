using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BankAccounts.Library
{
    /// <summary>
    /// Represents binary file storage for bank accounts
    /// </summary>
    public class BinaryFileStorage : IStorage
    {
        private readonly List<BankAccount> _accounts;
        private readonly string _filePath;

        /// <summary>
        /// Parametrized constructor
        /// </summary>
        /// <param name="filePath">Path to binary file</param>
        public BinaryFileStorage(string filePath)
        {
            this._accounts = new List<BankAccount>();
            this._filePath = filePath;
            this.Load(_filePath);
        }

        /// <summary>
        /// Load bank accounts from binary file
        /// </summary>
        /// <param name="filePath">Path to binary file</param>
        private void Load(string filePath)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(this._filePath, FileMode.OpenOrCreate))
            {
                if (fs.Length != 0)
                {
                    List<BankAccount> deserializeAccounts = (List<BankAccount>)formatter.Deserialize(fs);

                    foreach (var account in deserializeAccounts)
                    {
                        this._accounts.Add(account);
                    }
                }
            }
        }

        /// <summary>
        /// Adds new bank account to binary file
        /// </summary>
        /// <param name="account">Bank account to add</param>
        public void AddAccount(BankAccount account)
        {
            if (this._accounts.Contains(account))
            {
                throw new ArgumentException("The storage already contains account with the same id");
            }

            this._accounts.Add(account);

            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(this._filePath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, this._accounts);
            }
        }

        /// <summary>
        /// Removes a bank account from binary file
        /// </summary>
        /// <param name="account">Bank account to remove</param>
        public void RemoveAccount(BankAccount account)
        {
            if (!this._accounts.Contains(account))
            {
                throw new ArgumentException("The storage doesn't contain given account");
            }

            this._accounts.Remove(account);

            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(this._filePath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, this._accounts);
            }
        }

        /// <summary>
        /// Deposits into a bank account and save changes
        /// </summary>
        /// <param name="account">Bank account to deposit</param>
        /// <param name="deposit">Given deposit amount</param>
        public void DepositIntoAccount(BankAccount account, decimal deposit)
        {
            if (!this._accounts.Contains(account))
            {
                throw new ArgumentException("The storage doesn't contain given account");
            }

            BankAccount foundAccount = _accounts.Find(a => a == account);
            foundAccount.Deposit(deposit);

            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(this._filePath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, this._accounts);
            }
        }

        /// <summary>
        /// Withdraws from a bank account and save changes
        /// </summary>
        /// <param name="account">Bank account to withdraw</param>
        /// <param name="withdrawal">Given withdrawal amount</param>
        public void WithdrawFromAccount(BankAccount account, decimal withdrawal)
        {
            if (!this._accounts.Contains(account))
            {
                throw new ArgumentException("The storage doesn't contain given account");
            }

            BankAccount foundAccount = _accounts.Find(a => a == account);
            foundAccount.Withdraw(withdrawal);

            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(this._filePath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, this._accounts);
            }
        }

        /// <summary>
        /// Shows all books in the list
        /// </summary>
        public void ShowAll()
        {
            foreach (var account in this._accounts)
            {
                Console.WriteLine(account);
                Console.WriteLine();
            }
        }
    }
}
