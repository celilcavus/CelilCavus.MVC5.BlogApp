namespace _02.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAttributeBlogClass2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Blogs", "BlogTitle", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Blogs", "BlogImage", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Blogs", "BlogContent", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Blogs", "BlogContent", c => c.String());
            AlterColumn("dbo.Blogs", "BlogImage", c => c.String());
            AlterColumn("dbo.Blogs", "BlogTitle", c => c.String());
        }
    }
}
