namespace Kaiban.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ads", "ImagePath", c => c.String());
            DropColumn("dbo.Ads", "files");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ads", "files", c => c.String());
            DropColumn("dbo.Ads", "ImagePath");
        }
    }
}
