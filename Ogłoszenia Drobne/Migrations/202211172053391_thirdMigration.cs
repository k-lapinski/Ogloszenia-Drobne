namespace Ogłoszenia_Drobne.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class thirdMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Announcements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 250),
                        Description = c.String(nullable: false, maxLength: 250),
                        Address = c.String(nullable: false, maxLength: 250),
                        ImgPath = c.String(),
                        NumberOfEntries = c.Int(nullable: false),
                        IdAuthor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Dictionaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Newsletters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 250),
                        Description = c.String(nullable: false, maxLength: 250),
                        Author = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CategoryAnnouncements",
                c => new
                    {
                        Category_Id = c.Int(nullable: false),
                        Announcement_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Category_Id, t.Announcement_Id })
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .ForeignKey("dbo.Announcements", t => t.Announcement_Id, cascadeDelete: true)
                .Index(t => t.Category_Id)
                .Index(t => t.Announcement_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CategoryAnnouncements", "Announcement_Id", "dbo.Announcements");
            DropForeignKey("dbo.CategoryAnnouncements", "Category_Id", "dbo.Categories");
            DropIndex("dbo.CategoryAnnouncements", new[] { "Announcement_Id" });
            DropIndex("dbo.CategoryAnnouncements", new[] { "Category_Id" });
            DropTable("dbo.CategoryAnnouncements");
            DropTable("dbo.Newsletters");
            DropTable("dbo.Dictionaries");
            DropTable("dbo.Categories");
            DropTable("dbo.Announcements");
        }
    }
}
