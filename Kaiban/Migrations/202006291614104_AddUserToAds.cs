namespace Kaiban.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserToAds : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ads", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Ads", "ApplicationUserId");
            AddForeignKey("dbo.Ads", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ads", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Ads", new[] { "ApplicationUserId" });
            DropColumn("dbo.Ads", "ApplicationUserId");
        }
    }
}
