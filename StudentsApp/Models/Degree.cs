using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentsApp.Models
{
    public class Degree
    {
        [Key]
        public int Id { get; set; }
        public string DegreeName { get; set; }

        public List<Course> CourseList { get; set; }
        public List<Student> Students { get; set; }
    }
}