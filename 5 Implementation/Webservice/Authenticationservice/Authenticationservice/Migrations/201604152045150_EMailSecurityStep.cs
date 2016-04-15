namespace Authenticationservice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EMailSecurityStep : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ProjectSecuritySteps", "AdditionalConfiguration");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProjectSecuritySteps", "AdditionalConfiguration", c => c.String());
        }
    }
}
