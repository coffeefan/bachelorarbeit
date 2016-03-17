namespace Authentifizierungsservice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AcceptionLevels",
                c => new
                    {
                        AcceptionLevelId = c.Int(nullable: false, identity: true),
                        SecurityStepId = c.Int(nullable: false),
                        InteractiveType = c.Int(nullable: false),
                        Level = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.AcceptionLevelId)
                .ForeignKey("dbo.SecuritySteps", t => t.SecurityStepId, cascadeDelete: true)
                .Index(t => t.SecurityStepId);
            
            CreateTable(
                "dbo.SecuritySteps",
                c => new
                    {
                        SecurityStepId = c.Int(nullable: false, identity: true),
                        SecurityStepName = c.String(),
                        PollAcceptionLevel = c.Int(nullable: false),
                        WinAcceptionLevel = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.SecurityStepId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectID = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(),
                        OwnerId = c.String(maxLength: 128),
                        InteractiveType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectID)
                .ForeignKey("dbo.AspNetUsers", t => t.OwnerId)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.ProjectSecuritySteps",
                c => new
                    {
                        ProjectSecurityStepId = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        SecurityStepId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectSecurityStepId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.SecuritySteps", t => t.SecurityStepId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.SecurityStepId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ProjectSecuritySteps", "SecurityStepId", "dbo.SecuritySteps");
            DropForeignKey("dbo.ProjectSecuritySteps", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Projects", "OwnerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AcceptionLevels", "SecurityStepId", "dbo.SecuritySteps");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ProjectSecuritySteps", new[] { "SecurityStepId" });
            DropIndex("dbo.ProjectSecuritySteps", new[] { "ProjectId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Projects", new[] { "OwnerId" });
            DropIndex("dbo.AcceptionLevels", new[] { "SecurityStepId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ProjectSecuritySteps");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Projects");
            DropTable("dbo.SecuritySteps");
            DropTable("dbo.AcceptionLevels");
        }
    }
}
