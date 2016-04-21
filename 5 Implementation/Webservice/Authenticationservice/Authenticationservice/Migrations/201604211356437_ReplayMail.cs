namespace Authenticationservice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReplayMail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProjectAuthentications", "Finished", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProjectSecuritySteps", "SecurityStep", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProjectSecuritySteps", "SecurityStep", c => c.Int(nullable: false));
            DropColumn("dbo.ProjectAuthentications", "Finished");
        }
    }
}
