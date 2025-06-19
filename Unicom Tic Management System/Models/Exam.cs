using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicom_Tic_Management_System.Models
{
    public class Exam
    {
        public int ExamID { get; set; }           // Primary Key
        public int CourseID { get; set; }         // Foreign Key to Course
        public int SubjectID { get; set; }        // Foreign Key to Subject
        public string CourseName { get; set; }    // For display purposes
        public string SubjectName { get; set; }   // For display purposes
        public DateTime ExamDate { get; set; }    // Date of the exam
        public string Time { get; set; }          // Time of the exam
        public string Room { get; set; }          // Exam Room/Lab
    }
}
