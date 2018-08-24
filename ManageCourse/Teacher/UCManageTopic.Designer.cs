﻿namespace Teacher
{
    partial class UCManageTopic
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnCreateTeam = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.dgvTopics = new System.Windows.Forms.DataGridView();
            this.MajorID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TopicID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TopicCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TopicName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MajorCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MajorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Deadline = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberOfTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberStudent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Enable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopics)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Tomato;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Snow;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(708, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ CHUYÊN ĐỀ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txtKeyword);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(708, 60);
            this.panel1.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.Snow;
            this.btnSearch.Location = new System.Drawing.Point(553, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(92, 41);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtKeyword
            // 
            this.txtKeyword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKeyword.Location = new System.Drawing.Point(202, 18);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(316, 26);
            this.txtKeyword.TabIndex = 1;
            this.txtKeyword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKeyword_KeyDown);
            this.txtKeyword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKeyword_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã / Tên chuyên đề";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnReset);
            this.panel2.Controls.Add(this.btnCreateTeam);
            this.panel2.Controls.Add(this.btnUpdate);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 446);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(708, 64);
            this.panel2.TabIndex = 4;
            // 
            // btnReset
            // 
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.Coral;
            this.btnReset.Image = global::Teacher.Properties.Resources.reset32;
            this.btnReset.Location = new System.Drawing.Point(19, 6);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(108, 39);
            this.btnReset.TabIndex = 5;
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnCreateTeam
            // 
            this.btnCreateTeam.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCreateTeam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateTeam.ForeColor = System.Drawing.Color.Snow;
            this.btnCreateTeam.Location = new System.Drawing.Point(315, 6);
            this.btnCreateTeam.Name = "btnCreateTeam";
            this.btnCreateTeam.Size = new System.Drawing.Size(143, 41);
            this.btnCreateTeam.TabIndex = 4;
            this.btnCreateTeam.Text = "Tạo nhóm";
            this.btnCreateTeam.UseVisualStyleBackColor = false;
            this.btnCreateTeam.Click += new System.EventHandler(this.btnCreateTeam_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.SteelBlue;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.Snow;
            this.btnUpdate.Location = new System.Drawing.Point(149, 6);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(143, 41);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // dgvTopics
            // 
            this.dgvTopics.AllowUserToAddRows = false;
            this.dgvTopics.AllowUserToDeleteRows = false;
            this.dgvTopics.AllowUserToResizeRows = false;
            this.dgvTopics.BackgroundColor = System.Drawing.Color.White;
            this.dgvTopics.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTopics.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MajorID,
            this.TopicID,
            this.TopicCode,
            this.TopicName,
            this.MajorCode,
            this.MajorName,
            this.Deadline,
            this.NumberOfTeam,
            this.NumberTeam,
            this.NumberStudent,
            this.Enable});
            this.dgvTopics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTopics.GridColor = System.Drawing.Color.White;
            this.dgvTopics.Location = new System.Drawing.Point(0, 110);
            this.dgvTopics.MultiSelect = false;
            this.dgvTopics.Name = "dgvTopics";
            this.dgvTopics.ReadOnly = true;
            this.dgvTopics.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvTopics.RowHeadersVisible = false;
            this.dgvTopics.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTopics.Size = new System.Drawing.Size(708, 336);
            this.dgvTopics.TabIndex = 5;
            // 
            // MajorID
            // 
            this.MajorID.DataPropertyName = "MajorID";
            this.MajorID.HeaderText = "MajorID";
            this.MajorID.Name = "MajorID";
            this.MajorID.ReadOnly = true;
            this.MajorID.Visible = false;
            // 
            // TopicID
            // 
            this.TopicID.DataPropertyName = "TopicID";
            this.TopicID.HeaderText = "TopicID";
            this.TopicID.Name = "TopicID";
            this.TopicID.ReadOnly = true;
            this.TopicID.Visible = false;
            // 
            // TopicCode
            // 
            this.TopicCode.DataPropertyName = "TopicCode";
            this.TopicCode.HeaderText = "Mã chuyên đề";
            this.TopicCode.Name = "TopicCode";
            this.TopicCode.ReadOnly = true;
            this.TopicCode.Width = 150;
            // 
            // TopicName
            // 
            this.TopicName.DataPropertyName = "TopicName";
            this.TopicName.HeaderText = "Tên chuyên đề";
            this.TopicName.Name = "TopicName";
            this.TopicName.ReadOnly = true;
            this.TopicName.Width = 300;
            // 
            // MajorCode
            // 
            this.MajorCode.DataPropertyName = "MajorCode";
            this.MajorCode.HeaderText = "Mã ngành";
            this.MajorCode.Name = "MajorCode";
            this.MajorCode.ReadOnly = true;
            this.MajorCode.Width = 150;
            // 
            // MajorName
            // 
            this.MajorName.DataPropertyName = "MajorName";
            this.MajorName.HeaderText = "Chuyên ngành";
            this.MajorName.Name = "MajorName";
            this.MajorName.ReadOnly = true;
            this.MajorName.Width = 200;
            // 
            // Deadline
            // 
            this.Deadline.DataPropertyName = "Deadline";
            this.Deadline.HeaderText = "Deadline";
            this.Deadline.Name = "Deadline";
            this.Deadline.ReadOnly = true;
            this.Deadline.Width = 150;
            // 
            // NumberOfTeam
            // 
            this.NumberOfTeam.DataPropertyName = "NumberOfTeam";
            this.NumberOfTeam.HeaderText = "Số lượng nhóm hiện tại";
            this.NumberOfTeam.Name = "NumberOfTeam";
            this.NumberOfTeam.ReadOnly = true;
            this.NumberOfTeam.Width = 170;
            // 
            // NumberTeam
            // 
            this.NumberTeam.DataPropertyName = "NumberTeam";
            this.NumberTeam.HeaderText = "Số lượng nhóm tối đa";
            this.NumberTeam.Name = "NumberTeam";
            this.NumberTeam.ReadOnly = true;
            this.NumberTeam.Width = 150;
            // 
            // NumberStudent
            // 
            this.NumberStudent.DataPropertyName = "NumberStudent";
            this.NumberStudent.HeaderText = "Số sinh viên tối đa";
            this.NumberStudent.Name = "NumberStudent";
            this.NumberStudent.ReadOnly = true;
            this.NumberStudent.Width = 150;
            // 
            // Enable
            // 
            this.Enable.DataPropertyName = "Enable";
            this.Enable.HeaderText = "Tình trạng";
            this.Enable.Name = "Enable";
            this.Enable.ReadOnly = true;
            // 
            // UCManageTopic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dgvTopics);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "UCManageTopic";
            this.Size = new System.Drawing.Size(708, 510);
            this.Load += new System.EventHandler(this.UCManageTopic_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopics)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataGridView dgvTopics;
        private System.Windows.Forms.Button btnCreateTeam;
        private System.Windows.Forms.DataGridViewTextBoxColumn MajorID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TopicID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TopicCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn TopicName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MajorCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn MajorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Deadline;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberOfTeam;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberTeam;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberStudent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Enable;
        private System.Windows.Forms.Button btnReset;
    }
}
