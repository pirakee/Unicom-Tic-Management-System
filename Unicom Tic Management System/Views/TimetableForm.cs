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

namespace UnicomTICManagementSystem.Views
{
    public partial class TimetableForm : Form
    {
        private List<Subject> subjects;
        private List<Room> rooms;

        public TimetableForm(List<Room> rooms)
        {
            this.rooms = rooms;
        }

        public object RoomController { get; private set; }

        public TimetableForm()
        {
            InitializeComponent();
            LoadSubjects();
            LoadRooms();
            LoadTimetables();
        }

        private void LoadSubjects()
        {
            subjects = SubjectController.GetAllSubjects();
            cmbSubject.DataSource = subjects;
            cmbSubject.DisplayMember = "SubjectName";
            cmbSubject.ValueMember = "SubjectID";
        }

        private void LoadRooms()
        {
           // rooms = RoomController.GetAllRooms(); // static method
            cmbRoom.DataSource = rooms;
            cmbRoom.DisplayMember = "RoomName";
            cmbRoom.ValueMember = "RoomID";
        }

        private void LoadTimetables()
        {
            dgvTimetables.DataSource = TimetableController.GetAllTimetables();
            dgvTimetables.Columns["TimetableID"].Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimeSlot.Text))
            {
                MessageBox.Show("Please enter a time slot.");
                return;
            }

            int subjectId = (int)cmbSubject.SelectedValue;
            int roomId = (int)cmbRoom.SelectedValue;

            TimetableController.AddTimetable(subjectId, txtTimeSlot.Text.Trim(), roomId);
            LoadTimetables();
            txtTimeSlot.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvTimetables.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvTimetables.SelectedRows[0].Cells["TimetableID"].Value);
                int subjectId = (int)cmbSubject.SelectedValue;
                int roomId = (int)cmbRoom.SelectedValue;
                string slot = txtTimeSlot.Text.Trim();

                TimetableController.UpdateTimetable(id, subjectId, slot, roomId);
                LoadTimetables();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTimetables.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvTimetables.SelectedRows[0].Cells["TimetableID"].Value);
                TimetableController.DeleteTimetable(id);
                LoadTimetables();
            }
        }

        private void dgvTimetables_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtTimeSlot.Text = dgvTimetables.Rows[e.RowIndex].Cells["TimeSlot"].Value.ToString();
                cmbSubject.SelectedValue = Convert.ToInt32(dgvTimetables.Rows[e.RowIndex].Cells["SubjectID"].Value);
                cmbRoom.SelectedValue = Convert.ToInt32(dgvTimetables.Rows[e.RowIndex].Cells["RoomID"].Value);
            }
        }


        private void TimetableForm_Load(object sender, EventArgs e)
        {

        }

        public override bool Equals(object obj)
        {
            return obj is TimetableForm form &&
                   EqualityComparer<List<Room>>.Default.Equals(rooms, form.rooms);
        }

        private void cmbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
