using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicom_Tic_Management_System.Models;
using Unicom_Tic_Management_System.Repositories;

namespace Unicom_Tic_Management_System.Controller
{
    public class MarkController
    {
        private readonly MarkRepository markRepo = new MarkRepository();

        public List<Mark> GetAllMarks()
        {
            try
            {
                return markRepo.GetAllMarks();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to load marks: " + ex.Message);
            }
        }

        public void AddMark(Mark mark)
        {
            // Input validation
            if (mark.StudentID <= 0)
                throw new ArgumentException("Please select a student.");
            if (mark.SubjectID <= 0)
                throw new ArgumentException("Please select a subject.");
            if (mark.ExamID <= 0)
                throw new ArgumentException("Please select an exam.");
            if (mark.Score < 0 || mark.Score > 100)
                throw new ArgumentException("Score must be between 0 and 100.");

            try
            {
                markRepo.AddMark(mark);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add mark: " + ex.Message);
            }
        }

        public void UpdateMark(Mark mark)
        {
            if (mark.MarkID <= 0)
                throw new ArgumentException("Invalid Mark ID.");
            if (mark.StudentID <= 0)
                throw new ArgumentException("Please select a student.");
            if (mark.SubjectID <= 0)
                throw new ArgumentException("Please select a subject.");
            if (mark.ExamID <= 0)
                throw new ArgumentException("Please select an exam.");
            if (mark.Score < 0 || mark.Score > 100)
                throw new ArgumentException("Score must be between 0 and 100.");

            try
            {
                markRepo.UpdateMark(mark);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update mark: " + ex.Message);
            }
        }

        public void DeleteMark(int markId)
        {
            if (markId <= 0)
                throw new ArgumentException("Invalid Mark ID.");

            try
            {
                markRepo.DeleteMark(markId);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete mark: " + ex.Message);
            }
        }
    }
}
