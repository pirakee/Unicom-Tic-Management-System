using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicom_Tic_Management_System.Models;

namespace Unicom_Tic_Management_System.Repositories
{
    public class SubjectRepository
    {
        private readonly string connectionString = "Data Source=unicom.db;Version=3;";

        // Get all subjects
        public List<Subject> GetAllSubjects()
        {
            List<Subject> subjects = new List<Subject>();

            try
            {
                using (SQLiteConnection con = new SQLiteConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT * FROM Subjects";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            subjects.Add(new Subject
                            {
                                SubjectID = Convert.ToInt32(reader["SubjectID"]),
                                SubjectName = reader["SubjectName"].ToString(),
                                CourseID = Convert.ToInt32(reader["CourseID"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error loading subjects: " + ex.Message);
            }

            return subjects;
        }

        // Get subjects by course
        public List<Subject> GetSubjectsByCourse(int courseId)
        {
            List<Subject> subjects = new List<Subject>();

            try
            {
                using (SQLiteConnection con = new SQLiteConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT * FROM Subjects WHERE CourseID = @courseId";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@courseId", courseId);
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                subjects.Add(new Subject
                                {
                                    SubjectID = Convert.ToInt32(reader["SubjectID"]),
                                    SubjectName = reader["SubjectName"].ToString(),
                                    CourseID = Convert.ToInt32(reader["CourseID"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error filtering subjects: " + ex.Message);
            }

            return subjects;
        }

        // Add subject
        public void AddSubject(Subject subject)
        {
            if (string.IsNullOrWhiteSpace(subject.SubjectName))
                throw new ArgumentException("Subject name cannot be empty.");

            try
            {
                using (SQLiteConnection con = new SQLiteConnection(connectionString))
                {
                    con.Open();
                    string query = "INSERT INTO Subjects (SubjectName, CourseID) VALUES (@name, @courseId)";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@name", subject.SubjectName.Trim());
                        cmd.Parameters.AddWithValue("@courseId", subject.CourseID);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding subject: " + ex.Message);
            }
        }

        // Update subject
        public void UpdateSubject(Subject subject)
        {
            if (string.IsNullOrWhiteSpace(subject.SubjectName))
                throw new ArgumentException("Subject name cannot be empty.");

            try
            {
                using (SQLiteConnection con = new SQLiteConnection(connectionString))
                {
                    con.Open();
                    string query = "UPDATE Subjects SET SubjectName = @name, CourseID = @courseId WHERE SubjectID = @id";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@name", subject.SubjectName.Trim());
                        cmd.Parameters.AddWithValue("@courseId", subject.CourseID);
                        cmd.Parameters.AddWithValue("@id", subject.SubjectID);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating subject: " + ex.Message);
            }
        }

        // Delete subject
        public void DeleteSubject(int subjectId)
        {
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(connectionString))
                {
                    con.Open();
                    string query = "DELETE FROM Subjects WHERE SubjectID = @id";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", subjectId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting subject: " + ex.Message);
            }
        }
    }
}
