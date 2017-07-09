namespace StudentsApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseName = c.String(),
                        Degree_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Degrees", t => t.Degree_Id)
                .Index(t => t.Degree_Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentName = c.String(),
                        Degree_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Degrees", t => t.Degree_Id)
                .Index(t => t.Degree_Id);
            
            CreateTable(
                "dbo.Degrees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DegreeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentCourses",
                c => new
                    {
                        StudentID = c.Int(nullable: false),
                        CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentID, t.CourseID })
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.CourseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Degree_Id", "dbo.Degrees");
            DropForeignKey("dbo.Courses", "Degree_Id", "dbo.Degrees");
            DropForeignKey("dbo.StudentCourses", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.StudentCourses", "StudentID", "dbo.Students");
            DropIndex("dbo.StudentCourses", new[] { "CourseID" });
            DropIndex("dbo.StudentCourses", new[] { "StudentID" });
            DropIndex("dbo.Students", new[] { "Degree_Id" });
            DropIndex("dbo.Courses", new[] { "Degree_Id" });
            DropTable("dbo.StudentCourses");
            DropTable("dbo.Degrees");
            DropTable("dbo.Students");
            DropTable("dbo.Courses");
        }
    }
}
