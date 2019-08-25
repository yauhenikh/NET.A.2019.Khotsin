using System;

namespace BankAccounts.Library
{
    /// <summary>
    /// Represents "Platinum" account type
    /// </summary>
    [Serializable]
    public class PlatinumAccountType : IAccountType
    {
        /// <summary>
        /// Balance "Cost"
        /// </summary>
        public int BalanceCost { get; set; } = 6;

        /// <summary>
        /// Deposit "Cost"
        /// </summary>
        public int DepositCost { get; set; } = 6;

        /// <summary>
        /// Converts a platinum account type to its string representation
        /// </summary>
        /// <returns>String that represents platinum account type</returns>
        public override string ToString()
        {
            return "Platinum";
        }
    }
}
