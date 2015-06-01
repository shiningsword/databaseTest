namespace DatabaseTW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user_request_link : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Requests", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Requests", "UserId");
            AddForeignKey("dbo.Requests", "UserId", "dbo.UserInfoes", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "UserId", "dbo.UserInfoes");
            DropIndex("dbo.Requests", new[] { "UserId" });
            AlterColumn("dbo.Requests", "UserId", c => c.String());
        }
    }
}
