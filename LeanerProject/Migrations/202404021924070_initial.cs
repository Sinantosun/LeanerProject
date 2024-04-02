namespace LeanerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        AboutID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Image = c.String(),
                        Item1 = c.String(),
                        Item2 = c.String(),
                        Item3 = c.String(),
                    })
                .PrimaryKey(t => t.AboutID);
            
            CreateTable(
                "dbo.Banners",
                c => new
                    {
                        BannerId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.BannerId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Icon = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Image = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategoryID = c.Int(nullable: false),
                        ClassRoomID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.ClassRooms", t => t.ClassRoomID, cascadeDelete: true)
                .Index(t => t.CategoryID)
                .Index(t => t.ClassRoomID);
            
            CreateTable(
                "dbo.ClassRooms",
                c => new
                    {
                        ClassRoomID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Icon = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ClassRoomID);
            
            CreateTable(
                "dbo.CourseRegisters",
                c => new
                    {
                        CourseRegisterID = c.Int(nullable: false, identity: true),
                        StudentsID = c.Int(nullable: false),
                        CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseRegisterID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentsID, cascadeDelete: true)
                .Index(t => t.StudentsID)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentsID = c.Int(nullable: false, identity: true),
                        NameSurname = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.StudentsID);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        ReviewValue = c.Double(nullable: false),
                        Comment = c.String(),
                        StudentsID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReviewID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentsID, cascadeDelete: true)
                .Index(t => t.CourseID)
                .Index(t => t.StudentsID);
            
            CreateTable(
                "dbo.FAQquestions",
                c => new
                    {
                        FAQquestionsID = c.Int(nullable: false, identity: true),
                        Question = c.String(),
                        Answer = c.String(),
                        Image = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FAQquestionsID);
            
            CreateTable(
                "dbo.Testimonials",
                c => new
                    {
                        TestimonialID = c.Int(nullable: false, identity: true),
                        NameSurname = c.String(),
                        Title = c.String(),
                        Image = c.String(),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.TestimonialID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "StudentsID", "dbo.Students");
            DropForeignKey("dbo.Reviews", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.CourseRegisters", "StudentsID", "dbo.Students");
            DropForeignKey("dbo.CourseRegisters", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.Courses", "ClassRoomID", "dbo.ClassRooms");
            DropForeignKey("dbo.Courses", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Reviews", new[] { "StudentsID" });
            DropIndex("dbo.Reviews", new[] { "CourseID" });
            DropIndex("dbo.CourseRegisters", new[] { "CourseID" });
            DropIndex("dbo.CourseRegisters", new[] { "StudentsID" });
            DropIndex("dbo.Courses", new[] { "ClassRoomID" });
            DropIndex("dbo.Courses", new[] { "CategoryID" });
            DropTable("dbo.Testimonials");
            DropTable("dbo.FAQquestions");
            DropTable("dbo.Reviews");
            DropTable("dbo.Students");
            DropTable("dbo.CourseRegisters");
            DropTable("dbo.ClassRooms");
            DropTable("dbo.Courses");
            DropTable("dbo.Categories");
            DropTable("dbo.Banners");
            DropTable("dbo.Abouts");
        }
    }
}
