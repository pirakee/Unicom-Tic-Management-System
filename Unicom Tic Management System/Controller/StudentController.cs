using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicom_Tic_Management_System.Models;
using Unicom_Tic_Management_System.Repositories;

namespace Unicom_Tic_Management_System.Controller
{
    public class StudentController
    {
        private readonly StudentRepository studentRepo = new StudentRepository();

        public List<Student> GetAllStudents()
        {
            try
            {
                return studentRepo.GetAllStudents();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving students: " + ex.Message);
            }
        }

        public void AddStudent(Student student)
        {
            if (string.IsNullOrWhiteSpace(student.StudentName))
                throw new ArgumentException("Student name is required.");
            if (string.IsNullOrWhiteSpace(student.Email))
                throw new ArgumentException("Email is required.");
            if (student.CourseID <= 0)
                throw new ArgumentException("Course selection is required.");

            try
            {
                studentRepo.AddStudent(student);
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding student: " + ex.Message);
            }
        }

        public void UpdateStudent(Student student)
        {
            if (student.StudentID <= 0)
                throw new ArgumentException("Invalid student ID.");
            if (string.IsNullOrWhiteSpace(student.StudentName))
                throw new ArgumentException("Student name is required.");
            if (string.IsNullOrWhiteSpace(student.Email))
                throw new ArgumentException("Email is required.");

            try
            {
                studentRepo.UpdateStudent(student);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating student: " + ex.Message);
            }
        }

        public void DeleteStudent(int studentId)
        {
            if (studentId <= 0)
                throw new ArgumentException("Invalid student ID.");

            try
            {
                studentRepo.DeleteStudent(studentId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting student: " + ex.Message);
            }
        }
    }
}
