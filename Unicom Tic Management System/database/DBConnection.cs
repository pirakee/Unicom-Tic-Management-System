using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Unicom_Tic_Management_System.Helpers
{
    public static class DBConnection
    {
        // ✅ Update this path to match your actual SQLite database file
        public static string ConnectionString = @"Data Source=unicom.db;Version=3;";

        // ✅ Returns an open SQLite connection
        public static SQLiteConnection GetConnection()
        {
            try
            {
                SQLiteConnection conn = new SQLiteConnection(ConnectionString);
                return conn;
            }
            catch (Exception ex)
            {
                // You can log this to a file instead
                Console.WriteLine("Error creating SQLite connection: " + ex.Message);
                throw new Exception("Failed to create database connection.");
            }
        }
    }
}
