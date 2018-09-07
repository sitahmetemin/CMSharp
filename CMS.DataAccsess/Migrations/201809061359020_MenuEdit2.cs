namespace CMS.DataAccsess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MenuEdit2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Menus", "Name", c => c.String(maxLength: 100));
            CreateIndex("dbo.Menus", "Name", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Menus", new[] { "Name" });
            AlterColumn("dbo.Menus", "Name", c => c.String());
        }
    }
}
