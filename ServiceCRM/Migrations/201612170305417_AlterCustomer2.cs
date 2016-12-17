namespace ServiceCRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterCustomer2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "IdUser", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "IdUser", c => c.String(maxLength: 128));
        }
    }
}
