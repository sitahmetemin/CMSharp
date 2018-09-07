namespace CMS.DataAccsess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PageAddClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PageContents", "Class", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PageContents", "Class");
        }
    }
}
