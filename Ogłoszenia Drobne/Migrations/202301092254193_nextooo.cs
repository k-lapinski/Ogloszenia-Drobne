namespace Ogłoszenia_Drobne.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nextooo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Announcements", "IdAuthor", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Announcements", "IdAuthor", c => c.Int(nullable: false));
        }
    }
}
