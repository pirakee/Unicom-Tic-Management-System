using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTICManagementSystem.Controllers;
using UnicomTICManagementSystem.Models;

namespace Unicom_Tic_Management_System.Views
{
    public partial class MarkForm : Form
    {
        private List<Student> students;
        private List<Exam> exams; 

        public MarkForm()
        {
            InitializeComponent();
            LoadStudents();
            LoadExams();
            LoadMarks();
        }

        private void LoadStudents()
        {
            students = StudentController.GetAllStudents();
            cmbStudent.DataSource = students;
            cmbStudent.DisplayMember = "Name";
            cmbStudent.ValueMember = "StudentID";
        }

        private void LoadExams()
        {
            exams = ExamController.GetAllExams();
            cmbExam.DataSource = exams;
            cmbExam.DisplayMember = "ExamName";
            cmbExam.ValueMember = "ExamID";
        }

        private void LoadMarks()
        {
            dgvMarks.DataSource = MarkController.GetAllMarks();
            dgvMarks.Columns["MarkID"].Visible = false;
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtScore.Text.Trim(), out int score) || score < 0 || score > 100)
            {
                MessageBox.Show("Score must be a number between 0 and 100.");
                return;
            }

            int studentId = (int)cmbStudent.SelectedValue;
            int examId = (int)cmbExam.SelectedValue;

            MarkController.AddMark(studentId, examId, score);
            LoadMarks();
            txtScore.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvMarks.SelectedRows.Count > 0 && int.TryParse(txtScore.Text.Trim(), out int score))
            {
                int markId = Convert.ToInt32(dgvMarks.SelectedRows[0].Cells["MarkID"].Value);
                int studentId = (int)cmbStudent.SelectedValue;
                int examId = (int)cmbExam.SelectedValue;

                MarkController.UpdateMark(markId, studentId, examId, score);
                LoadMarks();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMarks.SelectedRows.Count > 0)
            {
                int markId = Convert.ToInt32(dgvMarks.SelectedRows[0].Cells["MarkID"].Value);
                MarkController.DeleteMark(markId);
                LoadMarks();
            }
        }

        private void dgvMarks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                cmbStudent.SelectedValue = Convert.ToInt32(dgvMarks.Rows[e.RowIndex].Cells["StudentID"].Value);
                cmbExam.SelectedValue = Convert.ToInt32(dgvMarks.Rows[e.RowIndex].Cells["ExamID"].Value);
                txtScore.Text = dgvMarks.Rows[e.RowIndex].Cells["Score"].Value.ToString();
            }
        }

        private void MarkForm_Load(object sender, EventArgs e)
        {

        }

        private void cmbStudent_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //private void InitializeComponent()
        //{
        //    throw new NotImplementedException();
        //}

        //private void MarkForm_Load(object sender, EventArgs e)
        //{

        //}
    }
}
