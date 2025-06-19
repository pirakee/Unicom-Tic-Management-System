using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicom_Tic_Management_System.Repositories
{
    public class LoginRepository
    {
        private readonly string connectionString;

        public LoginRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // Login method: returns true if valid credentials, false otherwise
        public bool Login(string username, string password, string role, out string errorMessage)
        {
            errorMessage = "";

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(role))
            {
                errorMessage = "All fields are required.";
                return false;
            }

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    // Note: If password hashing is used, hash the password here before querying
                    string query = "SELECT COUNT(*) FROM Users WHERE Username = @username AND PasswordHash = @password AND Role = @role";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password); // Use hashed password if applicable
                        cmd.Parameters.AddWithValue("@role", role);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count == 1)
                            return true;
                        else
                        {
                            errorMessage = "Invalid username, password, or role.";
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = "Login failed due to an internal error: " + ex.Message;
                return false;
            }
        }
    }
}
