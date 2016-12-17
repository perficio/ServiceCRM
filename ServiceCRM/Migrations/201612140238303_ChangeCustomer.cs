namespace ServiceCRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCustomer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "IdUser", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "IdUser", c => c.Int());
        }
    }
}
