namespace DatabaseTW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class amount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Requests", "AmountMin", c => c.Double(nullable: false));
            AddColumn("dbo.Requests", "AmountMax", c => c.Double(nullable: false));
            AddColumn("dbo.Requests", "Currency", c => c.Int(nullable: false));
            AddColumn("dbo.Transactions", "TransactionAmount", c => c.Double(nullable: false));
            AddColumn("dbo.Transactions", "Currency", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "Currency");
            DropColumn("dbo.Transactions", "TransactionAmount");
            DropColumn("dbo.Requests", "Currency");
            DropColumn("dbo.Requests", "AmountMax");
            DropColumn("dbo.Requests", "AmountMin");
        }
    }
}
