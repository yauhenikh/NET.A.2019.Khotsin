using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Database.Models
{
    /// <summary>
    /// Represents account types to store in database in AccountTypeDBs table
    /// </summary>
    public class AccountTypeDB
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public AccountTypeDB()
        {
            Accounts = new HashSet<Account>();
        }

        /// <summary>
        /// Id of the account type of the bank account
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the account type of the bank account
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Collection of the bank accounts of this type
        /// </summary>
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
