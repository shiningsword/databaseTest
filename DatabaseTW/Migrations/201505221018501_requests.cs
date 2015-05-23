namespace DatabaseTW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requests : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        RequestID = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        ExpirationDate = c.DateTime(nullable: false),
                        ExchangeMode = c.Int(nullable: false),
                        NeedEscrow = c.Boolean(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RequestID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Requests", new[] { "UserId" });
            DropTable("dbo.Requests");
        }
    }
}
