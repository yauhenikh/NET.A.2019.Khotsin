namespace BankAccounts.Library
{
    /// <summary>
    /// Interface for bonus points calculator classes 
    /// </summary>
    public interface IBonusPointsCalculator
    {
        /// <summary>
        /// Calculates bonus points
        /// </summary>
        /// <param name="accountType">Given account type</param>
        /// <param name="isDeposit">True if need to calculate for deposit, false if need to calculate for withdrawal</param>
        /// <returns>Calculated bonus points</returns>
        int CalculateBonusPoints(IAccountType accountType, bool isDeposit);
    }
}
