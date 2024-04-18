namespace LeanerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration_teacher_Add : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherID = c.Int(nullable: false, identity: true),
                        NameSurname = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.TeacherID);
            
            AddColumn("dbo.Courses", "TeacherID", c => c.Int());
            CreateIndex("dbo.Courses", "TeacherID");
            AddForeignKey("dbo.Courses", "TeacherID", "dbo.Teachers", "TeacherID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "TeacherID", "dbo.Teachers");
            DropIndex("dbo.Courses", new[] { "TeacherID" });
            DropColumn("dbo.Courses", "TeacherID");
            DropTable("dbo.Teachers");
        }
    }
}
