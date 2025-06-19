using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicom_Tic_Management_System.Models;
using Unicom_Tic_Management_System.Repositories;

namespace Unicom_Tic_Management_System.Controller
{
    public class SubjectController
    {
        private readonly SubjectRepository subjectRepo;

        public SubjectController()
        {
            subjectRepo = new SubjectRepository();
        }

        // Get all subjects
        public List<Subject> GetAllSubjects()
        {
            try
            {
                return subjectRepo.GetAllSubjects();
            }
            catch (Exception ex)
            {
                throw new Exception("Controller Error: Could not fetch subjects. " + ex.Message);
            }
        }

        // Get subjects filtered by CourseID
        public List<Subject> GetSubjectsByCourse(int courseId)
        {
            try
            {
                return subjectRepo.GetSubjectsByCourse(courseId);
            }
            catch (Exception ex)
            {
                throw new Exception("Controller Error: Could not fetch subjects by course. " + ex.Message);
            }
        }

        // Add a subject
        public void AddSubject(string subjectName, int courseId)
        {
            if (string.IsNullOrWhiteSpace(subjectName))
                throw new ArgumentException("Subject name cannot be empty.");

            Subject subject = new Subject
            {
                SubjectName = subjectName.Trim(),
                CourseID = courseId
            };

            try
            {
                subjectRepo.AddSubject(subject);
            }
            catch (Exception ex)
            {
                throw new Exception("Controller Error: Could not add subject. " + ex.Message);
            }
        }

        // Update a subject
        public void UpdateSubject(int subjectId, string subjectName, int courseId)
        {
            if (subjectId <= 0)
                throw new ArgumentException("Invalid Subject ID.");

            if (string.IsNullOrWhiteSpace(subjectName))
                throw new ArgumentException("Subject name cannot be empty.");

            Subject subject = new Subject
            {
                SubjectID = subjectId,
                SubjectName = subjectName.Trim(),
                CourseID = courseId
            };

            try
            {
                subjectRepo.UpdateSubject(subject);
            }
            catch (Exception ex)
            {
                throw new Exception("Controller Error: Could not update subject. " + ex.Message);
            }
        }

        // Delete a subject
        public void DeleteSubject(int subjectId)
        {
            if (subjectId <= 0)
                throw new ArgumentException("Invalid Subject ID.");

            try
            {
                subjectRepo.DeleteSubject(subjectId);
            }
            catch (Exception ex)
            {
                throw new Exception("Controller Error: Could not delete subject. " + ex.Message);
            }
        }
    }
}
