using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Unicom_Tic_Management_System.Views
{
    public partial class CourseForm : Form
    {
        private string connectionString = "Data Source=unicom.db;Version=3;";

        public CourseForm()
        {
            InitializeComponent();
            LoadCourses();
        }

        private void LoadCourses()
        {
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT * FROM Courses";
                    SQLiteDataAdapter da = new SQLiteDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvCourses.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading courses: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCourseName.Text))
            {
                MessageBox.Show("Please enter a course name.");
                return;
            }

            try
            {
                using (SQLiteConnection con = new SQLiteConnection(connectionString))
                {
                    con.Open();
                    string query = "INSERT INTO Courses (CourseName) VALUES (@name)";
                    SQLiteCommand cmd = new SQLiteCommand(query, con);
                    cmd.Parameters.AddWithValue("@name", txtCourseName.Text.Trim());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Course added successfully.");
                    LoadCourses();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding course: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCourseID.Text) || string.IsNullOrWhiteSpace(txtCourseName.Text))
            {
                MessageBox.Show("Please select a course to update.");
                return;
            }

            try
            {
                using (SQLiteConnection con = new SQLiteConnection(connectionString))
                {
                    con.Open();
                    string query = "UPDATE Courses SET CourseName = @name WHERE CourseID = @id";
                    SQLiteCommand cmd = new SQLiteCommand(query, con);
                    cmd.Parameters.AddWithValue("@name", txtCourseName.Text.Trim());
                    cmd.Parameters.AddWithValue("@id", txtCourseID.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Course updated successfully.");
                    LoadCourses();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating course: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCourseID.Text))
            {
                MessageBox.Show("Please select a course to delete.");
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this course?", "Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.No) return;

            try
            {
                using (SQLiteConnection con = new SQLiteConnection(connectionString))
                {
                    con.Open();
                    string query = "DELETE FROM Courses WHERE CourseID = @id";
                    SQLiteCommand cmd = new SQLiteCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", txtCourseID.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Course deleted successfully.");
                    LoadCourses();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting course: " + ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtCourseID.Clear();
            txtCourseName.Clear();
        }

        private void dgvCourses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtCourseID.Text = dgvCourses.Rows[e.RowIndex].Cells["CourseID"].Value.ToString();
                txtCourseName.Text = dgvCourses.Rows[e.RowIndex].Cells["CourseName"].Value.ToString();
            }
        }
    

        private void CourseForm_Load(object sender, EventArgs e)
        {

        }
    }
}
