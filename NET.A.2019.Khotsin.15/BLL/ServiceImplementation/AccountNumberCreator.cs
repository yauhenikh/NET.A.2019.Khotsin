using BLL.Interface;

namespace BLL
{
    /// <summary>
    /// Represents simple account number creator
    /// </summary>
    public class AccountNumberCreator : IAccountNumberCreateService
    {
        /// <summary>
        /// Generates number using seed number
        /// </summary>
        /// <param name="seed">Given seed number</param>
        /// <returns>Generated number</returns>
        public int GenerateNumber(int seed)
        {
            return seed + 1;
        }
    }
}
