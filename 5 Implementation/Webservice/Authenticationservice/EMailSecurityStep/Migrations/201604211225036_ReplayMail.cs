namespace EMailSecurityStep.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReplayMail : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EMailSecurityStepConfigs", "ReplayMail", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EMailSecurityStepConfigs", "ReplayMail", c => c.String());
        }
    }
}
