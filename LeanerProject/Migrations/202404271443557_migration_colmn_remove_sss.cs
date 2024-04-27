namespace LeanerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration_colmn_remove_sss : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.FAQs", "ImageUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FAQs", "ImageUrl", c => c.String());
        }
    }
}
