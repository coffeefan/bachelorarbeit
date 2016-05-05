namespace PassportSecurityStep.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PassportInit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PassportSecurityStepConfigs",
                c => new
                    {
                        PassportSecurityStepConfigId = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        Salutation = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.PassportSecurityStepConfigId);
            
            CreateTable(
                "dbo.PassportSecurityStepValidations",
                c => new
                    {
                        PassportSecurityStepValidationId = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        ProviderId = c.String(),
                        StatusId = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        PassportNumber = c.String(),
                        PassportSendCount = c.Int(nullable: false),
                        Code = c.String(),
                        CodeEntered = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PassportSecurityStepValidationId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PassportSecurityStepValidations");
            DropTable("dbo.PassportSecurityStepConfigs");
        }
    }
}
