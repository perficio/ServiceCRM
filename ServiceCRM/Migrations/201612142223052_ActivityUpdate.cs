namespace ServiceCRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActivityUpdate : DbMigration
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
                        DueDate = c.DateTime(),
                        Notes = c.String(maxLength: 255),
                        Status = c.String(maxLength: 254),
                        CompletedOn = c.DateTime(),
                        IdUser = c.Int(),
                        CreatedOn = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "timestamp"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Activity");
        }
    }
}
