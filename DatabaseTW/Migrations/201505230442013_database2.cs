namespace DatabaseTW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class database2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Transactions", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Transactions", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Transactions", "ApplicationUser_Id");
            AddForeignKey("dbo.Transactions", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
