using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unicom_Tic_Management_System.Models;
using Unicom_Tic_Management_System.Repositories;

namespace Unicom_Tic_Management_System.Controller
{
    public class TimetableController
    {
        private readonly TimetableRepository timetableRepo;

        public TimetableController()
        {
            timetableRepo = new TimetableRepository();
        }

        public void AddTimetable(Timetable timetable)
        {
            try
            {
                if (timetable.CourseID == 0 || timetable.SubjectID == 0 ||
                    string.IsNullOrWhiteSpace(timetable.Day) ||
                    string.IsNullOrWhiteSpace(timetable.Time) ||
                    timetable.RoomID == 0)
                {
                    MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                timetableRepo.AddTimetable(timetable);
                MessageBox.Show("Timetable added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding timetable: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateTimetable(Timetable timetable)
        {
            try
            {
                if (timetable.TimetableID == 0)
                {
                    MessageBox.Show("Select a timetable entry to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                timetableRepo.UpdateTimetable(timetable);
                MessageBox.Show("Timetable updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating timetable: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeleteTimetable(int id)
        {
            try
            {
                DialogResult confirm = MessageBox.Show("Are you sure you want to delete this timetable?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    timetableRepo.DeleteTimetable(id);
                    MessageBox.Show("Timetable deleted successfully!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting timetable: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<Timetable> GetAllTimetables()
        {
            try
            {
                return timetableRepo.GetAllTimetables();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading timetables: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Timetable>();
            }
        }

        public Timetable GetTimetableById(int id)
        {
            try
            {
                return timetableRepo.GetTimetableById(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error finding timetable: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
