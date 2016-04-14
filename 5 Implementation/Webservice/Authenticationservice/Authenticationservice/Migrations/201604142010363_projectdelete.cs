namespace Authenticationservice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class projectdelete : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "IsDeleted");
        }
    }
}
