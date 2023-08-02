namespace _02.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuthorAttributeisDelete : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Authors", "AuthorName", c => c.String(nullable: false));
            AlterColumn("dbo.Authors", "AuthorAbout", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Authors", "AuthorAbout", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Authors", "AuthorName", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
