namespace Kaiban.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPosterToAds : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posters",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ImageData = c.Binary(),
                        AdsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ads", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posters", "Id", "dbo.Ads");
            DropIndex("dbo.Posters", new[] { "Id" });
            DropTable("dbo.Posters");
        }
    }
}
