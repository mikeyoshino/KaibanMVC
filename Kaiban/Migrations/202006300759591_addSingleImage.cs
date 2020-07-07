namespace Kaiban.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSingleImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ads", "files", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ads", "files");
        }
    }
}
