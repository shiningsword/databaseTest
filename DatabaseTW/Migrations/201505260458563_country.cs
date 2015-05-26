namespace DatabaseTW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class country : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserInfoes", "Country", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserInfoes", "Country");
        }
    }
}
