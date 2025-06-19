using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicom_Tic_Management_System.Models
{
    public class Mark
    {
        public int MarkID { get; set; }             // Primary Key
        public int StudentID { get; set; }          // Foreign Key to Student
        public int SubjectID { get; set; }          // Foreign Key to Subject
        public int ExamID { get; set; }             // Foreign Key to Exam
        public int Score { get; set; }              // Mark scored by student

        // Optional Display Fields (useful when joining for DataGridView)
        public string StudentName { get; set; }
        public string SubjectName { get; set; }
        public string CourseName { get; set; }
        public DateTime ExamDate { get; set; }
    }
}
