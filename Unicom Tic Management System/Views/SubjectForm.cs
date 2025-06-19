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
    public partial class SubjectForm : Form
    {
        private readonly SubjectRepository subjectRepo = new SubjectRepository();
        private readonly CourseRepository courseRepo = new CourseRepository();
        private int selectedSubjectId = -1;

        public SubjectForm()
        {
            InitializeComponent();
            LoadCourses();
            LoadSubjects();
        }

        private void LoadCourses()
        {
            try
            {
                var courses = courseRepo.GetAllCourses();
                cbCourse.DataSource = courses;
                cbCourse.DisplayMember = "CourseName";
                cbCourse.ValueMember = "CourseID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading courses: " + ex.Message);
            }
        }

        private void LoadSubjects()
        {
            try
            {
                dgvSubjects.DataSource = subjectRepo.GetAllSubjects();
                dgvSubjects.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading subjects: " + ex.Message);
            }
        }

        private void ClearForm()
        {
            txtSubjectName.Clear();
            cbCourse.SelectedIndex = 0;
            selectedSubjectId = -1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Subject subject = new Subject
                {
                    SubjectName = txtSubjectName.Text.Trim(),
                    CourseID = (int)cbCourse.SelectedValue
                };

                subjectRepo.AddSubject(subject);
                MessageBox.Show("Subject added successfully.");
                LoadSubjects();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding subject: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedSubjectId == -1)
            {
                MessageBox.Show("Please select a subject to update.");
                return;
            }

            try
            {
                Subject subject = new Subject
                {
                    SubjectID = selectedSubjectId,
                    SubjectName = txtSubjectName.Text.Trim(),
                    CourseID = (int)cbCourse.SelectedValue
                };

                subjectRepo.UpdateSubject(subject);
                MessageBox.Show("Subject updated successfully.");
                LoadSubjects();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating subject: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedSubjectId == -1)
            {
                MessageBox.Show("Please select a subject to delete.");
                return;
            }

            try
            {
                subjectRepo.DeleteSubject(selectedSubjectId);
                MessageBox.Show("Subject deleted successfully.");
                LoadSubjects();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting subject: " + ex.Message);
            }
        }

        private void dgvSubjects_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedSubjectId = Convert.ToInt32(dgvSubjects.Rows[e.RowIndex].Cells["SubjectID"].Value);
                txtSubjectName.Text = dgvSubjects.Rows[e.RowIndex].Cells["SubjectName"].Value.ToString();
                cbCourse.SelectedValue = Convert.ToInt32(dgvSubjects.Rows[e.RowIndex].Cells["CourseID"].Value);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }


        private void SubjectForm_Load(object sender, EventArgs e)
        {

        }
    }
}
