namespace Kaiban.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeDataTypePrice : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ads", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ads", "Price", c => c.Double(nullable: false));
        }
    }
}
