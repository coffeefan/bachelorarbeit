namespace PassportSecurityStep.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PassportInit : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PassportSecurityStepConfigs", "Salutation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PassportSecurityStepConfigs", "Salutation", c => c.String(nullable: false, maxLength: 30));
        }
    }
}
