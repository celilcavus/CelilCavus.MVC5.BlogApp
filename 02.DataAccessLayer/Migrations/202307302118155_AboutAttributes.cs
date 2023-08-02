namespace _02.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AboutAttributes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Abouts", "AboutTitle", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Abouts", "AboutContent", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Abouts", "AboutTitle1", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Abouts", "AboutContent1", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Abouts", "AboutContent1", c => c.String());
            AlterColumn("dbo.Abouts", "AboutTitle1", c => c.String());
            AlterColumn("dbo.Abouts", "AboutContent", c => c.String());
            AlterColumn("dbo.Abouts", "AboutTitle", c => c.String());
        }
    }
}
