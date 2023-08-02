namespace _02.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAdminProperties2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AdminRoles", "RoleName", c => c.String(nullable: false));
            DropColumn("dbo.AdminRoles", "Role");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AdminRoles", "Role", c => c.String(nullable: false));
            DropColumn("dbo.AdminRoles", "RoleName");
        }
    }
}
