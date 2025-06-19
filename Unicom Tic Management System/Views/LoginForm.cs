using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unicom_Tic_Management_System.Controller;
using Unicom_Tic_Management_System.Views;

namespace Unicom_Tic_Management_System
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {

            InitializeComponent();
            cbRole.Items.AddRange(new string[] { "Admin", "Staff", "Lecturer", "student" });
            cbRole.SelectedIndex = 0;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string role = cbRole.SelectedItem.ToString();

            if (username == "" || password == "")
            {
                MessageBox.Show("Please enter both username and password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection("Data Source=unicom.db;Version=3;"))
                {
                    conn.Open();

                    string hashedPassword = GetHashedPassword(password);
                    string query = "SELECT * FROM Users WHERE Username = @username AND Password = @password AND Role = @role";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", hashedPassword);
                        cmd.Parameters.AddWithValue("@role", role);

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Open role-based dashboard
                                MainForm mainForm = new MainForm(role); // send role
                                this.Hide();
                                mainForm.Show();
                            }
                            else
                            {
                                MessageBox.Show("Invalid credentials or role.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login error:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetHashedPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                    builder.Append(b.ToString("x2"));
                return builder.ToString();
            }
        }


        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string role = cbRole.SelectedItem.ToString();

            LoginController loginController = new LoginController();
            string error;

            if (loginController.Login(username, password, role, out error))
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainForm mainForm = new MainForm(role);
                this.Hide();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show(error, "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
