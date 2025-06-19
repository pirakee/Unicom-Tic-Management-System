using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicom_Tic_Management_System.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }

        // Optional constructor
        public Course() { }

        public Course(int id, string name)
        {
            CourseID = id;
            CourseName = name;
        }

        public override string ToString()
        {
            return $"{CourseID} - {CourseName}";
        }
    }
}
