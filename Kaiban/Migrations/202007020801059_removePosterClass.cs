namespace Kaiban.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removePosterClass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posters", "Id", "dbo.Ads");
            DropIndex("dbo.Posters", new[] { "Id" });
            AddColumn("dbo.Ads", "Poster", c => c.String());
            DropTable("dbo.Posters");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Posters",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ImageData = c.Binary(),
                        AdsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Ads", "Poster");
            CreateIndex("dbo.Posters", "Id");
            AddForeignKey("dbo.Posters", "Id", "dbo.Ads", "Id");
        }
    }
}
