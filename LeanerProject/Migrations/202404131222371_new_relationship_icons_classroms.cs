namespace LeanerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_relationship_icons_classroms : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Classrooms", "CategoryIconsID", c => c.Int(nullable: false));
            CreateIndex("dbo.Classrooms", "CategoryIconsID");
            AddForeignKey("dbo.Classrooms", "CategoryIconsID", "dbo.CategoryIcons", "CategoryIconsID", cascadeDelete: true);
            DropColumn("dbo.Classrooms", "Icon");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Classrooms", "Icon", c => c.String());
            DropForeignKey("dbo.Classrooms", "CategoryIconsID", "dbo.CategoryIcons");
            DropIndex("dbo.Classrooms", new[] { "CategoryIconsID" });
            DropColumn("dbo.Classrooms", "CategoryIconsID");
        }
    }
}
