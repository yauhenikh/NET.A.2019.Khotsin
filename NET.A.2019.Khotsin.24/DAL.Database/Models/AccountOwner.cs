using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Database.Models
{
    /// <summary>
    /// Represents owner of the bank account to store in database in AccountOwners table
    /// </summary>
    public class AccountOwner
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public AccountOwner()
        {
            Accounts = new HashSet<Account>();
        }

        /// <summary>
        /// Id of the bank account owner
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// First name of the bank account owner
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the bank account owner
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Collection of the owner's bank accounts
        /// </summary>
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
