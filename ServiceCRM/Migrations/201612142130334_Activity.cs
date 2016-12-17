namespace ServiceCRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Activity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
               "dbo.Activity",
               c => new
               {
                   Id = c.Int(nullable: false, identity: true),
                   IdCustomer = c.Int(),
                   ActivityType = c.String(nullable: false, maxLength: 80),
                   DueDate = c.DateTime(nullable: true),
                   Notes = c.String(nullable: true, maxLength: 255),
                   Status = c.String(nullable: true, maxLength: 254),
                   CompletedOn = c.DateTime(nullable: true),
                   IdUser = c.Int(),
                   CreatedOn = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
               })
               .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.Activity");
        }
    }
}
