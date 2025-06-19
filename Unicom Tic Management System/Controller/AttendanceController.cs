using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unicom_Tic_Management_System.Models;
using Unicom_Tic_Management_System.Repositories;

namespace Unicom_Tic_Management_System.Controller
{
    public class AttendanceController
    {
        private readonly AttendanceRepository attendanceRepo;

        public AttendanceController()
        {
            attendanceRepo = new AttendanceRepository();
        }

        public void AddAttendance(Attendance attendance)
        {
            try
            {
                if (attendance.StudentID == 0 || attendance.SubjectID == 0 || string.IsNullOrWhiteSpace(attendance.Status))
                {
                    MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                attendanceRepo.AddAttendance(attendance);
                MessageBox.Show("Attendance recorded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while adding attendance: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<Attendance> GetAllAttendance()
        {
            try
            {
                return attendanceRepo.GetAllAttendance();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving attendance records: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Attendance>();
            }
        }

        public List<Attendance> GetAttendanceByStudent(int studentId)
        {
            try
            {
                return attendanceRepo.GetAttendanceByStudent(studentId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving student attendance: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Attendance>();
            }
        }
    }
}
