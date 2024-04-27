namespace LeanerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migaration_remove_colm_for_table_about : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Abouts", "ImageUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Abouts", "ImageUrl", c => c.String());
        }
    }
}
