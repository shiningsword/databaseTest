namespace DatabaseTW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Transactions2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "AmountSend", c => c.Double(nullable: false));
            AddColumn("dbo.Transactions", "CurrencySend", c => c.Int(nullable: false));
            AddColumn("dbo.Transactions", "AmountReceived", c => c.Double(nullable: false));
            AddColumn("dbo.Transactions", "CurrencyRecieved", c => c.Int(nullable: false));
            DropColumn("dbo.Transactions", "TransactionAmount");
            DropColumn("dbo.Transactions", "Currency");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "Currency", c => c.Int(nullable: false));
            AddColumn("dbo.Transactions", "TransactionAmount", c => c.Double(nullable: false));
            DropColumn("dbo.Transactions", "CurrencyRecieved");
            DropColumn("dbo.Transactions", "AmountReceived");
            DropColumn("dbo.Transactions", "CurrencySend");
            DropColumn("dbo.Transactions", "AmountSend");
        }
    }
}
