using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicom_Tic_Management_System.Controller;
using Unicom_Tic_Management_System.Helpers;
using Unicom_Tic_Management_System.Models;

namespace Unicom_Tic_Management_System.Repositories
{
    public class TimetableRepository
    {
        public void AddTimetable(Timetable timetable)
        {
            using (var con = DBConnection.GetConnection())
            {
                con.Open();
                string query = @"INSERT INTO Timetables (CourseID, SubjectID, Day, Time, RoomID)
                                 VALUES (@CourseID, @SubjectID, @Day, @Time, @RoomID)";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@CourseID", timetable.CourseID);
                    cmd.Parameters.AddWithValue("@SubjectID", timetable.SubjectID);
                    cmd.Parameters.AddWithValue("@Day", timetable.Day);
                    cmd.Parameters.AddWithValue("@Time", timetable.Time);
                    cmd.Parameters.AddWithValue("@RoomID", timetable.RoomID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateTimetable(Timetable timetable)
        {
            using (var con = DBConnection.GetConnection())
            {
                con.Open();
                string query = @"UPDATE Timetables SET 
                                    CourseID = @CourseID,
                                    SubjectID = @SubjectID,
                                    Day = @Day,
                                    Time = @Time,
                                    RoomID = @RoomID
                                 WHERE TimetableID = @TimetableID";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@CourseID", timetable.CourseID);
                    cmd.Parameters.AddWithValue("@SubjectID", timetable.SubjectID);
                    cmd.Parameters.AddWithValue("@Day", timetable.Day);
                    cmd.Parameters.AddWithValue("@Time", timetable.Time);
                    cmd.Parameters.AddWithValue("@RoomID", timetable.RoomID);
                    cmd.Parameters.AddWithValue("@TimetableID", timetable.TimetableID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteTimetable(int timetableID)
        {
            using (var con = DBConnection.GetConnection())
            {
                con.Open();
                string query = "DELETE FROM Timetables WHERE TimetableID = @TimetableID";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@TimetableID", timetableID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Timetable> GetAllTimetables()
        {
            List<Timetable> list = new List<Timetable>();

            using (var con = DBConnection.GetConnection())
            {
                con.Open();
                string query = @"
                    SELECT t.TimetableID, t.Day, t.Time,
                           t.CourseID, c.CourseName,
                           t.SubjectID, s.SubjectName,
                           t.RoomID, r.RoomName
                    FROM Timetables t
                    JOIN Courses c ON t.CourseID = c.CourseID
                    JOIN Subjects s ON t.SubjectID = s.SubjectID
                    JOIN Rooms r ON t.RoomID = r.RoomID
                    ORDER BY t.Day, t.Time";

                using (var cmd = new SQLiteCommand(query, con))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Timetable
                        {
                            TimetableID = Convert.ToInt32(reader["TimetableID"]),
                            CourseID = Convert.ToInt32(reader["CourseID"]),
                            CourseName = reader["CourseName"].ToString(),
                            SubjectID = Convert.ToInt32(reader["SubjectID"]),
                            SubjectName = reader["SubjectName"].ToString(),
                            Day = reader["Day"].ToString(),
                            Time = reader["Time"].ToString(),
                            RoomID = Convert.ToInt32(reader["RoomID"]),
                            RoomName = reader["RoomName"].ToString()
                        });
                    }
                }
            }

            return list;
        }

        public Timetable GetTimetableById(int id)
        {
            Timetable timetable = null;

            using (var con = DBConnection.GetConnection())
            {
                con.Open();
                string query = "SELECT * FROM Timetables WHERE TimetableID = @TimetableID";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@TimetableID", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            timetable = new Timetable
                            {
                                TimetableID = Convert.ToInt32(reader["TimetableID"]),
                                CourseID = Convert.ToInt32(reader["CourseID"]),
                                SubjectID = Convert.ToInt32(reader["SubjectID"]),
                                Day = reader["Day"].ToString(),
                                Time = reader["Time"].ToString(),
                                RoomID = Convert.ToInt32(reader["RoomID"])
                            };
                        }
                    }
                }
            }

            return timetable;
        }
    }
}
