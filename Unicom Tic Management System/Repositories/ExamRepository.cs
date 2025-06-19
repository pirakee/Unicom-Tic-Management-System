using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicom_Tic_Management_System.Models;

namespace Unicom_Tic_Management_System.Repositories
{
    public class ExamRepository
    {
        private readonly string connectionString = "Data Source=unicom.db;Version=3;";

        public List<Exam> GetAllExams()
        {
            List<Exam> exams = new List<Exam>();

            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            {
                string query = @"SELECT e.ExamID, e.CourseID, e.SubjectID, e.ExamDate, e.Time, e.Room,
                                        c.CourseName, s.SubjectName
                                 FROM Exams e
                                 JOIN Courses c ON e.CourseID = c.CourseID
                                 JOIN Subjects s ON e.SubjectID = s.SubjectID";

                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    con.Open();
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            exams.Add(new Exam
                            {
                                ExamID = Convert.ToInt32(reader["ExamID"]),
                                CourseID = Convert.ToInt32(reader["CourseID"]),
                                SubjectID = Convert.ToInt32(reader["SubjectID"]),
                                ExamDate = Convert.ToDateTime(reader["ExamDate"]),
                                Time = reader["Time"].ToString(),
                                Room = reader["Room"].ToString(),
                                CourseName = reader["CourseName"].ToString(),
                                SubjectName = reader["SubjectName"].ToString()
                            });
                        }
                    }
                }
            }

            return exams;
        }

        public void AddExam(Exam exam)
        {
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            {
                string query = @"INSERT INTO Exams (CourseID, SubjectID, ExamDate, Time, Room)
                                 VALUES (@courseID, @subjectID, @examDate, @time, @room)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@courseID", exam.CourseID);
                    cmd.Parameters.AddWithValue("@subjectID", exam.SubjectID);
                    cmd.Parameters.AddWithValue("@examDate", exam.ExamDate);
                    cmd.Parameters.AddWithValue("@time", exam.Time);
                    cmd.Parameters.AddWithValue("@room", exam.Room);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateExam(Exam exam)
        {
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            {
                string query = @"UPDATE Exams 
                                 SET CourseID = @courseID, SubjectID = @subjectID, ExamDate = @examDate, Time = @time, Room = @room 
                                 WHERE ExamID = @examID";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@courseID", exam.CourseID);
                    cmd.Parameters.AddWithValue("@subjectID", exam.SubjectID);
                    cmd.Parameters.AddWithValue("@examDate", exam.ExamDate);
                    cmd.Parameters.AddWithValue("@time", exam.Time);
                    cmd.Parameters.AddWithValue("@room", exam.Room);
                    cmd.Parameters.AddWithValue("@examID", exam.ExamID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteExam(int examId)
        {
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            {
                string query = "DELETE FROM Exams WHERE ExamID = @examID";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@examID", examId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
