namespace Kaiban.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeImageField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "ImageData", c => c.Binary());
            DropColumn("dbo.Images", "ImagePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Images", "ImagePath", c => c.String());
            DropColumn("dbo.Images", "ImageData");
        }
    }
}
