using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Unicom_Tic_Management_System.Views
{
    public partial class MainForm : Form
    {
        private string userRole;

        public MainForm(string role)
        {
            InitializeComponent();
            userRole = role;
            lblWelcome.Text = "Welcome: " + role;
            CustomizeViewBasedOnRole(role);
        }

        private void CustomizeViewBasedOnRole(string role)
        {
            // Basic visibility control (example)
            if (role == "Student")
            {
                btnCourses.Visible = false;
                btnSubjects.Visible = false;
                btnStudents.Visible = false;
                btnExams.Visible = true;
                btnMarks.Visible = true;
                btnTimetable.Visible = true;
            }
            else if (role == "Lecturer")
            {
                btnCourses.Visible = false;
                btnSubjects.Visible = true;
                btnStudents.Visible = true;
                btnExams.Visible = true;
                btnMarks.Visible = true;
                btnTimetable.Visible = true;
            }
            else if (role == "Staff")
            {
                btnCourses.Visible = true;
                btnSubjects.Visible = true;
                btnStudents.Visible = true;
                btnExams.Visible = true;
                btnMarks.Visible = true;
                btnTimetable.Visible = true;
            }
            else if (role == "Admin")
            {
                // Admin sees everything
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

       // You can handle button clicks here to open other forms
        private void btnCourses_Click(object sender, EventArgs e)
        {
            CourseForm courseForm = new CourseForm();
            courseForm.ShowDialog();
        }

        private void btnSubjects_Click(object sender, EventArgs e)
        {
            SubjectForm subjectForm = new SubjectForm();
            subjectForm.ShowDialog();
        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
            StudentForm studentForm = new StudentForm();
            studentForm.ShowDialog();
        }

        //private void btnExams_Click(object sender, EventArgs e)
        //{
        //    ExamForm examForm = new ExamForm();
        //    examForm.ShowDialog();
        //}

        //private void btnMarks_Click(object sender, EventArgs e)
        //{
        //    MarkForm markForm = new MarkForm();
        //    markForm.ShowDialog();
        //}

        //private void btnTimetable_Click(object sender, EventArgs e)
        //{
        //    TimetableForm timetableForm = new TimetableForm();
        //    timetableForm.ShowDialog();
        //}

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        //private void btnCourses_Click(object sender, EventArgs e)
        //{
            
        //}

        //private void btnSubjects_Click(object sender, EventArgs e) 
        //{
            
        //}
    }
}
