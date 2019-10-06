using System.Data.Entity;
using DAL.Database.Models;

namespace DAL.Database.Context
{
    /// <summary>
    /// Represents initializer that will optionally recreate and re-seed the database
    /// </summary>
    public class AccountsInitializer : CreateDatabaseIfNotExists<AccountContext>
    {
        /// <summary>
        /// Adds data to the context for seeding
        /// </summary>
        /// <param name="context">The context to seed</param>
        protected override void Seed(AccountContext context)
        {
            context.AccountTypes.AddRange(new AccountTypeDB[]
                {
                    new AccountTypeDB { Name = "Base" },
                    new AccountTypeDB { Name = "Silver" },
                    new AccountTypeDB { Name = "Gold" },
                    new AccountTypeDB { Name = "Platinum" },
                });

            context.SaveChanges();
        }
    }
}
