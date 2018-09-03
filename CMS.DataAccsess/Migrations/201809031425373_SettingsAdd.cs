namespace CMS.DataAccsess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SettingsAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        SiteTitle = c.String(),
                        Slogan = c.String(),
                        Description = c.String(),
                        Copyright = c.String(),
                        Logo = c.String(),
                        Ico = c.String(),
                        SMTPHost = c.String(),
                        SMTPPort = c.String(),
                        SMTPUser = c.String(),
                        SMTPPassword = c.String(),
                        Facebook = c.String(),
                        Twitter = c.String(),
                        Instagram = c.String(),
                        Youtube = c.String(),
                        Linkedin = c.String(),
                        Google = c.String(),
                        Github = c.String(),
                        Pinterest = c.String(),
                        Tumblr = c.String(),
                        Flickr = c.String(),
                        Reddit = c.String(),
                        Snapchat = c.String(),
                        Whatsapp = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Settings");
        }
    }
}
