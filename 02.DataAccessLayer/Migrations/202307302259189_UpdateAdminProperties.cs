namespace _02.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAdminProperties : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Admins", "RoleId");
            AddForeignKey("dbo.Admins", "RoleId", "dbo.AdminRoles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Admins", "RoleId", "dbo.AdminRoles");
            DropIndex("dbo.Admins", new[] { "RoleId" });
        }
    }
}
