namespace Kaiban.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteCascicade : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AdsImages", "AdsId", "dbo.Ads");
            DropForeignKey("dbo.Ads", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Ads", "CityId", "dbo.Cities");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Counties", "CityId", "dbo.Cities");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.Ads", new[] { "CountyId" });
            AlterColumn("dbo.Ads", "CountyId", c => c.Int(nullable: false));
            CreateIndex("dbo.Ads", "CountyId");
            AddForeignKey("dbo.AdsImages", "AdsId", "dbo.Ads", "Id");
            AddForeignKey("dbo.Ads", "CategoryId", "dbo.Categories", "Id");
            AddForeignKey("dbo.Ads", "CityId", "dbo.Cities", "Id");
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Counties", "CityId", "dbo.Cities", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Counties", "CityId", "dbo.Cities");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Ads", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Ads", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.AdsImages", "AdsId", "dbo.Ads");
            DropIndex("dbo.Ads", new[] { "CountyId" });
            AlterColumn("dbo.Ads", "CountyId", c => c.Int());
            CreateIndex("dbo.Ads", "CountyId");
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Counties", "CityId", "dbo.Cities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Ads", "CityId", "dbo.Cities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Ads", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AdsImages", "AdsId", "dbo.Ads", "Id", cascadeDelete: true);
        }
    }
}
