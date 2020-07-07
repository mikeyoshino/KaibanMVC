namespace Kaiban.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDescriptionAndPriceToAdsClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ads", "Description", c => c.String());
            AddColumn("dbo.Ads", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ads", "Price");
            DropColumn("dbo.Ads", "Description");
        }
    }
}
