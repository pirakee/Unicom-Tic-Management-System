using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicom_Tic_Management_System.Models
{
    public class Subject
    {
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public int CourseID { get; set; }

        // Optional constructor
        public Subject() { }

        public Subject(int id, string name, int courseId)
        {
            SubjectID = id;
            SubjectName = name;
            CourseID = courseId;
        }

        public override string ToString()
        {
            return $"{SubjectName}";
        }
    }
}

