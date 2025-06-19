using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicom_Tic_Management_System.Models;

namespace Unicom_Tic_Management_System.Repositories
{
    public class MarkRepository
    {
        private readonly string connectionString = "Data Source=unicom.db;Version=3;";

        public List<Mark> GetAllMarks()
        {
            var marks = new List<Mark>();

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = @"
                    SELECT m.MarkID, m.StudentID, m.SubjectID, m.ExamID, m.Score,
                           s.FullName AS StudentName, sb.SubjectName, c.CourseName, e.ExamDate
                    FROM Marks m
                    INNER JOIN Students s ON m.StudentID = s.StudentID
                    INNER JOIN Subjects sb ON m.SubjectID = sb.SubjectID
                    INNER JOIN Exams e ON m.ExamID = e.ExamID
                    INNER JOIN Courses c ON sb.CourseID = c.CourseID
                    ORDER BY e.ExamDate DESC;
                ";

                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        marks.Add(new Mark
                        {
                            MarkID = Convert.ToInt32(reader["MarkID"]),
                            StudentID = Convert.ToInt32(reader["StudentID"]),
                            SubjectID = Convert.ToInt32(reader["SubjectID"]),
                            ExamID = Convert.ToInt32(reader["ExamID"]),
                            Score = Convert.ToInt32(reader["Score"]),
                            StudentName = reader["StudentName"].ToString(),
                            SubjectName = reader["SubjectName"].ToString(),
                            CourseName = reader["CourseName"].ToString(),
                            ExamDate = Convert.ToDateTime(reader["ExamDate"])
                        });
                    }
                }
            }

            return marks;
        }

        public void AddMark(Mark mark)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO Marks (StudentID, SubjectID, ExamID, Score) VALUES (@StudentID, @SubjectID, @ExamID, @Score)";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentID", mark.StudentID);
                    cmd.Parameters.AddWithValue("@SubjectID", mark.SubjectID);
                    cmd.Parameters.AddWithValue("@ExamID", mark.ExamID);
                    cmd.Parameters.AddWithValue("@Score", mark.Score);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateMark(Mark mark)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = "UPDATE Marks SET StudentID = @StudentID, SubjectID = @SubjectID, ExamID = @ExamID, Score = @Score WHERE MarkID = @MarkID";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentID", mark.StudentID);
                    cmd.Parameters.AddWithValue("@SubjectID", mark.SubjectID);
                    cmd.Parameters.AddWithValue("@ExamID", mark.ExamID);
                    cmd.Parameters.AddWithValue("@Score", mark.Score);
                    cmd.Parameters.AddWithValue("@MarkID", mark.MarkID);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void DeleteMark(int markId)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = "DELETE FROM Marks WHERE MarkID = @MarkID";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MarkID", markId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
