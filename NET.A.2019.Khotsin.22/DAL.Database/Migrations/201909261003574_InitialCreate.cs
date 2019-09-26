namespace DAL.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    /// <summary>
    /// Represents code-based migrations
    /// </summary>
    public partial class InitialCreate : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process
        /// </summary>
        public override void Up()
        {
            CreateTable(
                "dbo.AccountOwners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountOwnerId = c.Int(nullable: false),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BonusPoints = c.Int(nullable: false),
                        AccountTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountOwners", t => t.AccountOwnerId, cascadeDelete: true)
                .ForeignKey("dbo.AccountTypeDBs", t => t.AccountTypeId, cascadeDelete: true)
                .Index(t => t.AccountOwnerId)
                .Index(t => t.AccountTypeId);
            
            CreateTable(
                "dbo.AccountTypeDBs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
        }

        /// <summary>
        /// Operations to be performed during the downgrade process
        /// </summary>
        public override void Down()
        {
            this.DropForeignKey("dbo.Accounts", "AccountTypeId", "dbo.AccountTypeDBs");
            this.DropForeignKey("dbo.Accounts", "AccountOwnerId", "dbo.AccountOwners");
            this.DropIndex("dbo.Accounts", new[] { "AccountTypeId" });
            this.DropIndex("dbo.Accounts", new[] { "AccountOwnerId" });
            this.DropTable("dbo.AccountTypeDBs");
            this.DropTable("dbo.Accounts");
            this.DropTable("dbo.AccountOwners");
        }
    }
}
