namespace PhoneSecurityStep.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhoneInit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PhoneSecurityStepConfigs",
                c => new
                    {
                        PhoneSecurityStepConfigId = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        Salutation = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.PhoneSecurityStepConfigId);
            
            CreateTable(
                "dbo.PhoneSecurityStepValidations",
                c => new
                    {
                        PhoneSecurityStepValidationId = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        ProviderId = c.String(),
                        StatusId = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        PhoneNumber = c.String(),
                        PhoneSendCount = c.Int(nullable: false),
                        Code = c.String(),
                        CodeEntered = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PhoneSecurityStepValidationId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PhoneSecurityStepValidations");
            DropTable("dbo.PhoneSecurityStepConfigs");
        }
    }
}
