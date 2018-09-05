namespace CMS.DataAccsess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LayoutItemDegisti2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Authorizations", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Authorizations", "UpdatedAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Authorizations", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Authorizations", "CreatedAt", c => c.DateTime(nullable: false));
        }
    }
}
