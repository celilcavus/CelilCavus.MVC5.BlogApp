namespace _02.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAtributeAdmin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "RoleId", c => c.Int(nullable: false));
            AlterColumn("dbo.Admins", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.Admins", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Admins", "Password", c => c.String());
            AlterColumn("dbo.Admins", "UserName", c => c.String());
            DropColumn("dbo.Admins", "RoleId");
        }
    }
}
