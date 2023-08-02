namespace _02.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuthorAttributesCompleted : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Authors", "AuthorName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Authors", "AuthorAbout", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Authors", "AuthorAbout", c => c.String());
            AlterColumn("dbo.Authors", "AuthorName", c => c.String(maxLength: 50));
        }
    }
}
