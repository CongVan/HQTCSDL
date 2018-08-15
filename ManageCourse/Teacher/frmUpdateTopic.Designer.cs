namespace Teacher
{
    partial class frmUpdateTopic
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
            this.components = new System.ComponentModel.Container();
            this.lblTitleMain = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbTopicCode = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbTopicName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.mudNumberStudent = new System.Windows.Forms.NumericUpDown();
            this.mudNumberTeam = new System.Windows.Forms.NumericUpDown();
            this.dtpDeadline = new System.Windows.Forms.DateTimePicker();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lbMajorCode = new System.Windows.Forms.Label();
            this.ErrorChecker = new System.Windows.Forms.ErrorProvider(this.components);
            this.lbMajorID = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mudNumberStudent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mudNumberTeam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorChecker)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitleMain
            // 
            this.lblTitleMain.BackColor = System.Drawing.Color.Tomato;
            this.lblTitleMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitleMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitleMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleMain.ForeColor = System.Drawing.Color.Snow;
            this.lblTitleMain.Location = new System.Drawing.Point(0, 0);
            this.lblTitleMain.Name = "lblTitleMain";
            this.lblTitleMain.Size = new System.Drawing.Size(470, 41);
            this.lblTitleMain.TabIndex = 1;
            this.lblTitleMain.Text = "CẬP NHẬT CHUYÊN ĐỀ";
            this.lblTitleMain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mã chuyên đề";
            // 
            // lbTopicCode
            // 
            this.lbTopicCode.AutoSize = true;
            this.lbTopicCode.Location = new System.Drawing.Point(178, 120);
            this.lbTopicCode.Name = "lbTopicCode";
            this.lbTopicCode.Size = new System.Drawing.Size(87, 16);
            this.lbTopicCode.TabIndex = 3;
            this.lbTopicCode.Text = "lbTopicCode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tên chuyên đề";
            // 
            // lbTopicName
            // 
            this.lbTopicName.AutoSize = true;
            this.lbTopicName.Location = new System.Drawing.Point(178, 168);
            this.lbTopicName.Name = "lbTopicName";
            this.lbTopicName.Size = new System.Drawing.Size(91, 16);
            this.lbTopicName.TabIndex = 5;
            this.lbTopicName.Text = "lbTopicName";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Deadline";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 264);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Số nhóm tối đa";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 312);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Số sinh viên tối đa";
            // 
            // mudNumberStudent
            // 
            this.mudNumberStudent.Location = new System.Drawing.Point(178, 310);
            this.mudNumberStudent.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.mudNumberStudent.Name = "mudNumberStudent";
            this.mudNumberStudent.Size = new System.Drawing.Size(132, 22);
            this.mudNumberStudent.TabIndex = 11;
            // 
            // mudNumberTeam
            // 
            this.mudNumberTeam.Location = new System.Drawing.Point(178, 262);
            this.mudNumberTeam.Name = "mudNumberTeam";
            this.mudNumberTeam.Size = new System.Drawing.Size(132, 22);
            this.mudNumberTeam.TabIndex = 10;
            // 
            // dtpDeadline
            // 
            this.dtpDeadline.CustomFormat = "";
            this.dtpDeadline.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDeadline.Location = new System.Drawing.Point(178, 211);
            this.dtpDeadline.Name = "dtpDeadline";
            this.dtpDeadline.Size = new System.Drawing.Size(132, 22);
            this.dtpDeadline.TabIndex = 9;
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Coral;
            this.btnCancel.Location = new System.Drawing.Point(316, 379);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(108, 39);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.Coral;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.Color.Snow;
            this.btnSubmit.Location = new System.Drawing.Point(191, 379);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(108, 39);
            this.btnSubmit.TabIndex = 12;
            this.btnSubmit.Text = "Cập nhật";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "Mã ngành";
            // 
            // lbMajorCode
            // 
            this.lbMajorCode.AutoSize = true;
            this.lbMajorCode.Location = new System.Drawing.Point(178, 78);
            this.lbMajorCode.Name = "lbMajorCode";
            this.lbMajorCode.Size = new System.Drawing.Size(86, 16);
            this.lbMajorCode.TabIndex = 15;
            this.lbMajorCode.Text = "lbMajorCode";
            // 
            // ErrorChecker
            // 
            this.ErrorChecker.ContainerControl = this;
            // 
            // lbMajorID
            // 
            this.lbMajorID.AutoSize = true;
            this.lbMajorID.Location = new System.Drawing.Point(346, 78);
            this.lbMajorID.Name = "lbMajorID";
            this.lbMajorID.Size = new System.Drawing.Size(66, 16);
            this.lbMajorID.TabIndex = 16;
            this.lbMajorID.Text = "lbMajorID";
            this.lbMajorID.Visible = false;
            // 
            // frmUpdateTopic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(470, 455);
            this.Controls.Add(this.lbMajorID);
            this.Controls.Add(this.lbMajorCode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.mudNumberStudent);
            this.Controls.Add(this.mudNumberTeam);
            this.Controls.Add(this.dtpDeadline);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbTopicName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbTopicCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitleMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmUpdateTopic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cập nhật thông tin";
            ((System.ComponentModel.ISupportInitialize)(this.mudNumberStudent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mudNumberTeam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorChecker)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitleMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSubmit;
        public System.Windows.Forms.Label lbTopicCode;
        public System.Windows.Forms.Label lbTopicName;
        public System.Windows.Forms.NumericUpDown mudNumberStudent;
        public System.Windows.Forms.NumericUpDown mudNumberTeam;
        public System.Windows.Forms.DateTimePicker dtpDeadline;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label lbMajorCode;
        private System.Windows.Forms.ErrorProvider ErrorChecker;
        public System.Windows.Forms.Label lbMajorID;
    }
}