namespace _02.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAboutAttributes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Abouts", "AboutImage", c => c.String(nullable: false));
            DropColumn("dbo.Abouts", "AboutTitle1");
            DropColumn("dbo.Abouts", "AboutContent1");
            DropColumn("dbo.Abouts", "AboutImage1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Abouts", "AboutImage1", c => c.String());
            AddColumn("dbo.Abouts", "AboutContent1", c => c.String(nullable: false, maxLength: 500));
            AddColumn("dbo.Abouts", "AboutTitle1", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Abouts", "AboutImage", c => c.String());
        }
    }
}
