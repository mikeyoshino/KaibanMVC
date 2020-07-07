namespace Kaiban.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrelationshipBetweenAdsAndImage : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Images", newName: "AdsImages");
            DropForeignKey("dbo.Ads", "Ads_Id", "dbo.Ads");
            DropIndex("dbo.Ads", new[] { "Ads_Id" });
            DropColumn("dbo.Ads", "Ads_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ads", "Ads_Id", c => c.Int());
            CreateIndex("dbo.Ads", "Ads_Id");
            AddForeignKey("dbo.Ads", "Ads_Id", "dbo.Ads", "Id");
            RenameTable(name: "dbo.AdsImages", newName: "Images");
        }
    }
}
