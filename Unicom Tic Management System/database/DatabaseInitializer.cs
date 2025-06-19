using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Unicom_Tic_Management_System.Helpers;

namespace Unicom_Tic_Management_System.database
{
    public static class DatabaseInitializer
    {
        public static void InitializeDatabase()
        {
            using (SQLiteConnection conn = DBConnection.GetConnection())
            {
                conn.Open();

                Execute(conn, @"
                    CREATE TABLE IF NOT EXISTS Users (
                        UserID INTEGER PRIMARY KEY AUTOINCREMENT,
                        FullName TEXT NOT NULL,
                        Username TEXT NOT NULL UNIQUE,
                        Password TEXT NOT NULL,
                        Role TEXT NOT NULL,
                        Email TEXT,
                        IsActive INTEGER NOT NULL DEFAULT 1
                    );
                ");

                Execute(conn, @"
                    CREATE TABLE IF NOT EXISTS Courses (
                        CourseID INTEGER PRIMARY KEY AUTOINCREMENT,
                        CourseName TEXT NOT NULL,
                        Description TEXT
                    );
                ");

                Execute(conn, @"
                    CREATE TABLE IF NOT EXISTS Subjects (
                        SubjectID INTEGER PRIMARY KEY AUTOINCREMENT,
                        SubjectName TEXT NOT NULL,
                        CourseID INTEGER NOT NULL,
                        FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
                    );
                ");

                Execute(conn, @"
                    CREATE TABLE IF NOT EXISTS Students (
                        StudentID INTEGER PRIMARY KEY AUTOINCREMENT,
                        FullName TEXT NOT NULL,
                        Gender TEXT,
                        DOB TEXT,
                        Email TEXT,
                        Phone TEXT,
                        Address TEXT,
                        CourseID INTEGER NOT NULL,
                        GroupName TEXT,
                        FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
                    );
                ");

                Execute(conn, @"
                    CREATE TABLE IF NOT EXISTS Exams (
                        ExamID INTEGER PRIMARY KEY AUTOINCREMENT,
                        CourseID INTEGER NOT NULL,
                        SubjectID INTEGER NOT NULL,
                        ExamDate TEXT NOT NULL,
                        ExamTime TEXT NOT NULL,
                        Room TEXT,
                        FOREIGN KEY (CourseID) REFERENCES Courses(CourseID),
                        FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID)
                    );
                ");

                Execute(conn, @"
                    CREATE TABLE IF NOT EXISTS Marks (
                        MarkID INTEGER PRIMARY KEY AUTOINCREMENT,
                        StudentID INTEGER NOT NULL,
                        SubjectID INTEGER NOT NULL,
                        ExamID INTEGER NOT NULL,
                        Score INTEGER NOT NULL,
                        FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
                        FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID),
                        FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)
                    );
                ");

                Execute(conn, @"
                    CREATE TABLE IF NOT EXISTS Timetable (
                        TimetableID INTEGER PRIMARY KEY AUTOINCREMENT,
                        CourseID INTEGER NOT NULL,
                        SubjectID INTEGER NOT NULL,
                        Lecturer TEXT NOT NULL,
                        DayOfWeek TEXT NOT NULL,
                        StartTime TEXT NOT NULL,
                        EndTime TEXT NOT NULL,
                        Room TEXT NOT NULL,
                        GroupName TEXT,
                        FOREIGN KEY (CourseID) REFERENCES Courses(CourseID),
                        FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID)
                    );
                ");

                Execute(conn, @"
                    CREATE TABLE IF NOT EXISTS Attendance (
                        AttendanceID INTEGER PRIMARY KEY AUTOINCREMENT,
                        StudentID INTEGER NOT NULL,
                        Date TEXT NOT NULL,
                        Status TEXT NOT NULL,
                        SubjectID INTEGER NOT NULL,
                        FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
                        FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID)
                    );
                ");

                Execute(conn, @"
                    CREATE TABLE IF NOT EXISTS Rooms (
                        RoomID INTEGER PRIMARY KEY AUTOINCREMENT,
                        RoomName TEXT NOT NULL,
                        RoomType TEXT NOT NULL
                    );
                ");
            }
        }

        private static void Execute(SQLiteConnection conn, string query)
        {
            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}
