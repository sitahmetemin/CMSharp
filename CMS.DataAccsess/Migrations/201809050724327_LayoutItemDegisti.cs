namespace CMS.DataAccsess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LayoutItemDegisti : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LayoutItems", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.LayoutItems", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.LayoutItems", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LayoutItems", "IsDeleted");
            DropColumn("dbo.LayoutItems", "UpdatedAt");
            DropColumn("dbo.LayoutItems", "CreatedAt");
        }
    }
}
