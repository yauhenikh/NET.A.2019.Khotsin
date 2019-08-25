using System;

namespace BankAccounts.Library
{
    /// <summary>
    /// Represents default bonus points calculator
    /// </summary>
    [Serializable]
    public class DefaultBonusPointsCalculator : IBonusPointsCalculator
    {
        /// <summary>
        /// Calculates bonus points
        /// </summary>
        /// <param name="accountType">Given account type</param>
        /// <param name="isDeposit">True if need to calculate for deposit, false if need to calculate for withdrawal</param>
        /// <returns>Calculated bonus points</returns>
        public int CalculateBonusPoints(IAccountType accountType, bool isDeposit)
        {
            if (isDeposit)
            {
                return accountType.DepositCost;
            }
            else
            {
                return accountType.BalanceCost / 2;
            }
        }
    }
}
