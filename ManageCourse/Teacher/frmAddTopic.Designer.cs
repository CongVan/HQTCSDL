namespace Teacher
{
    partial class frmAddTopic
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTopicName = new System.Windows.Forms.TextBox();
            this.txtTopicCode = new System.Windows.Forms.TextBox();
            this.cbbMajor = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.mudNumberStudent = new System.Windows.Forms.NumericUpDown();
            this.mudNumberTeam = new System.Windows.Forms.NumericUpDown();
            this.dtpDeadline = new System.Windows.Forms.DateTimePicker();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.ErrorChecker = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.lblTitleMain.Size = new System.Drawing.Size(445, 41);
            this.lblTitleMain.TabIndex = 0;
            this.lblTitleMain.Text = "MỞ CHUYÊN ĐỀ";
            this.lblTitleMain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTopicName);
            this.groupBox1.Controls.Add(this.txtTopicCode);
            this.groupBox1.Controls.Add(this.cbbMajor);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(21, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 182);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chuyên đề";
            // 
            // txtTopicName
            // 
            this.txtTopicName.Location = new System.Drawing.Point(149, 123);
            this.txtTopicName.Name = "txtTopicName";
            this.txtTopicName.Size = new System.Drawing.Size(222, 22);
            this.txtTopicName.TabIndex = 5;
            this.txtTopicName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTopicName_KeyPress);
            // 
            // txtTopicCode
            // 
            this.txtTopicCode.Location = new System.Drawing.Point(149, 78);
            this.txtTopicCode.Name = "txtTopicCode";
            this.txtTopicCode.Size = new System.Drawing.Size(223, 22);
            this.txtTopicCode.TabIndex = 4;
            this.txtTopicCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTopicCode_KeyPress);
            // 
            // cbbMajor
            // 
            this.cbbMajor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMajor.FormattingEnabled = true;
            this.cbbMajor.Location = new System.Drawing.Point(149, 34);
            this.cbbMajor.Name = "cbbMajor";
            this.cbbMajor.Size = new System.Drawing.Size(223, 24);
            this.cbbMajor.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên chuyên đề";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã chuyên đề";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chuyên ngành";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Deadline";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Số nhóm tối đa";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Số sinh viên tối đa";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.mudNumberStudent);
            this.groupBox2.Controls.Add(this.mudNumberTeam);
            this.groupBox2.Controls.Add(this.dtpDeadline);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(21, 268);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(401, 189);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin chi tiết";
            // 
            // mudNumberStudent
            // 
            this.mudNumberStudent.Location = new System.Drawing.Point(149, 123);
            this.mudNumberStudent.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.mudNumberStudent.Name = "mudNumberStudent";
            this.mudNumberStudent.Size = new System.Drawing.Size(222, 22);
            this.mudNumberStudent.TabIndex = 8;
            // 
            // mudNumberTeam
            // 
            this.mudNumberTeam.Location = new System.Drawing.Point(149, 81);
            this.mudNumberTeam.Name = "mudNumberTeam";
            this.mudNumberTeam.Size = new System.Drawing.Size(222, 22);
            this.mudNumberTeam.TabIndex = 7;
            // 
            // dtpDeadline
            // 
            this.dtpDeadline.CustomFormat = "";
            this.dtpDeadline.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDeadline.Location = new System.Drawing.Point(149, 37);
            this.dtpDeadline.Name = "dtpDeadline";
            this.dtpDeadline.Size = new System.Drawing.Size(222, 22);
            this.dtpDeadline.TabIndex = 6;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.Coral;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.Color.Snow;
            this.btnSubmit.Location = new System.Drawing.Point(189, 473);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(108, 39);
            this.btnSubmit.TabIndex = 3;
            this.btnSubmit.Text = "Hoàn tất";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Coral;
            this.btnClose.Location = new System.Drawing.Point(313, 473);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(108, 39);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ErrorChecker
            // 
            this.ErrorChecker.ContainerControl = this;
            // 
            // frmAddTopic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(445, 517);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTitleMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmAddTopic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mở chuyên đề";
            this.Load += new System.EventHandler(this.frmAddTopic_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mudNumberStudent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mudNumberTeam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorChecker)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitleMain;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbbMajor;
        private System.Windows.Forms.TextBox txtTopicCode;
        private System.Windows.Forms.TextBox txtTopicName;
        private System.Windows.Forms.DateTimePicker dtpDeadline;
        private System.Windows.Forms.NumericUpDown mudNumberStudent;
        private System.Windows.Forms.NumericUpDown mudNumberTeam;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ErrorProvider ErrorChecker;
    }
}