namespace CMS.DataAccsess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PageContentDuzeltmeler : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PageContents", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.PageContents", "UpdatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.PageContents", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PageContents", "IsDeleted");
            DropColumn("dbo.PageContents", "UpdatedAt");
            DropColumn("dbo.PageContents", "CreatedAt");
        }
    }
}
