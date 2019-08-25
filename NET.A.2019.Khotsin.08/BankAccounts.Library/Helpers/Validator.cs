namespace BankAccounts.Library
{
    /// <summary>
    /// Class for validation
    /// </summary>
    internal static class Validator
    {
        /// <summary>
        /// Determines if id value is valid
        /// </summary>
        /// <param name="id">Given id</param>
        /// <returns>True, if id value is valid</returns>
        internal static bool IsIdValid(int id)
        {
            if (id <= 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Determines if first name is valid
        /// </summary>
        /// <param name="firstName">Given first name</param>
        /// <returns>True, if first name is valid</returns>
        internal static bool IsFirstNameValid(string firstName)
        {
            if (firstName == null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Determines if last name is valid
        /// </summary>
        /// <param name="lastName">Given last name</param>
        /// <returns>True, if last name is valid</returns>
        internal static bool IsLastNameValid(string lastName)
        {
            if (lastName == null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Determines if balance is valid
        /// </summary>
        /// <param name="balance">Given balance</param>
        /// <returns>True, if balance is valid</returns>
        internal static bool IsBalanceValid(decimal balance)
        {
            if (balance < 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Determines if bonus points value is valid
        /// </summary>
        /// <param name="balance">Given bonus points value</param>
        /// <returns>True, if bonus points value is valid</returns>
        internal static bool IsBonusPointsValid(int bonusPoints)
        {
            if (bonusPoints < 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Determines if account type is valid
        /// </summary>
        /// <param name="accountType">Given account type</param>
        /// <returns>True, if account type is valid</returns>
        internal static bool IsAccountTypeValid(IAccountType accountType)
        {
            if (accountType == null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Determines if bonus points calculator is valid
        /// </summary>
        /// <param name="bonusPointsCalculator">Given bonus points calculator</param>
        /// <returns>True, if bonus points calculator is valid</returns>
        internal static bool IsBonusPointsCalculatorValid(IBonusPointsCalculator bonusPointsCalculator)
        {
            if (bonusPointsCalculator == null)
            {
                return false;
            }

            return true;
        }
    }
}
