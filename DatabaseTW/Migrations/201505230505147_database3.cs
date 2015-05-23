namespace DatabaseTW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class database3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Requests", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Transactions", "RecipientUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Transactions", "SenderUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Requests", new[] { "UserId" });
            DropIndex("dbo.Transactions", new[] { "SenderUserId" });
            DropIndex("dbo.Transactions", new[] { "RecipientUserId" });
            AlterColumn("dbo.Requests", "UserId", c => c.String());
            AlterColumn("dbo.Transactions", "SenderUserId", c => c.String());
            AlterColumn("dbo.Transactions", "RecipientUserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transactions", "RecipientUserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Transactions", "SenderUserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Requests", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Transactions", "RecipientUserId");
            CreateIndex("dbo.Transactions", "SenderUserId");
            CreateIndex("dbo.Requests", "UserId");
            AddForeignKey("dbo.Transactions", "SenderUserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Transactions", "RecipientUserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Requests", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
