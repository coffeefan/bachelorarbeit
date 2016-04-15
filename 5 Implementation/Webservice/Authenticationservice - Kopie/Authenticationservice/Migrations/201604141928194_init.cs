namespace Authenticationservice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Description", c => c.String());
            AddColumn("dbo.Projects", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Projects", "ApplicationUserId");
            AddForeignKey("dbo.Projects", "ApplicationUserId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Projects", "Bezeichnung");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "Bezeichnung", c => c.String());
            DropForeignKey("dbo.Projects", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Projects", new[] { "ApplicationUserId" });
            DropColumn("dbo.Projects", "ApplicationUserId");
            DropColumn("dbo.Projects", "Description");
        }
    }
}
