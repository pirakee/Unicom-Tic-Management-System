using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicom_Tic_Management_System.Controller;
using Unicom_Tic_Management_System.Helpers;
using Unicom_Tic_Management_System.Models;

namespace Unicom_Tic_Management_System.Repositories
{
    public class UserRepository
    {
        private string connectionString;

        public bool AddUser(User user)
        {
            try
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Users (FullName, Username, PasswordHash, Role, Email, IsActive) " +
                                   "VALUES (@FullName, @Username, @PasswordHash, @Role, @Email, @IsActive)";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FullName", user.FullName);
                        cmd.Parameters.AddWithValue("@Username", user.Username);
                        cmd.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                        cmd.Parameters.AddWithValue("@Role", user.Role);
                        cmd.Parameters.AddWithValue("@Email", user.Email ?? "");
                        cmd.Parameters.AddWithValue("@IsActive", user.IsActive ? 1 : 0);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding user: " + ex.Message);
                return false;
            }
        }

        public User GetUserByUsername(string username)
        {
            try
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Users WHERE Username = @Username AND IsActive = 1";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new User
                                {
                                    UserID = Convert.ToInt32(reader["UserID"]),
                                    FullName = reader["FullName"].ToString(),
                                    Username = reader["Username"].ToString(),
                                    PasswordHash = reader["PasswordHash"].ToString(),
                                    Role = reader["Role"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    IsActive = Convert.ToInt32(reader["IsActive"]) == 1
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving user: " + ex.Message);
            }

            return null;
        }

        public List<User> GetAllUsers()
        {
            var users = new List<User>();

            try
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Users";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                users.Add(new User
                                {
                                    UserID = Convert.ToInt32(reader["UserID"]),
                                    FullName = reader["FullName"].ToString(),
                                    Username = reader["Username"].ToString(),
                                    PasswordHash = reader["PasswordHash"].ToString(),
                                    Role = reader["Role"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    IsActive = Convert.ToInt32(reader["IsActive"]) == 1
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting users: " + ex.Message);
            }

            return users;
        }
    }
}
