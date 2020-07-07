namespace Kaiban.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostDated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ads", "PostDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ads", "PostDate");
        }
    }
}
