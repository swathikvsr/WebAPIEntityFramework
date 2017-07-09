namespace StudentsApp.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    internal sealed class Configuration : DbMigrationsConfiguration<StudentsApp.Models.StudentsAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StudentsApp.Models.StudentsAppContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            List<Course> courseList = new List<Course>()
            {
               new Course {Id = 1, CourseName = "Arts1" },
              new Course { Id = 2, CourseName = "Arts2" },
              new Course { Id =3, CourseName = "Arts3" }
            };
            List<Course> courseList1 = new List<Course>()
            {
               new Course {Id = 2, CourseName = "Science1" },
              new Course { Id = 3, CourseName = "Science2" },
              new Course { Id = 4, CourseName = "Science3" }
            };
            //context.Courses.AddOrUpdate(
            //  p => p.Id,
            //  new Course { Id = 1, CourseName = "Arts1" },
            //  new Course { Id = 2, CourseName = "Arts2" },
            //  new Course { Id = 3, CourseName = "Arts3" }
            //);
            List<Degree> degressList = new List<Degree>()
            {
               new Degree {Id = 1, DegreeName = "Arts", CourseList = courseList },
              new Degree { Id = 2, DegreeName = "Science", CourseList = courseList1 }
            };
            context.Degrees.AddOrUpdate(
              p => p.Id,
              new Degree { DegreeName = "Arts", CourseList = courseList },
              new Degree { DegreeName = "Science", CourseList = courseList1 }
            );
            context.SaveChanges();
            context.Students.AddOrUpdate(
              p => p.Id,
              new Student { Id = 1, StudentName = "swat", Degree = context.Degrees.FirstOrDefault(d => d.Id ==1 )},
              new Student { Id = 2, StudentName = "swat1", Degree = context.Degrees.FirstOrDefault(d => d.Id == 2) }
              //new Student { Id = 3, StudentName = "swat2", CourseList = courseList, Degree = new Degree { DegreeName = "Arts", CourseList = courseList } }
            );
        }
    }
}
