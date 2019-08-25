using System;

namespace BankAccounts.Library
{
    /// <summary>
    /// Represents "Gold" account type
    /// </summary>
    [Serializable]
    public class GoldAccountType : IAccountType
    {
        /// <summary>
        /// Balance "Cost"
        /// </summary>
        public int BalanceCost { get; set; } = 4;

        /// <summary>
        /// Deposit "Cost"
        /// </summary>
        public int DepositCost { get; set; } = 4;

        /// <summary>
        /// Converts a gold account type to its string representation
        /// </summary>
        /// <returns>String that represents gold account type</returns>
        public override string ToString()
        {
            return "Gold";
        }
    }
}
