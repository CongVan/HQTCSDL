namespace Student
{
    partial class UCTransferTeam
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbbMajor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbTopic = new System.Windows.Forms.ComboBox();
            this.btnSubmitTransfer = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvTeamOfTopic = new System.Windows.Forms.DataGridView();
            this.lblCurrentTeam = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeamOfTopic)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(694, 51);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.btnSubmitTransfer);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 51);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(694, 422);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(3, 63);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 100);
            this.panel3.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbbTopic);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbbMajor);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(694, 65);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // cbbMajor
            // 
            this.cbbMajor.FormattingEnabled = true;
            this.cbbMajor.Location = new System.Drawing.Point(109, 25);
            this.cbbMajor.Name = "cbbMajor";
            this.cbbMajor.Size = new System.Drawing.Size(215, 24);
            this.cbbMajor.TabIndex = 0;
            this.cbbMajor.SelectedIndexChanged += new System.EventHandler(this.cbbMajor_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chuyên ngành";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(357, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Chuyên đề";
            // 
            // cbbTopic
            // 
            this.cbbTopic.FormattingEnabled = true;
            this.cbbTopic.Location = new System.Drawing.Point(435, 24);
            this.cbbTopic.Name = "cbbTopic";
            this.cbbTopic.Size = new System.Drawing.Size(218, 24);
            this.cbbTopic.TabIndex = 2;
            this.cbbTopic.SelectedValueChanged += new System.EventHandler(this.cbbTopic_SelectedValueChanged);
            // 
            // btnSubmitTransfer
            // 
            this.btnSubmitTransfer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSubmitTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmitTransfer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmitTransfer.ForeColor = System.Drawing.Color.Tomato;
            this.btnSubmitTransfer.Location = new System.Drawing.Point(0, 390);
            this.btnSubmitTransfer.Name = "btnSubmitTransfer";
            this.btnSubmitTransfer.Size = new System.Drawing.Size(694, 32);
            this.btnSubmitTransfer.TabIndex = 2;
            this.btnSubmitTransfer.Text = "Chuyển nhóm";
            this.btnSubmitTransfer.UseVisualStyleBackColor = true;
            this.btnSubmitTransfer.Click += new System.EventHandler(this.btnSubmitTransfer_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvTeamOfTopic);
            this.groupBox3.Controls.Add(this.lblCurrentTeam);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 65);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(694, 325);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách nhóm";
            // 
            // dgvTeamOfTopic
            // 
            this.dgvTeamOfTopic.AllowUserToAddRows = false;
            this.dgvTeamOfTopic.AllowUserToDeleteRows = false;
            this.dgvTeamOfTopic.BackgroundColor = System.Drawing.Color.White;
            this.dgvTeamOfTopic.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTeamOfTopic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTeamOfTopic.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.NameTeam,
            this.SL});
            this.dgvTeamOfTopic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTeamOfTopic.GridColor = System.Drawing.Color.White;
            this.dgvTeamOfTopic.Location = new System.Drawing.Point(3, 47);
            this.dgvTeamOfTopic.Name = "dgvTeamOfTopic";
            this.dgvTeamOfTopic.ReadOnly = true;
            this.dgvTeamOfTopic.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTeamOfTopic.Size = new System.Drawing.Size(688, 275);
            this.dgvTeamOfTopic.TabIndex = 1;
            this.dgvTeamOfTopic.SelectionChanged += new System.EventHandler(this.dgvTeamOfTopic_SelectionChanged);
            // 
            // lblCurrentTeam
            // 
            this.lblCurrentTeam.BackColor = System.Drawing.Color.LimeGreen;
            this.lblCurrentTeam.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCurrentTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentTeam.ForeColor = System.Drawing.Color.White;
            this.lblCurrentTeam.Location = new System.Drawing.Point(3, 18);
            this.lblCurrentTeam.Name = "lblCurrentTeam";
            this.lblCurrentTeam.Size = new System.Drawing.Size(688, 29);
            this.lblCurrentTeam.TabIndex = 0;
            this.lblCurrentTeam.Text = "Nhóm hiện tại của bạn là: ";
            this.lblCurrentTeam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // NameTeam
            // 
            this.NameTeam.DataPropertyName = "NameTeam";
            this.NameTeam.HeaderText = "Tên nhóm";
            this.NameTeam.Name = "NameTeam";
            this.NameTeam.ReadOnly = true;
            // 
            // SL
            // 
            this.SL.DataPropertyName = "SL";
            this.SL.HeaderText = "Số lượng thành viên";
            this.SL.Name = "SL";
            this.SL.ReadOnly = true;
            this.SL.Width = 150;
            // 
            // UCTransferTeam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "UCTransferTeam";
            this.Size = new System.Drawing.Size(694, 473);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeamOfTopic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvTeamOfTopic;
        private System.Windows.Forms.Label lblCurrentTeam;
        private System.Windows.Forms.Button btnSubmitTransfer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbTopic;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbMajor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameTeam;
        private System.Windows.Forms.DataGridViewTextBoxColumn SL;
    }
}
