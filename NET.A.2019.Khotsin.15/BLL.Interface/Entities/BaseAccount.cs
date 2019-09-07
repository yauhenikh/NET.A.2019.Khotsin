namespace BLL.Interface
{
    /// <summary>
    /// Represents bank account of base type
    /// </summary>
    public class BaseAccount : BankAccount
    {
        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="id">Given id</param>
        /// <param name="firstName">Given first name</param>
        /// <param name="lastName">Given last name</param>
        /// <param name="balance">Given balance</param>
        /// <param name="bonusPoints">Given bonus points</param>
        public BaseAccount(int id, string firstName, string lastName, decimal balance, int bonusPoints) :
            base(id, firstName, lastName, balance, bonusPoints)
        {
        }

        /// <summary>
        /// Calculates bonus points
        /// </summary>
        /// <param name="value">Given value of deposit/withdrawal</param>
        /// <returns>Calculated bonus points</returns>
        protected override int CalculateBonusPoints(decimal value)
        {
            return (int)(value * 1);
        }

        /// <summary>
        /// Determines if balance value is valid
        /// </summary>
        /// <param name="value">Given balance value</param>
        /// <returns>True, if balance value is valid</returns>
        protected override bool IsBalanceValid(decimal value)
        {
            return value >= 0;
        }

        /// <summary>
        /// Converts a base bank account to its string representation
        /// </summary>
        /// <returns>String that represents base bank account</returns>
        public override string ToString()
        {
            return base.ToString() +
                $"\nType: Base";
        }
    }
}
