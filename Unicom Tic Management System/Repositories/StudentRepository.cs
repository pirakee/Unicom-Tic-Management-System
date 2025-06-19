using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicom_Tic_Management_System.Models;

namespace Unicom_Tic_Management_System.Repositories
{
    public class StudentRepository
    {
        private readonly string connectionString = "Data Source=unicom.db;Version=3;";

        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();

            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            {
                string query = @"SELECT s.StudentID, s.StudentName, s.Email, s.CourseID, c.CourseName
                                 FROM Students s
                                 INNER JOIN Courses c ON s.CourseID = c.CourseID";

                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    con.Open();
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            students.Add(new Student
                            {
                                StudentID = Convert.ToInt32(reader["StudentID"]),
                                StudentName = reader["StudentName"].ToString(),
                                Email = reader["Email"].ToString(),
                                CourseID = Convert.ToInt32(reader["CourseID"]),
                                CourseName = reader["CourseName"].ToString()
                            });
                        }
                    }
                }
            }

            return students;
        }

        public void AddStudent(Student student)
        {
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            {
                string query = "INSERT INTO Students (StudentName, Email, CourseID) VALUES (@name, @email, @courseId)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@name", student.StudentName);
                    cmd.Parameters.AddWithValue("@email", student.Email);
                    cmd.Parameters.AddWithValue("@courseId", student.CourseID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateStudent(Student student)
        {
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            {
                string query = "UPDATE Students SET StudentName = @name, Email = @email, CourseID = @courseId WHERE StudentID = @id";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@name", student.StudentName);
                    cmd.Parameters.AddWithValue("@email", student.Email);
                    cmd.Parameters.AddWithValue("@courseId", student.CourseID);
                    cmd.Parameters.AddWithValue("@id", student.StudentID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteStudent(int studentId)
        {
            using (SQLiteConnection con = new SQLiteConnection(connectionString))
            {
                string query = "DELETE FROM Students WHERE StudentID = @id";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", studentId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
