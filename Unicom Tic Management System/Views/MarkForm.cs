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
    public partial class MarkForm : Form
    {
        private readonly MarkController markController = new MarkController();
        private readonly StudentRepository studentRepo = new StudentRepository();
        private readonly SubjectRepository subjectRepo = new SubjectRepository();
        private readonly ExamRepository examRepo = new ExamRepository();

        private int selectedMarkId = 0;

        public MarkForm()
        {
            InitializeComponent();
            LoadStudents();
            LoadSubjects();
            LoadExams();
            LoadMarks();
        }

        private void LoadStudents()
        {
            try
            {
                cbStudent.DataSource = studentRepo.GetAllStudents();
                cbStudent.DisplayMember = "FullName";
                cbStudent.ValueMember = "StudentID";
                cbStudent.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading students: " + ex.Message);
            }
        }

        private void LoadSubjects()
        {
            try
            {
                cbSubject.DataSource = subjectRepo.GetAllSubjects();
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
                cbExam.DataSource = examRepo.GetAllExams();
                cbExam.DisplayMember = "ExamDate";
                cbExam.ValueMember = "ExamID";
                cbExam.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading exams: " + ex.Message);
            }
        }

        private void LoadMarks()
        {
            try
            {
                dgvMarks.DataSource = markController.GetAllMarks();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading marks: " + ex.Message);
            }
        }

        private void ClearForm()
        {
            cbStudent.SelectedIndex = -1;
            cbSubject.SelectedIndex = -1;
            cbExam.SelectedIndex = -1;
            txtScore.Clear();
            selectedMarkId = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Mark mark = new Mark
                {
                    StudentID = Convert.ToInt32(cbStudent.SelectedValue),
                    SubjectID = Convert.ToInt32(cbSubject.SelectedValue),
                    ExamID = Convert.ToInt32(cbExam.SelectedValue),
                    Score = Convert.ToInt32(txtScore.Text.Trim())
                };

                markController.AddMark(mark);
                MessageBox.Show("Mark added successfully!");
                LoadMarks();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add failed: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedMarkId == 0)
            {
                MessageBox.Show("Please select a mark to update.");
                return;
            }

            try
            {
                Mark mark = new Mark
                {
                    MarkID = selectedMarkId,
                    StudentID = Convert.ToInt32(cbStudent.SelectedValue),
                    SubjectID = Convert.ToInt32(cbSubject.SelectedValue),
                    ExamID = Convert.ToInt32(cbExam.SelectedValue),
                    Score = Convert.ToInt32(txtScore.Text.Trim())
                };

                markController.UpdateMark(mark);
                MessageBox.Show("Mark updated successfully!");
                LoadMarks();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update failed: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedMarkId == 0)
            {
                MessageBox.Show("Please select a mark to delete.");
                return;
            }

            if (MessageBox.Show("Are you sure to delete this mark?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    markController.DeleteMark(selectedMarkId);
                    MessageBox.Show("Mark deleted successfully!");
                    LoadMarks();
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

        private void dgvMarks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMarks.Rows[e.RowIndex];

                selectedMarkId = Convert.ToInt32(row.Cells["MarkID"].Value);
                cbStudent.SelectedValue = Convert.ToInt32(row.Cells["StudentID"].Value);
                cbSubject.SelectedValue = Convert.ToInt32(row.Cells["SubjectID"].Value);
                cbExam.SelectedValue = Convert.ToInt32(row.Cells["ExamID"].Value);
                txtScore.Text = row.Cells["Score"].Value.ToString();
            }
        }

        private void MarkForm_Load(object sender, EventArgs e)
        {

        }
    }
}
