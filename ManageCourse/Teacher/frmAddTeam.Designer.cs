namespace Teacher
{
    partial class frmAddTeam
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
            this.lbTopicName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbTopicCode = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbTopicID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbNumberOfTeam = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTeamName = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ErrorChecker = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbNumberTeam = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorChecker)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.lblTitleMain.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitleMain.Name = "lblTitleMain";
            this.lblTitleMain.Size = new System.Drawing.Size(513, 50);
            this.lblTitleMain.TabIndex = 1;
            this.lblTitleMain.Text = "TẠO NHÓM";
            this.lblTitleMain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTopicName
            // 
            this.lbTopicName.AutoSize = true;
            this.lbTopicName.Location = new System.Drawing.Point(193, 85);
            this.lbTopicName.Name = "lbTopicName";
            this.lbTopicName.Size = new System.Drawing.Size(91, 16);
            this.lbTopicName.TabIndex = 9;
            this.lbTopicName.Text = "lbTopicName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Tên chuyên đề";
            // 
            // lbTopicCode
            // 
            this.lbTopicCode.AutoSize = true;
            this.lbTopicCode.Location = new System.Drawing.Point(193, 43);
            this.lbTopicCode.Name = "lbTopicCode";
            this.lbTopicCode.Size = new System.Drawing.Size(87, 16);
            this.lbTopicCode.TabIndex = 7;
            this.lbTopicCode.Text = "lbTopicCode";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Mã chuyên đề";
            // 
            // lbTopicID
            // 
            this.lbTopicID.AutoSize = true;
            this.lbTopicID.Location = new System.Drawing.Point(369, 43);
            this.lbTopicID.Name = "lbTopicID";
            this.lbTopicID.Size = new System.Drawing.Size(67, 16);
            this.lbTopicID.TabIndex = 17;
            this.lbTopicID.Text = "lbTopicID";
            this.lbTopicID.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "Số lượng nhóm hiện tại";
            // 
            // lbNumberOfTeam
            // 
            this.lbNumberOfTeam.AutoSize = true;
            this.lbNumberOfTeam.Location = new System.Drawing.Point(193, 127);
            this.lbNumberOfTeam.Name = "lbNumberOfTeam";
            this.lbNumberOfTeam.Size = new System.Drawing.Size(116, 16);
            this.lbNumberOfTeam.TabIndex = 19;
            this.lbNumberOfTeam.Text = "lbNumberOfTeam";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 16);
            this.label4.TabIndex = 20;
            this.label4.Text = "Tên nhóm";
            // 
            // txtTeamName
            // 
            this.txtTeamName.Location = new System.Drawing.Point(196, 38);
            this.txtTeamName.Name = "txtTeamName";
            this.txtTeamName.Size = new System.Drawing.Size(210, 22);
            this.txtTeamName.TabIndex = 21;
            this.txtTeamName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTeamName_KeyPress);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.Coral;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.Color.Snow;
            this.btnSubmit.Location = new System.Drawing.Point(215, 400);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(108, 39);
            this.btnSubmit.TabIndex = 22;
            this.btnSubmit.Text = "Hoàn tất";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Coral;
            this.btnCancel.Location = new System.Drawing.Point(347, 400);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(108, 39);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "Đóng";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ErrorChecker
            // 
            this.ErrorChecker.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbNumberTeam);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lbTopicCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lbTopicID);
            this.groupBox1.Controls.Add(this.lbTopicName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lbNumberOfTeam);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(28, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(453, 214);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chuyên đề";
            // 
            // lbNumberTeam
            // 
            this.lbNumberTeam.AutoSize = true;
            this.lbNumberTeam.Location = new System.Drawing.Point(193, 168);
            this.lbNumberTeam.Name = "lbNumberTeam";
            this.lbNumberTeam.Size = new System.Drawing.Size(103, 16);
            this.lbNumberTeam.TabIndex = 21;
            this.lbNumberTeam.Text = "lbNumberTeam";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 16);
            this.label5.TabIndex = 20;
            this.label5.Text = "Số lượng nhóm tối đa";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtTeamName);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(28, 281);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(453, 88);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin nhóm";
            // 
            // frmAddTeam
            // 
            this.AcceptButton = this.btnSubmit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(513, 458);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lblTitleMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmAddTeam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tạo nhóm";
            ((System.ComponentModel.ISupportInitialize)(this.ErrorChecker)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitleMain;
        public System.Windows.Forms.Label lbTopicName;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lbTopicCode;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lbTopicID;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lbNumberOfTeam;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTeamName;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ErrorProvider ErrorChecker;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label lbNumberTeam;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}