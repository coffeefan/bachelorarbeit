namespace SMSSecurityStep.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SMSInit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SMSSecurityStepConfigs",
                c => new
                    {
                        SMSSecurityStepConfigId = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        SendName = c.String(nullable: false, maxLength: 8),
                    })
                .PrimaryKey(t => t.SMSSecurityStepConfigId);
            
            CreateTable(
                "dbo.SMSSecurityStepValidations",
                c => new
                    {
                        SMSSecurityStepValidationId = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        ProviderId = c.String(),
                        StatusId = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        MobileNumber = c.String(),
                        SMSSendCount = c.Int(nullable: false),
                        Code = c.String(),
                        CodeEntered = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SMSSecurityStepValidationId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SMSSecurityStepValidations");
            DropTable("dbo.SMSSecurityStepConfigs");
        }
    }
}
