namespace BLL.Interface
{
    /// <summary>
    /// Represents inerface for account number generator classes
    /// </summary>
    public interface IAccountNumberCreateService
    {
        /// <summary>
        /// Generates number using seed number
        /// </summary>
        /// <param name="seed">Given seed number</param>
        /// <returns>Generated number</returns>
        int GenerateNumber(int seed);
    }
}