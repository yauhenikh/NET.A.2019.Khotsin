using System;
using System.Reflection;
using BLL.Interface;
using DAL.Interface;

namespace BLL
{
    /// <summary>
    /// Represents class for mapping BankAccountDTO object to BankAccount object and vice versa
    /// </summary>
    public static class BankAccountMapper
    {
        /// <summary>
        /// Maps BankAccount object to BankAccountDTO object
        /// </summary>
        /// <param name="account">Given BankAccount object</param>
        /// <returns>Generated BankAccountDTO object</returns>
        public static BankAccountDTO BankAccToDTO(BankAccount account)
        {
            return new BankAccountDTO(
                account.Id,
                account.FirstName,
                account.LastName,
                account.Balance,
                account.BonusPoints,
                account.GetType().ToString());
        }

        /// <summary>
        /// Maps BankAccountDTO object to BankAccount object
        /// </summary>
        /// <param name="dto">Given BankAccountDTO object</param>
        /// <returns>Generated BankAccount object</returns>
        public static BankAccount DTOToBancAcc(BankAccountDTO dto)
        {
            string accountType = dto.AccountType;

            if (accountType.Substring(0, 3) != "BLL")
            {
                accountType = "BLL.Interface." + accountType + "Account";
            }

            Assembly asm = typeof(BaseAccount).Assembly;
            Type type = asm.GetType(accountType);

            dynamic account = Activator.CreateInstance(type, dto.Id, dto.FirstName, dto.LastName, dto.Balance, dto.BonusPoints) as BankAccount;

            return account;
        }
    }
}
