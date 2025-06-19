using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicom_Tic_Management_System.Controller;

using Unicom_Tic_Management_System.Helpers;
using Unicom_Tic_Management_System.Models;

namespace Unicom_Tic_Management_System.Repositories
{
    public class AttendanceRepository
    {
        public void AddAttendance(Attendance attendance)
        {
            using (var con = DBConnection.GetConnection())
            {
                con.Open();
                string query = "INSERT INTO Attendance (StudentID, SubjectID, Date, Status) VALUES (@studentId, @subjectId, @date, @status)";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@studentId", attendance.StudentID);
                    cmd.Parameters.AddWithValue("@subjectId", attendance.SubjectID);
                    cmd.Parameters.AddWithValue("@date", attendance.Date);
                    cmd.Parameters.AddWithValue("@status", attendance.Status);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Attendance> GetAttendanceByStudent(int studentId)
        {
            var list = new List<Attendance>();
            using (var con = DBConnection.GetConnection())
            {
                con.Open();
                string query = "SELECT * FROM Attendance WHERE StudentID = @id";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", studentId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Attendance
                            {
                                AttendanceID = Convert.ToInt32(reader["AttendanceID"]),
                                StudentID = Convert.ToInt32(reader["StudentID"]),
                                SubjectID = Convert.ToInt32(reader["SubjectID"]),
                                Date = reader["Date"].ToString(),
                                Status = reader["Status"].ToString()
                            });
                        }
                    }
                }
            }
            return list;
        }

        public List<Attendance> GetAllAttendance()
        {
            var list = new List<Attendance>();
            using (var con = DBConnection.GetConnection())
            {
                con.Open();
                string query = "SELECT * FROM Attendance";
                using (var cmd = new SQLiteCommand(query, con))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Attendance
                        {
                            AttendanceID = Convert.ToInt32(reader["AttendanceID"]),
                            StudentID = Convert.ToInt32(reader["StudentID"]),
                            SubjectID = Convert.ToInt32(reader["SubjectID"]),
                            Date = reader["Date"].ToString(),
                            Status = reader["Status"].ToString()
                        });
                    }
                }
            }
            return list;
        }
    }
}
