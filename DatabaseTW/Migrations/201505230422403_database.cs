namespace DatabaseTW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class database : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserInfoes", "Zip", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserInfoes", "Zip", c => c.String());
        }
    }
}
