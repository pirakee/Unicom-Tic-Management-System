using System;
using Unicom_Tic_Management_System.Views;

namespace UnicomTICManagementSystem.Views
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnTimetables = new System.Windows.Forms.Button();
            this.btnMarks = new System.Windows.Forms.Button();
            this.btnExams = new System.Windows.Forms.Button();
            this.btnStudents = new System.Windows.Forms.Button();
            this.btnSubjects = new System.Windows.Forms.Button();
            this.btnCourses = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLogout
            // 
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLogout.Font = new System.Drawing.Font("Mytupi", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnLogout.Location = new System.Drawing.Point(330, 351);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 15;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnTimetables
            // 
            this.btnTimetables.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimetables.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTimetables.Font = new System.Drawing.Font("Mytupi", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnTimetables.Location = new System.Drawing.Point(408, 296);
            this.btnTimetables.Name = "btnTimetables";
            this.btnTimetables.Size = new System.Drawing.Size(75, 23);
            this.btnTimetables.TabIndex = 14;
            this.btnTimetables.Text = "Timetables";
            this.btnTimetables.UseVisualStyleBackColor = true;
            this.btnTimetables.Click += new System.EventHandler(this.btnTimetables_Click);
            // 
            // btnMarks
            // 
            this.btnMarks.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMarks.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMarks.Font = new System.Drawing.Font("Mytupi", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnMarks.Location = new System.Drawing.Point(407, 238);
            this.btnMarks.Name = "btnMarks";
            this.btnMarks.Size = new System.Drawing.Size(75, 23);
            this.btnMarks.TabIndex = 13;
            this.btnMarks.Text = "Marks";
            this.btnMarks.UseVisualStyleBackColor = true;
            this.btnMarks.Click += new System.EventHandler(this.btnMarks_Click);
            // 
            // btnExams
            // 
            this.btnExams.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExams.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExams.Font = new System.Drawing.Font("Mytupi", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnExams.Location = new System.Drawing.Point(408, 183);
            this.btnExams.Name = "btnExams";
            this.btnExams.Size = new System.Drawing.Size(74, 23);
            this.btnExams.TabIndex = 12;
            this.btnExams.Text = "Exams";
            this.btnExams.UseVisualStyleBackColor = true;
            this.btnExams.Click += new System.EventHandler(this.btnExams_Click);
            // 
            // btnStudents
            // 
            this.btnStudents.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStudents.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStudents.Font = new System.Drawing.Font("Mytupi", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnStudents.Location = new System.Drawing.Point(255, 296);
            this.btnStudents.Name = "btnStudents";
            this.btnStudents.Size = new System.Drawing.Size(75, 23);
            this.btnStudents.TabIndex = 11;
            this.btnStudents.Text = "Students";
            this.btnStudents.UseVisualStyleBackColor = true;
            this.btnStudents.Click += new System.EventHandler(this.btnStudents_Click);
            // 
            // btnSubjects
            // 
            this.btnSubjects.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubjects.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSubjects.Font = new System.Drawing.Font("Mytupi", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSubjects.Location = new System.Drawing.Point(255, 240);
            this.btnSubjects.Name = "btnSubjects";
            this.btnSubjects.Size = new System.Drawing.Size(75, 23);
            this.btnSubjects.TabIndex = 10;
            this.btnSubjects.Text = "Subjects";
            this.btnSubjects.UseVisualStyleBackColor = true;
            this.btnSubjects.Click += new System.EventHandler(this.btnSubjects_Click);
            // 
            // btnCourses
            // 
            this.btnCourses.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCourses.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCourses.Font = new System.Drawing.Font("Mytupi", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCourses.Location = new System.Drawing.Point(255, 184);
            this.btnCourses.Name = "btnCourses";
            this.btnCourses.Size = new System.Drawing.Size(75, 23);
            this.btnCourses.TabIndex = 9;
            this.btnCourses.Text = "Courses";
            this.btnCourses.UseVisualStyleBackColor = true;
            this.btnCourses.Click += new System.EventHandler(this.btnCourses_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcome.Font = new System.Drawing.Font("MontrealSerial", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(117, 30);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(180, 50);
            this.lblWelcome.TabIndex = 8;
            this.lblWelcome.Text = "Welcome!";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Unicom_Tic_Management_System.Properties.Resources.istockphoto_1404131751_612x612;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnTimetables);
            this.Controls.Add(this.btnMarks);
            this.Controls.Add(this.btnExams);
            this.Controls.Add(this.btnStudents);
            this.Controls.Add(this.btnSubjects);
            this.Controls.Add(this.btnCourses);
            this.Controls.Add(this.lblWelcome);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnMarks_Click(object sender, EventArgs e)
        {
            var form = new MarkForm();
            form.ShowDialog();
        }

        private void btnSubjects_Click(object sender, EventArgs e)
        {
            var form = new SubjectForm();
            form.ShowDialog();
        }

        #endregion

        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnTimetables;
        private System.Windows.Forms.Button btnMarks;
        private System.Windows.Forms.Button btnExams;
        private System.Windows.Forms.Button btnStudents;
        private System.Windows.Forms.Button btnSubjects;
        private System.Windows.Forms.Button btnCourses;
        private System.Windows.Forms.Label lblWelcome;
    }
}