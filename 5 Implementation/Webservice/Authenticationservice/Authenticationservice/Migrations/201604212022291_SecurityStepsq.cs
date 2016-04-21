namespace Authenticationservice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecurityStepsq : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Projects", "SecuritySteps");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "SecuritySteps", c => c.String());
        }
    }
}
