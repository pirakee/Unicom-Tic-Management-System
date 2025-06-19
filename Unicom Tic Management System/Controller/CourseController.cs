using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Unicom_Tic_Management_System.Controller
{
    public class CourseController
    {
        private readonly string connectionString = "Data Source=unicom.db;Version=3;";

        // Get all courses
        public DataTable GetAllCourses()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT * FROM Courses";
                    using (SQLiteDataAdapter da = new SQLiteDataAdapter(query, con))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error loading courses: " + ex.Message);
            }
            return dt;
        }

        // Add a new course
        public void AddCourse(string courseName)
        {
            if (string.IsNullOrWhiteSpace(courseName))
                throw new ArgumentException("Course name cannot be empty.");

            try
            {
                using (SQLiteConnection con = new SQLiteConnection(connectionString))
                {
                    con.Open();
                    string query = "INSERT INTO Courses (CourseName) VALUES (@name)";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@name", courseName.Trim());
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding course: " + ex.Message);
            }
        }

        // Update existing course
        public void UpdateCourse(int courseId, string courseName)
        {
            if (string.IsNullOrWhiteSpace(courseName))
                throw new ArgumentException("Course name cannot be empty.");

            try
            {
                using (SQLiteConnection con = new SQLiteConnection(connectionString))
                {
                    con.Open();
                    string query = "UPDATE Courses SET CourseName = @name WHERE CourseID = @id";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@name", courseName.Trim());
                        cmd.Parameters.AddWithValue("@id", courseId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating course: " + ex.Message);
            }
        }

        // Delete course
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
