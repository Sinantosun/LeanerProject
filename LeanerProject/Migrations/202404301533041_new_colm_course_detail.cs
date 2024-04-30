namespace LeanerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_colm_course_detail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CoursesDetails",
                c => new
                    {
                        CoursesDetailsID = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        CourseContent = c.String(),
                        CourseDetail = c.String(),
                    })
                .PrimaryKey(t => t.CoursesDetailsID)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CoursesDetails", "CourseId", "dbo.Courses");
            DropIndex("dbo.CoursesDetails", new[] { "CourseId" });
            DropTable("dbo.CoursesDetails");
        }
    }
}
