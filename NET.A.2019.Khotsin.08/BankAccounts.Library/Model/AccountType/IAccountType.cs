namespace BankAccounts.Library
{
    /// <summary>
    /// Represents interface for account type classes
    /// </summary>
    public interface IAccountType
    {
        /// <summary>
        /// Balance "Cost"
        /// </summary>
        int BalanceCost { get; set; }

        /// <summary>
        /// Deposit "Cost"
        /// </summary>
        int DepositCost { get; set; }
    }
}
