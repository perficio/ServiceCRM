namespace ServiceCRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initAzure : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 80),
                        LastName = c.String(nullable: false, maxLength: 80),
                        Email = c.String(nullable: false, maxLength: 254),
                        Phone = c.String(maxLength: 20),
                        Company = c.String(maxLength: 80),
                        Address = c.String(maxLength: 80),
                        City = c.String(maxLength: 80),
                        State = c.String(maxLength: 2),
                        PostalCode = c.String(maxLength: 20),
                        IdUser = c.Int(),
                        CreatedOn = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Customers");
        }
    }
}
