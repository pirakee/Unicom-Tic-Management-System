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
    public class RoomRepository
    {
        public void AddRoom(Room room)
        {
            using (var con = DBConnection.GetConnection())
            {
                con.Open();
                string query = "INSERT INTO Rooms (RoomName, RoomType) VALUES (@name, @type)";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@name", room.RoomName);
                    cmd.Parameters.AddWithValue("@type", room.RoomType);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateRoom(Room room)
        {
            using (var con = DBConnection.GetConnection())
            {
                con.Open();
                string query = "UPDATE Rooms SET RoomName = @name, RoomType = @type WHERE RoomID = @id";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@name", room.RoomName);
                    cmd.Parameters.AddWithValue("@type", room.RoomType);
                    cmd.Parameters.AddWithValue("@id", room.RoomID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteRoom(int roomId)
        {
            using (var con = DBConnection.GetConnection())
            {
                con.Open();
                string query = "DELETE FROM Rooms WHERE RoomID = @id";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", roomId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Room> GetAllRooms()
        {
            List<Room> rooms = new List<Room>();

            using (var con = DBConnection.GetConnection())
            {
                con.Open();
                string query = "SELECT * FROM Rooms";
                using (var cmd = new SQLiteCommand(query, con))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        rooms.Add(new Room
                        {
                            RoomID = Convert.ToInt32(reader["RoomID"]),
                            RoomName = reader["RoomName"].ToString(),
                            RoomType = reader["RoomType"].ToString()
                        });
                    }
                }
            }

            return rooms;
        }

        public Room GetRoomById(int roomId)
        {
            using (var con = DBConnection.GetConnection())
            {
                con.Open();
                string query = "SELECT * FROM Rooms WHERE RoomID = @id";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", roomId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Room
                            {
                                RoomID = Convert.ToInt32(reader["RoomID"]),
                                RoomName = reader["RoomName"].ToString(),
                                RoomType = reader["RoomType"].ToString()
                            };
                        }
                    }
                }
            }

            return null;
        }
    }

}
