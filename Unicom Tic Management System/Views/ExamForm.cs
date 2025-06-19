using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unicom_Tic_Management_System.Controller;
using Unicom_Tic_Management_System.Models;
using Unicom_Tic_Management_System.Repositories;

namespace Unicom_Tic_Management_System.Views
{
    public partial class ExamForm : Form
    {
        private readonly ExamController examController = new ExamController();
        private readonly CourseRepository courseRepo = new CourseRepository();
        private readonly SubjectRepository subjectRepo = new SubjectRepository();

        private int selectedExamId = 0;

        public ExamForm()
        {
            InitializeComponent();
            LoadCourses();
            LoadExams();
        }

        private void LoadCourses()
        {
            try
            {
                var courses = courseRepo.GetAllCourses();
                cbCourse.DataSource = courses;
                cbCourse.DisplayMember = "CourseName";
                cbCourse.ValueMember = "CourseID";
                cbCourse.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading courses: " + ex.Message);
            }
        }

        private void LoadSubjects(int courseId)
        {
            try
            {
                var subjects = subjectRepo.GetSubjectsByCourse(courseId);
                cbSubject.DataSource = subjects;
                cbSubject.DisplayMember = "SubjectName";
                cbSubject.ValueMember = "SubjectID";
                cbSubject.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading subjects: " + ex.Message);
            }
        }

        private void LoadExams()
        {
            try
            {
                var exams = examController.GetAllExams();
                dgvExams.DataSource = exams;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading exams: " + ex.Message);
            }
        }

        private void ClearForm()
        {
            cbCourse.SelectedIndex = -1;
            cbSubject.SelectedIndex = -1;
            dtpExamDate.Value = DateTime.Today;
            txtTime.Clear();
            txtRoom.Clear();
            selectedExamId = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Exam exam = new Exam
                {
                    CourseID = Convert.ToInt32(cbCourse.SelectedValue),
                    SubjectID = Convert.ToInt32(cbSubject.SelectedValue),
                    ExamDate = dtpExamDate.Value,
                    Time = txtTime.Text.Trim(),
                    Room = txtRoom.Text.Trim()
                };

                examController.AddExam(exam);
                MessageBox.Show("Exam added successfully!");
                LoadExams();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add failed: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedExamId == 0)
            {
                MessageBox.Show("Please select an exam to update.");
                return;
            }

            try
            {
                Exam exam = new Exam
                {
                    ExamID = selectedExamId,
                    CourseID = Convert.ToInt32(cbCourse.SelectedValue),
                    SubjectID = Convert.ToInt32(cbSubject.SelectedValue),
                    ExamDate = dtpExamDate.Value,
                    Time = txtTime.Text.Trim(),
                    Room = txtRoom.Text.Trim()
                };

                examController.UpdateExam(exam);
                MessageBox.Show("Exam updated successfully!");
                LoadExams();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update failed: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedExamId == 0)
            {
                MessageBox.Show("Please select an exam to delete.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this exam?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    examController.DeleteExam(selectedExamId);
                    MessageBox.Show("Exam deleted successfully!");
                    LoadExams();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Delete failed: " + ex.Message);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void dgvExams_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvExams.Rows[e.RowIndex];

                selectedExamId = Convert.ToInt32(row.Cells["ExamID"].Value);
                cbCourse.SelectedValue = Convert.ToInt32(row.Cells["CourseID"].Value);
                cbSubject.SelectedValue = Convert.ToInt32(row.Cells["SubjectID"].Value);
                dtpExamDate.Value = Convert.ToDateTime(row.Cells["ExamDate"].Value);
                txtTime.Text = row.Cells["Time"].Value.ToString();
                txtRoom.Text = row.Cells["Room"].Value.ToString();
            }
        }

        private void cbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCourse.SelectedIndex >= 0)
            {
                int courseId = Convert.ToInt32(cbCourse.SelectedValue);
                LoadSubjects(courseId);
            }
        }

        private void ExamForm_Load(object sender, EventArgs e)
        {

        }
    }
}
