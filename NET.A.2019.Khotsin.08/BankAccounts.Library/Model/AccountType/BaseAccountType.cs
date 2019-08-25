using System;

namespace BankAccounts.Library
{
    /// <summary>
    /// Represents "Base" account type
    /// </summary>
    [Serializable]
    public class BaseAccountType : IAccountType
    {
        /// <summary>
        /// Balance "Cost"
        /// </summary>
        public int BalanceCost { get; set; } = 2;

        /// <summary>
        /// Deposit "Cost"
        /// </summary>
        public int DepositCost { get; set; } = 2;

        /// <summary>
        /// Converts a base account type to its string representation
        /// </summary>
        /// <returns>String that represents base account type</returns>
        public override string ToString()
        {
            return "Base";
        }
    }
}
