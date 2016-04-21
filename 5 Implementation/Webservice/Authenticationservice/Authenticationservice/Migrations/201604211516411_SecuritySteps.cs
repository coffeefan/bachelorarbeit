namespace Authenticationservice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecuritySteps : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "SecuritySteps", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "SecuritySteps");
        }
    }
}
