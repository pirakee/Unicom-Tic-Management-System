using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicom_Tic_Management_System.Models
{
    public class User
    {
        public int UserID { get; set; }

        public string FullName { get; set; }

        public string Username { get; set; }

        public string PasswordHash { get; set; }

        public string Role { get; set; } // Admin, Staff, Student, Lecturer

        public string Email { get; set; } // Optional

        public bool IsActive { get; set; } = true;

        public override string ToString()
        {
            return $"{FullName} ({Role})";
        }
    }
}
