using System;

namespace DAL.Interface
{
    /// <summary>
    /// Represents bank account DTO object
    /// </summary>
    [Serializable]
    public class BankAccountDTO
    {
        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="id">Given id</param>
        /// <param name="firstName">Given first name</param>
        /// <param name="lastName">Given last name</param>
        /// <param name="balance">Given balance</param>
        /// <param name="bonusPoints">Given bonus points</param>
        /// <param name="accountType">Given account type</param>
        public BankAccountDTO(int id, string firstName, string lastName, decimal balance, int bonusPoints, string accountType)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Balance = balance;
            BonusPoints = bonusPoints;
            AccountType = accountType;
        }

        /// <summary>
        /// Id of the bank account
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// First name of the owner of bank account
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the owner of bank account
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Balance of the bank account
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// Bonus points of the bank account
        /// </summary>
        public int BonusPoints { get; set; }

        /// <summary>
        /// Account type of the bank account
        /// </summary>
        public string AccountType { get; set; }
    }
}
