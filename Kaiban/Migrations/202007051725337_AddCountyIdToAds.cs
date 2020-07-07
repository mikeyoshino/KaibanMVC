namespace Kaiban.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCountyIdToAds : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ads", "CountyId", c => c.Int());
            CreateIndex("dbo.Ads", "CountyId");
            AddForeignKey("dbo.Ads", "CountyId", "dbo.Counties", "Id");
            DropColumn("dbo.Ads", "County");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ads", "County", c => c.String());
            DropForeignKey("dbo.Ads", "CountyId", "dbo.Counties");
            DropIndex("dbo.Ads", new[] { "CountyId" });
            DropColumn("dbo.Ads", "CountyId");
        }
    }
}
