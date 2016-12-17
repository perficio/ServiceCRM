namespace ServiceCRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActivityUpdate4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Activity", "IdUser", c => c.String(nullable: false, maxLength: 254));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Activity", "IdUser", c => c.Int());
        }
    }
}
