namespace CMS.DataAccsess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kt : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SliderContexts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        imgWay = c.String(),
                        Slider_Id = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Slider_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sliders", t => t.Slider_Id1)
                .Index(t => t.Slider_Id1);
            
            CreateTable(
                "dbo.Sliders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SliderContexts", "Slider_Id1", "dbo.Sliders");
            DropIndex("dbo.SliderContexts", new[] { "Slider_Id1" });
            DropTable("dbo.Sliders");
            DropTable("dbo.SliderContexts");
        }
    }
}
