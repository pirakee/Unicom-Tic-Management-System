using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicom_Tic_Management_System.Models
{
    public class Student
    {
        public int StudentID { get; set; }         // Primary Key
        public string StudentName { get; set; }    // Full Name
        public string Email { get; set; }          // Email ID
        public int CourseID { get; set; }          // Foreign Key to Course
        public string CourseName { get; set; }     // Optional: for display (JOIN result)
    }
}
