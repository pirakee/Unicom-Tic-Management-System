using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Unicom_Tic_Management_System.Helpers;

namespace Unicom_Tic_Management_System.Controller
{
    public class LoginController
    {
        public bool Login(string username, string password, string role, out string errorMessage)
        {
            errorMessage = "";

            try
            {
                using (SQLiteConnection conn = DBConnection.GetConnection()) // ✅ use static connection method
                {
                    conn.Open();

                    string query = "SELECT COUNT(*) FROM Users WHERE Username = @username AND Password = @password AND Role = @role";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password); // plain text (or hash if needed)
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
                errorMessage = "Login failed: " + ex.Message;
                return false;
            }
        }
        

    }
}
