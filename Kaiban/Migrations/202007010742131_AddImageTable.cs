namespace Kaiban.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(),
                        AdsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ads", t => t.AdsId, cascadeDelete: true)
                .Index(t => t.AdsId);
            
            AddColumn("dbo.Ads", "Ads_Id", c => c.Int());
            CreateIndex("dbo.Ads", "Ads_Id");
            AddForeignKey("dbo.Ads", "Ads_Id", "dbo.Ads", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "AdsId", "dbo.Ads");
            DropForeignKey("dbo.Ads", "Ads_Id", "dbo.Ads");
            DropIndex("dbo.Images", new[] { "AdsId" });
            DropIndex("dbo.Ads", new[] { "Ads_Id" });
            DropColumn("dbo.Ads", "Ads_Id");
            DropTable("dbo.Images");
        }
    }
}
