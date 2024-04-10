namespace LeanerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration_relation_add_category_ıcons : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryIcons",
                c => new
                    {
                        CategoryIconsID = c.Int(nullable: false, identity: true),
                        IconType = c.String(),
                    })
                .PrimaryKey(t => t.CategoryIconsID);
            
            AddColumn("dbo.Categories", "CategoryIconsID", c => c.Int(nullable: false));
            CreateIndex("dbo.Categories", "CategoryIconsID");
            AddForeignKey("dbo.Categories", "CategoryIconsID", "dbo.CategoryIcons", "CategoryIconsID", cascadeDelete: true);
            DropColumn("dbo.Categories", "Icon");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Icon", c => c.String());
            DropForeignKey("dbo.Categories", "CategoryIconsID", "dbo.CategoryIcons");
            DropIndex("dbo.Categories", new[] { "CategoryIconsID" });
            DropColumn("dbo.Categories", "CategoryIconsID");
            DropTable("dbo.CategoryIcons");
        }
    }
}
