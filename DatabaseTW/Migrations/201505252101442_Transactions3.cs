namespace DatabaseTW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Transactions3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "RecipientName", c => c.String());
            AddColumn("dbo.Transactions", "SenderName", c => c.String());
            DropColumn("dbo.Transactions", "RecipientUserName");
            DropColumn("dbo.Transactions", "SenderUserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "SenderUserName", c => c.String());
            AddColumn("dbo.Transactions", "RecipientUserName", c => c.String());
            DropColumn("dbo.Transactions", "SenderName");
            DropColumn("dbo.Transactions", "RecipientName");
        }
    }
}
