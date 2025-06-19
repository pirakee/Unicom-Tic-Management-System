using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unicom_Tic_Management_System.Models;
using Unicom_Tic_Management_System.Repositories;

namespace Unicom_Tic_Management_System.Views
{
    public partial class StudentForm : Form
    {
        private readonly StudentRepository studentRepo = new StudentRepository();
        private readonly CourseRepository courseRepo = new CourseRepository();
        private int selectedStudentId = -1;

        public StudentForm()
        {
            InitializeComponent();
            LoadCourses();
            LoadStudents();
        }

        private void LoadCourses()
        {
            try
            {
                cbCourse.DataSource = courseRepo.GetAllCourses();
                cbCourse.DisplayMember = "CourseName";
                cbCourse.ValueMember = "CourseID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading courses: " + ex.Message);
            }
        }

        private void LoadStudents()
        {
            try
            {
                dgvStudents.DataSource = studentRepo.GetAllStudents();
                dgvStudents.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading students: " + ex.Message);
            }
        }

        private void ClearForm()
        {
            txtStudentName.Clear();
            txtEmail.Clear();
            cbCourse.SelectedIndex = 0;
            selectedStudentId = -1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Student student = new Student
                {
                    StudentName = txtStudentName.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    CourseID = (int)cbCourse.SelectedValue
                };

                studentRepo.AddStudent(student);
                MessageBox.Show("Student added successfully.");
                LoadStudents();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding student: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedStudentId == -1)
            {
                MessageBox.Show("Please select a student to update.");
                return;
            }

            try
            {
                Student student = new Student
                {
                    StudentID = selectedStudentId,
                    StudentName = txtStudentName.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    CourseID = (int)cbCourse.SelectedValue
                };

                studentRepo.UpdateStudent(student);
                MessageBox.Show("Student updated successfully.");
                LoadStudents();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating student: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedStudentId == -1)
            {
                MessageBox.Show("Please select a student to delete.");
                return;
            }

            try
            {
                studentRepo.DeleteStudent(selectedStudentId);
                MessageBox.Show("Student deleted successfully.");
                LoadStudents();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting student: " + ex.Message);
            }
        }

        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedStudentId = Convert.ToInt32(dgvStudents.Rows[e.RowIndex].Cells["StudentID"].Value);
                txtStudentName.Text = dgvStudents.Rows[e.RowIndex].Cells["StudentName"].Value.ToString();
                txtEmail.Text = dgvStudents.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                cbCourse.SelectedValue = Convert.ToInt32(dgvStudents.Rows[e.RowIndex].Cells["CourseID"].Value);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
    

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void StudentForm_Load(object sender, EventArgs e)
        {

        }
    }
}
