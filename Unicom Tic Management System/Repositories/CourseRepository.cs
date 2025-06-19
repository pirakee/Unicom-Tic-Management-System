using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicom_Tic_Management_System.Models;

namespace Unicom_Tic_Management_System.Repositories
{
    public class CourseRepository
    {
        private readonly string connectionString = "Data Source=unicom.db;Version=3;";

        // Get all courses as a list
        public List<Course> GetAllCourses()
        {
            List<Course> courses = new List<Course>();

            try
            {
                using (SQLiteConnection con = new SQLiteConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT * FROM Courses";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            courses.Add(new Course
                            {
                                CourseID = Convert.ToInt32(reader["CourseID"]),
                                CourseName = reader["CourseName"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching courses: " + ex.Message);
            }

            return courses;
        }

        // Add a course
        public void AddCourse(Course course)
        {
            if (string.IsNullOrWhiteSpace(course.CourseName))
                throw new ArgumentException("Course name cannot be empty.");

            try
            {
                using (SQLiteConnection con = new SQLiteConnection(connectionString))
                {
                    con.Open();
                    string query = "INSERT INTO Courses (CourseName) VALUES (@name)";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@name", course.CourseName.Trim());
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding course: " + ex.Message);
            }
        }

        // Update a course
        public void UpdateCourse(Course course)
        {
            if (string.IsNullOrWhiteSpace(course.CourseName))
                throw new ArgumentException("Course name cannot be empty.");

            try
            {
                using (SQLiteConnection con = new SQLiteConnection(connectionString))
                {
                    con.Open();
                    string query = "UPDATE Courses SET CourseName = @name WHERE CourseID = @id";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@name", course.CourseName.Trim());
                        cmd.Parameters.AddWithValue("@id", course.CourseID);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating course: " + ex.Message);
            }
        }

        // Delete a course
        public void DeleteCourse(int courseId)
        {
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(connectionString))
                {
                    con.Open();
                    string query = "DELETE FROM Courses WHERE CourseID = @id";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", courseId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting course: " + ex.Message);
            }
        }
    }
}
