namespace Authenticationservice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjectSecurityStep : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ProjectSecuritySteps", "Created");
            DropColumn("dbo.ProjectSecuritySteps", "Updated");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProjectSecuritySteps", "Updated", c => c.DateTime(nullable: false));
            AddColumn("dbo.ProjectSecuritySteps", "Created", c => c.DateTime(nullable: false));
        }
    }
}
