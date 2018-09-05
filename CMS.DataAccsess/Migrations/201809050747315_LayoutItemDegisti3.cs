namespace CMS.DataAccsess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LayoutItemDegisti3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Authorizations", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Authorizations", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.LayoutItems", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.LayoutItems", "UpdatedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LayoutItems", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.LayoutItems", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Authorizations", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.Authorizations", "CreatedAt", c => c.DateTime());
        }
    }
}
