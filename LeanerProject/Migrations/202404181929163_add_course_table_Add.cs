namespace LeanerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_course_table_Add : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseVideos",
                c => new
                    {
                        CourseVideoID = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        VideoNumber = c.Int(nullable: false),
                        VideoURL = c.String(),
                    })
                .PrimaryKey(t => t.CourseVideoID)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseVideos", "CourseId", "dbo.Courses");
            DropIndex("dbo.CourseVideos", new[] { "CourseId" });
            DropTable("dbo.CourseVideos");
        }
    }
}
