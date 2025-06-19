using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicom_Tic_Management_System.Models;
using Unicom_Tic_Management_System.Repositories;

namespace Unicom_Tic_Management_System.Controller
{
    public class ExamController
    {
        private readonly ExamRepository examRepo = new ExamRepository();

        public List<Exam> GetAllExams()
        {
            try
            {
                return examRepo.GetAllExams();
            }
            catch (Exception ex)
            {
                throw new Exception("Error loading exams: " + ex.Message);
            }
        }

        public void AddExam(Exam exam)
        {
            // Validation
            if (exam.CourseID <= 0)
                throw new ArgumentException("Please select a course.");
            if (exam.SubjectID <= 0)
                throw new ArgumentException("Please select a subject.");
            if (string.IsNullOrWhiteSpace(exam.Time))
                throw new ArgumentException("Exam time is required.");
            if (string.IsNullOrWhiteSpace(exam.Room))
                throw new ArgumentException("Room is required.");

            try
            {
                examRepo.AddExam(exam);
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding exam: " + ex.Message);
            }
        }

        public void UpdateExam(Exam exam)
        {
            if (exam.ExamID <= 0)
                throw new ArgumentException("Invalid exam ID.");
            if (exam.CourseID <= 0)
                throw new ArgumentException("Please select a course.");
            if (exam.SubjectID <= 0)
                throw new ArgumentException("Please select a subject.");
            if (string.IsNullOrWhiteSpace(exam.Time))
                throw new ArgumentException("Exam time is required.");
            if (string.IsNullOrWhiteSpace(exam.Room))
                throw new ArgumentException("Room is required.");

            try
            {
                examRepo.UpdateExam(exam);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating exam: " + ex.Message);
            }
        }

        public void DeleteExam(int examId)
        {
            if (examId <= 0)
                throw new ArgumentException("Invalid exam ID.");

            try
            {
                examRepo.DeleteExam(examId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting exam: " + ex.Message);
            }
        }
    }
}
