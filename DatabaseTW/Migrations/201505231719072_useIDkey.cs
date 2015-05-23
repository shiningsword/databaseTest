namespace DatabaseTW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class useIDkey : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.UserInfoes");
            AlterColumn("dbo.UserInfoes", "UserId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.UserInfoes", "UserId");
            DropColumn("dbo.UserInfoes", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserInfoes", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.UserInfoes");
            AlterColumn("dbo.UserInfoes", "UserId", c => c.String());
            AddPrimaryKey("dbo.UserInfoes", "Id");
        }
    }
}
