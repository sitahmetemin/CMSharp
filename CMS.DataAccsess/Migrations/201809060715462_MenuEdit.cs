namespace CMS.DataAccsess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MenuEdit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menus", "Icon", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Menus", "Icon");
        }
    }
}
