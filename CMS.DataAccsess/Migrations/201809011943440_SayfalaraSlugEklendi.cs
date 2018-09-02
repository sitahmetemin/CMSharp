namespace CMS.DataAccsess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SayfalaraSlugEklendi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pages", "Slug", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pages", "Slug");
        }
    }
}
