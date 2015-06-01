namespace DatabaseTW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class request2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Requests", "CloseToZipcode", c => c.Int(nullable: false));
            AddColumn("dbo.Requests", "CompanyDomain", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Requests", "CompanyDomain");
            DropColumn("dbo.Requests", "CloseToZipcode");
        }
    }
}
