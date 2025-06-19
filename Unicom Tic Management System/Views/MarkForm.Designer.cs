namespace Unicom_Tic_Management_System.Views
{
    partial class MarkForm
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
            this.cbStudent = new System.Windows.Forms.ComboBox();
            this.cbExam = new System.Windows.Forms.ComboBox();
            this.cbSubject = new System.Windows.Forms.ComboBox();
            this.txtScore = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dgvMarks = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblStudent = new System.Windows.Forms.Label();
            this.lblSubject = new System.Windows.Forms.Label();
            this.lblExam = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarks)).BeginInit();
            this.SuspendLayout();
            // 
            // cbStudent
            // 
            this.cbStudent.FormattingEnabled = true;
            this.cbStudent.Location = new System.Drawing.Point(220, 38);
            this.cbStudent.Name = "cbStudent";
            this.cbStudent.Size = new System.Drawing.Size(121, 28);
            this.cbStudent.TabIndex = 0;
            // 
            // cbExam
            // 
            this.cbExam.FormattingEnabled = true;
            this.cbExam.Location = new System.Drawing.Point(220, 130);
            this.cbExam.Name = "cbExam";
            this.cbExam.Size = new System.Drawing.Size(121, 28);
            this.cbExam.TabIndex = 2;
            // 
            // cbSubject
            // 
            this.cbSubject.FormattingEnabled = true;
            this.cbSubject.Location = new System.Drawing.Point(220, 86);
            this.cbSubject.Name = "cbSubject";
            this.cbSubject.Size = new System.Drawing.Size(121, 28);
            this.cbSubject.TabIndex = 3;
            // 
            // txtScore
            // 
            this.txtScore.Location = new System.Drawing.Point(220, 185);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(121, 26);
            this.txtScore.TabIndex = 4;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(403, 28);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(87, 38);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(403, 80);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(87, 38);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(403, 130);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(87, 38);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(403, 185);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(87, 38);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // dgvMarks
            // 
            this.dgvMarks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMarks.Location = new System.Drawing.Point(444, 265);
            this.dgvMarks.Name = "dgvMarks";
            this.dgvMarks.RowHeadersWidth = 62;
            this.dgvMarks.RowTemplate.Height = 28;
            this.dgvMarks.Size = new System.Drawing.Size(240, 173);
            this.dgvMarks.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(153, 286);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mark Entry";
            // 
            // lblStudent
            // 
            this.lblStudent.AutoSize = true;
            this.lblStudent.Location = new System.Drawing.Point(62, 46);
            this.lblStudent.Name = "lblStudent";
            this.lblStudent.Size = new System.Drawing.Size(119, 20);
            this.lblStudent.TabIndex = 0;
            this.lblStudent.Text = "Select Student:";
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Location = new System.Drawing.Point(62, 94);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(116, 20);
            this.lblSubject.TabIndex = 11;
            this.lblSubject.Text = "Select Subject:";
            // 
            // lblExam
            // 
            this.lblExam.AutoSize = true;
            this.lblExam.Location = new System.Drawing.Point(62, 138);
            this.lblExam.Name = "lblExam";
            this.lblExam.Size = new System.Drawing.Size(102, 20);
            this.lblExam.TabIndex = 12;
            this.lblExam.Text = "Select Exam:";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(62, 191);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(98, 20);
            this.lblScore.TabIndex = 13;
            this.lblScore.Text = "Enter Score:";
            // 
            // MarkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblExam);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.lblStudent);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvMarks);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.cbSubject);
            this.Controls.Add(this.cbExam);
            this.Controls.Add(this.cbStudent);
            this.Name = "MarkForm";
            this.Text = "MarkForm";
            this.Load += new System.EventHandler(this.MarkForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbStudent;
        private System.Windows.Forms.ComboBox cbExam;
        private System.Windows.Forms.ComboBox cbSubject;
        private System.Windows.Forms.TextBox txtScore;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dgvMarks;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblStudent;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.Label lblExam;
        private System.Windows.Forms.Label lblScore;
    }
}