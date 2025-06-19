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
    public partial class AttendanceForm : Form
    {
        private readonly AttendanceRepository repository;
        private readonly StudentRepository studentRepo;
        private readonly SubjectRepository subjectRepo;

        public AttendanceForm()
        {
            InitializeComponent();
            repository = new AttendanceRepository();
            studentRepo = new StudentRepository();
            subjectRepo = new SubjectRepository();
            LoadCombos();
            LoadAttendance();
        }

        private void LoadCombos()
        {
            cbStudent.DataSource = studentRepo.GetAllStudents();
            cbStudent.DisplayMember = "StudentName";
            cbStudent.ValueMember = "StudentID";

            cbSubject.DataSource = subjectRepo.GetAllSubjects();
            cbSubject.DisplayMember = "SubjectName";
            cbSubject.ValueMember = "SubjectID";

            cbStatus.Items.Add("Present");
            cbStatus.Items.Add("Absent");
        }

        private void LoadAttendance()
        {
            dgvAttendance.DataSource = repository.GetAllAttendance();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var attendance = new Attendance
            {
                StudentID = Convert.ToInt32(cbStudent.SelectedValue),
                SubjectID = Convert.ToInt32(cbSubject.SelectedValue),
                Date = dtpDate.Value.ToString("yyyy-MM-dd"),
                Status = cbStatus.Text
            };

            repository.AddAttendance(attendance);
            LoadAttendance();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void AttendanceForm_Load(object sender, EventArgs e)
        {

        }
    }
}
