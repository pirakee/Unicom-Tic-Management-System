using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicom_Tic_Management_System.Models
{
    public class Timetable
    {
        public int TimetableID { get; set; }
        public int CourseID { get; set; }
        public int SubjectID { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
        public int RoomID { get; set; }

        // Extra for display (optional but useful)
        public string CourseName { get; set; }
        public string SubjectName { get; set; }
        public string RoomName { get; set; }
    }
}
