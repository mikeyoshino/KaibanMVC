namespace Kaiban.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reuqireallclassads : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ads", "AdsName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ads", "AdsName", c => c.String());
        }
    }
}
