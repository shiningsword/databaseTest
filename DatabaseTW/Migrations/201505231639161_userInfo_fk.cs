namespace DatabaseTW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userInfo_fk : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserInfoes", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.UserInfoes", new[] { "UserId" });
            DropPrimaryKey("dbo.UserInfoes");
            AddColumn("dbo.UserInfoes", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.UserInfoes", "UserId", c => c.String());
            AddPrimaryKey("dbo.UserInfoes", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UserInfoes");
            AlterColumn("dbo.UserInfoes", "UserId", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.UserInfoes", "Id");
            AddPrimaryKey("dbo.UserInfoes", "UserId");
            CreateIndex("dbo.UserInfoes", "UserId");
            AddForeignKey("dbo.UserInfoes", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
