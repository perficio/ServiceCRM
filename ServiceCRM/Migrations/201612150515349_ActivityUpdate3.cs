namespace ServiceCRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActivityUpdate3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Activity", "IdCustomer", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Activity", "IdCustomer", c => c.Int());
        }
    }
}
