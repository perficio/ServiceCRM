namespace ServiceCRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActivityUpdate2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activity", "IdCustomer", c => c.Int());

        }
        
        public override void Down()
        {
            DropColumn("dbo.Activity", "IdCustomer");
        }
    }
}
