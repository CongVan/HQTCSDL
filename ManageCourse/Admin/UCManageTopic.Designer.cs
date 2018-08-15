namespace Admin
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvTopic = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbFMajor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grbUpdate = new System.Windows.Forms.GroupBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.cbbStatus = new System.Windows.Forms.ComboBox();
            this.txtNameTopic = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TopicName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MajorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Enable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FromDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopic)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.grbUpdate.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Tomato;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(612, 54);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Snow;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(612, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ CHUYÊN ĐỀ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.dgvTopic);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(230, 54);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(382, 355);
            this.panel3.TabIndex = 2;
            // 
            // dgvTopic
            // 
            this.dgvTopic.AllowUserToAddRows = false;
            this.dgvTopic.AllowUserToDeleteRows = false;
            this.dgvTopic.BackgroundColor = System.Drawing.Color.White;
            this.dgvTopic.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTopic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopic.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.TopicName,
            this.MajorName,
            this.Enable,
            this.FromDate,
            this.ToDate});
            this.dgvTopic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTopic.Location = new System.Drawing.Point(0, 37);
            this.dgvTopic.Name = "dgvTopic";
            this.dgvTopic.ReadOnly = true;
            this.dgvTopic.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTopic.Size = new System.Drawing.Size(382, 318);
            this.dgvTopic.TabIndex = 4;
            this.dgvTopic.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTopic_CellClick);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.cbbFMajor);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(382, 37);
            this.panel4.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Lọc theo ngành";
            // 
            // cbbFMajor
            // 
            this.cbbFMajor.FormattingEnabled = true;
            this.cbbFMajor.Location = new System.Drawing.Point(117, 8);
            this.cbbFMajor.Name = "cbbFMajor";
            this.cbbFMajor.Size = new System.Drawing.Size(235, 24);
            this.cbbFMajor.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grbUpdate);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 54);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(230, 355);
            this.panel2.TabIndex = 1;
            // 
            // grbUpdate
            // 
            this.grbUpdate.BackColor = System.Drawing.Color.White;
            this.grbUpdate.Controls.Add(this.btnSubmit);
            this.grbUpdate.Controls.Add(this.dtpToDate);
            this.grbUpdate.Controls.Add(this.dtpFromDate);
            this.grbUpdate.Controls.Add(this.cbbStatus);
            this.grbUpdate.Controls.Add(this.txtNameTopic);
            this.grbUpdate.Controls.Add(this.label6);
            this.grbUpdate.Controls.Add(this.label5);
            this.grbUpdate.Controls.Add(this.label4);
            this.grbUpdate.Controls.Add(this.label2);
            this.grbUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbUpdate.Location = new System.Drawing.Point(0, 0);
            this.grbUpdate.Name = "grbUpdate";
            this.grbUpdate.Size = new System.Drawing.Size(230, 355);
            this.grbUpdate.TabIndex = 1;
            this.grbUpdate.TabStop = false;
            this.grbUpdate.Text = "Cập nhật chuyên đề";
            // 
            // btnSubmit
            // 
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.ForeColor = System.Drawing.Color.Coral;
            this.btnSubmit.Location = new System.Drawing.Point(78, 157);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(84, 33);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "Cập nhật";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(78, 119);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(142, 22);
            this.dtpToDate.TabIndex = 7;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(78, 89);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(142, 22);
            this.dtpFromDate.TabIndex = 6;
            // 
            // cbbStatus
            // 
            this.cbbStatus.FormattingEnabled = true;
            this.cbbStatus.Location = new System.Drawing.Point(78, 58);
            this.cbbStatus.Name = "cbbStatus";
            this.cbbStatus.Size = new System.Drawing.Size(142, 24);
            this.cbbStatus.TabIndex = 5;
            this.cbbStatus.SelectedIndexChanged += new System.EventHandler(this.cbbStatus_SelectedIndexChanged);
            // 
            // txtNameTopic
            // 
            this.txtNameTopic.Enabled = false;
            this.txtNameTopic.Location = new System.Drawing.Point(78, 28);
            this.txtNameTopic.Name = "txtNameTopic";
            this.txtNameTopic.Size = new System.Drawing.Size(142, 22);
            this.txtNameTopic.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "Đến ngày";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "Trạng thái";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Từ ngày";
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // TopicName
            // 
            this.TopicName.DataPropertyName = "TopicName";
            this.TopicName.HeaderText = "Tên chuyên đề";
            this.TopicName.Name = "TopicName";
            this.TopicName.ReadOnly = true;
            // 
            // MajorName
            // 
            this.MajorName.DataPropertyName = "MajorName";
            this.MajorName.HeaderText = "Chuyên ngành";
            this.MajorName.Name = "MajorName";
            this.MajorName.ReadOnly = true;
            // 
            // Enable
            // 
            this.Enable.DataPropertyName = "Enable";
            this.Enable.HeaderText = "Trạng thái";
            this.Enable.Name = "Enable";
            this.Enable.ReadOnly = true;
            // 
            // FromDate
            // 
            this.FromDate.DataPropertyName = "FromDate";
            this.FromDate.HeaderText = "Từ ngày";
            this.FromDate.Name = "FromDate";
            this.FromDate.ReadOnly = true;
            // 
            // ToDate
            // 
            this.ToDate.DataPropertyName = "ToDate";
            this.ToDate.HeaderText = "Đến ngày";
            this.ToDate.Name = "ToDate";
            this.ToDate.ReadOnly = true;
            // 
            // UCManageTopic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "UCManageTopic";
            this.Size = new System.Drawing.Size(612, 409);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopic)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.grbUpdate.ResumeLayout(false);
            this.grbUpdate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbFMajor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox grbUpdate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.ComboBox cbbStatus;
        private System.Windows.Forms.TextBox txtNameTopic;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvTopic;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TopicName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MajorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Enable;
        private System.Windows.Forms.DataGridViewTextBoxColumn FromDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToDate;
    }
}
