namespace ServiceCRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActivityUpdate5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Activity", "DueDate", c => c.DateTime(storeType: "date"));
            AlterColumn("dbo.Activity", "CompletedOn", c => c.DateTime(storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Activity", "CompletedOn", c => c.DateTime());
            AlterColumn("dbo.Activity", "DueDate", c => c.DateTime());
        }
    }
}
