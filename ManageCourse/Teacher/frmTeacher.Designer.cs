namespace Teacher
{
    partial class frmTeacher
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
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnTopicInfo = new System.Windows.Forms.Button();
            this.btnOpenTopic = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnLookUpScore = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.White;
            this.pnlMenu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlMenu.Controls.Add(this.btnTopicInfo);
            this.pnlMenu.Controls.Add(this.btnOpenTopic);
            this.pnlMenu.Controls.Add(this.btnLogout);
            this.pnlMenu.Controls.Add(this.btnLookUpScore);
            this.pnlMenu.Controls.Add(this.label1);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.ForeColor = System.Drawing.Color.Coral;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(222, 559);
            this.pnlMenu.TabIndex = 0;
            // 
            // btnTopicInfo
            // 
            this.btnTopicInfo.BackColor = System.Drawing.Color.White;
            this.btnTopicInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTopicInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTopicInfo.ForeColor = System.Drawing.Color.Coral;
            this.btnTopicInfo.Location = new System.Drawing.Point(7, 156);
            this.btnTopicInfo.Name = "btnTopicInfo";
            this.btnTopicInfo.Size = new System.Drawing.Size(205, 80);
            this.btnTopicInfo.TabIndex = 5;
            this.btnTopicInfo.Text = "Xem thông tin chuyên đề";
            this.btnTopicInfo.UseVisualStyleBackColor = false;
            // 
            // btnOpenTopic
            // 
            this.btnOpenTopic.BackColor = System.Drawing.Color.White;
            this.btnOpenTopic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenTopic.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenTopic.ForeColor = System.Drawing.Color.Coral;
            this.btnOpenTopic.Location = new System.Drawing.Point(7, 92);
            this.btnOpenTopic.Name = "btnOpenTopic";
            this.btnOpenTopic.Size = new System.Drawing.Size(205, 58);
            this.btnOpenTopic.TabIndex = 4;
            this.btnOpenTopic.Text = "Mở chuyên đề";
            this.btnOpenTopic.UseVisualStyleBackColor = false;
            this.btnOpenTopic.Click += new System.EventHandler(this.btnOpenTopic_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.OldLace;
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.Coral;
            this.btnLogout.Location = new System.Drawing.Point(0, 497);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(218, 58);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnLookUpScore
            // 
            this.btnLookUpScore.BackColor = System.Drawing.Color.White;
            this.btnLookUpScore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLookUpScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLookUpScore.ForeColor = System.Drawing.Color.Coral;
            this.btnLookUpScore.Location = new System.Drawing.Point(7, 242);
            this.btnLookUpScore.Name = "btnLookUpScore";
            this.btnLookUpScore.Size = new System.Drawing.Size(205, 58);
            this.btnLookUpScore.TabIndex = 2;
            this.btnLookUpScore.Text = "Tra cứu điểm";
            this.btnLookUpScore.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Tomato;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Snow;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 84);
            this.label1.TabIndex = 0;
            this.label1.Text = "GIÁO VIÊN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlContainer
            // 
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(222, 0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(670, 559);
            this.pnlContainer.TabIndex = 1;
            // 
            // frmTeacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 559);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.pnlMenu);
            this.Name = "frmTeacher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trang giáo viên";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTeacher_FormClosed);
            this.pnlMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.FlowLayoutPanel pnlContainer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLookUpScore;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnOpenTopic;
        private System.Windows.Forms.Button btnTopicInfo;
    }
}

