namespace Kaiban.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMutiplImgae : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Ads", "ImagePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ads", "ImagePath", c => c.String());
        }
    }
}
