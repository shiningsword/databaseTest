namespace DatabaseTW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transactions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionId = c.Int(nullable: false, identity: true),
                        RecipientUserName = c.String(),
                        SenderUserName = c.String(),
                        Message = c.String(),
                        SenderUserId = c.String(maxLength: 128),
                        RecipientUserId = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TransactionId)
                .ForeignKey("dbo.AspNetUsers", t => t.RecipientUserId)
                .ForeignKey("dbo.AspNetUsers", t => t.SenderUserId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.SenderUserId)
                .Index(t => t.RecipientUserId)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Transactions", "SenderUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Transactions", "RecipientUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Transactions", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Transactions", new[] { "RecipientUserId" });
            DropIndex("dbo.Transactions", new[] { "SenderUserId" });
            DropTable("dbo.Transactions");
        }
    }
}
