namespace DAL.Database.Models
{
    /// <summary>
    /// Represents bank account to store in database in Accounts table
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Id of the bank account
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id of the bank account owner
        /// </summary>
        public int AccountOwnerId { get; set; }

        /// <summary>
        /// Balance of the bank account
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// Bonus points of the bank account
        /// </summary>
        public int BonusPoints { get; set; }

        /// <summary>
        /// Id of the account type of the bank account
        /// </summary>
        public int AccountTypeId { get; set; }

        /// <summary>
        /// Owner of the bank account
        /// </summary>
        public virtual AccountOwner AccountOwner { get; set; }

        /// <summary>
        /// Account type of the bank account
        /// </summary>
        public virtual AccountTypeDB AccountType { get; set; }
    }
}
