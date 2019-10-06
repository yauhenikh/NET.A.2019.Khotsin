namespace DAL.Database.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    /// <summary>
    /// Represents configuration relating to the use of migrations for a given model
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<DAL.Database.Context.AccountContext>
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.ContextKey = "DAL.Database.Context.AccountContext";
        }

        /// <summary>
        /// Method, which will be called after migrating to the latest version
        /// </summary>
        /// <param name="context">Given context</param>
        protected override void Seed(DAL.Database.Context.AccountContext context)
        {
            // This method will be called after migrating to the latest version.

            // You can use the DbSet<T>.AddOrUpdate() helper extension method
            // to avoid creating duplicate seed data.
        }
    }
}
