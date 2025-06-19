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
    public partial class TimetableForm : Form
    {
        private readonly TimetableController controller;
        private readonly CourseRepository courseRepo;
        private readonly SubjectRepository subjectRepo;
        //private readonly RoomRepository roomRepo;

        public TimetableForm()
        {
            InitializeComponent();
            controller = new TimetableController();
            courseRepo = new CourseRepository();
            subjectRepo = new SubjectRepository();
            //roomRepo = new RoomRepository();

            LoadCombos();
            LoadTimetables();
        }

        private void LoadCombos()
        {
            cbCourse.DataSource = courseRepo.GetAllCourses();
            cbCourse.DisplayMember = "CourseName";
            cbCourse.ValueMember = "CourseID";

            //cbRoom.DataSource = roomRepo.GetAllRooms();
            cbRoom.DisplayMember = "RoomName";
            cbRoom.ValueMember = "RoomID";

            cbDay.Items.AddRange(new string[]
            {
                    "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"
            });

            cbCourse.SelectedIndexChanged += (s, e) => LoadSubjects();
            LoadSubjects(); // initial load
        }

        private void LoadSubjects()
        {
            if (cbCourse.SelectedValue is int courseId)
            {
                //cbSubject.DataSource = subjectRepo.GetSubjectsByCourseId(courseId);
                //cbSubject.DisplayMember = "SubjectName";
                //cbSubject.ValueMember = "SubjectID";
            }
        }

        private void LoadTimetables()
        {
            dgvTimetable.DataSource = controller.GetAllTimetables();
        }

        private void ClearForm()
        {
            cbCourse.SelectedIndex = 0;
            cbSubject.SelectedIndex = 0;
            cbRoom.SelectedIndex = 0;
            cbDay.SelectedIndex = 0;
            txtTime.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var timetable = new Timetable
            {
                CourseID = Convert.ToInt32(cbCourse.SelectedValue),
                SubjectID = Convert.ToInt32(cbSubject.SelectedValue),
                RoomID = Convert.ToInt32(cbRoom.SelectedValue),
                Day = cbDay.Text,
                Time = txtTime.Text
            };

            controller.AddTimetable(timetable);
            LoadTimetables();
            ClearForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvTimetable.CurrentRow != null)
            {
                var timetable = new Timetable
                {
                    TimetableID = Convert.ToInt32(dgvTimetable.CurrentRow.Cells["TimetableID"].Value),
                    CourseID = Convert.ToInt32(cbCourse.SelectedValue),
                    SubjectID = Convert.ToInt32(cbSubject.SelectedValue),
                    RoomID = Convert.ToInt32(cbRoom.SelectedValue),
                    Day = cbDay.Text,
                    Time = txtTime.Text
                };

                controller.UpdateTimetable(timetable);
                LoadTimetables();
                ClearForm();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTimetable.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvTimetable.CurrentRow.Cells["TimetableID"].Value);
                controller.DeleteTimetable(id);
                LoadTimetables();
                ClearForm();
            }
        }

        private void dgvTimetable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvTimetable.Rows[e.RowIndex];
                cbCourse.SelectedValue = Convert.ToInt32(row.Cells["CourseID"].Value);
                cbSubject.SelectedValue = Convert.ToInt32(row.Cells["SubjectID"].Value);
                cbRoom.SelectedValue = Convert.ToInt32(row.Cells["RoomID"].Value);
                cbDay.Text = row.Cells["Day"].Value.ToString();
                txtTime.Text = row.Cells["Time"].Value.ToString();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void TimetableForm_Load(object sender, EventArgs e)
        {

        }
    }
}
