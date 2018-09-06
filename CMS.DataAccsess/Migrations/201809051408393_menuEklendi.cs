namespace CMS.DataAccsess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class menuEklendi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ParentId = c.Int(),
                        OrderNo = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ParentMenu_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Menus", t => t.ParentMenu_Id)
                .Index(t => t.ParentMenu_Id);
            
            AddColumn("dbo.Pages", "MenuId", c => c.Int());
            CreateIndex("dbo.Pages", "MenuId");
            AddForeignKey("dbo.Pages", "MenuId", "dbo.Menus", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pages", "MenuId", "dbo.Menus");
            DropForeignKey("dbo.Menus", "ParentMenu_Id", "dbo.Menus");
            DropIndex("dbo.Menus", new[] { "ParentMenu_Id" });
            DropIndex("dbo.Pages", new[] { "MenuId" });
            DropColumn("dbo.Pages", "MenuId");
            DropTable("dbo.Menus");
        }
    }
}
