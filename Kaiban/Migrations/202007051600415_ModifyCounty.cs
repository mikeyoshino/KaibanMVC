namespace Kaiban.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyCounty : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Counties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
            DropColumn("dbo.Ads", "StreetName");
            DropColumn("dbo.Ads", "District");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ads", "District", c => c.String());
            AddColumn("dbo.Ads", "StreetName", c => c.String());
            DropForeignKey("dbo.Counties", "CityId", "dbo.Cities");
            DropIndex("dbo.Counties", new[] { "CityId" });
            DropTable("dbo.Counties");
        }
    }
}
