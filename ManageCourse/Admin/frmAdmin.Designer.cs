namespace Admin
{
    partial class frmAdmin
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
            this.btnManagerUser = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnManageTopic = new System.Windows.Forms.Button();
            this.btnManageMajor = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.pnlMenu.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.White;
            this.pnlMenu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlMenu.Controls.Add(this.btnManagerUser);
            this.pnlMenu.Controls.Add(this.btnLogout);
            this.pnlMenu.Controls.Add(this.btnManageTopic);
            this.pnlMenu.Controls.Add(this.btnManageMajor);
            this.pnlMenu.Controls.Add(this.panel3);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.ForeColor = System.Drawing.Color.Coral;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(222, 561);
            this.pnlMenu.TabIndex = 0;
            // 
            // btnManagerUser
            // 
            this.btnManagerUser.BackColor = System.Drawing.Color.White;
            this.btnManagerUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManagerUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManagerUser.Location = new System.Drawing.Point(8, 90);
            this.btnManagerUser.Name = "btnManagerUser";
            this.btnManagerUser.Size = new System.Drawing.Size(205, 58);
            this.btnManagerUser.TabIndex = 2;
            this.btnManagerUser.Text = "Người dùng";
            this.btnManagerUser.UseVisualStyleBackColor = false;
            this.btnManagerUser.Click += new System.EventHandler(this.btnManagerUser_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.OldLace;
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(0, 512);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(218, 45);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnManageTopic
            // 
            this.btnManageTopic.BackColor = System.Drawing.Color.White;
            this.btnManageTopic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageTopic.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageTopic.Location = new System.Drawing.Point(8, 218);
            this.btnManageTopic.Name = "btnManageTopic";
            this.btnManageTopic.Size = new System.Drawing.Size(205, 58);
            this.btnManageTopic.TabIndex = 4;
            this.btnManageTopic.Text = "Chuyên đề";
            this.btnManageTopic.UseVisualStyleBackColor = false;
            this.btnManageTopic.Click += new System.EventHandler(this.btnManageTopic_Click);
            // 
            // btnManageMajor
            // 
            this.btnManageMajor.BackColor = System.Drawing.Color.White;
            this.btnManageMajor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageMajor.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageMajor.Location = new System.Drawing.Point(8, 154);
            this.btnManageMajor.Name = "btnManageMajor";
            this.btnManageMajor.Size = new System.Drawing.Size(205, 58);
            this.btnManageMajor.TabIndex = 3;
            this.btnManageMajor.Text = "Chuyên ngành";
            this.btnManageMajor.UseVisualStyleBackColor = false;
            this.btnManageMajor.Click += new System.EventHandler(this.btnManageMajor_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Tomato;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(218, 84);
            this.panel3.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Snow;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 84);
            this.label1.TabIndex = 0;
            this.label1.Text = "ADMIN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlContainer
            // 
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(222, 0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(662, 561);
            this.pnlContainer.TabIndex = 1;
            // 
            // frmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.pnlMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trang quản trị Admin";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAdmin_FormClosed);
            this.pnlMenu.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnManageTopic;
        private System.Windows.Forms.Button btnManageMajor;
        private System.Windows.Forms.Button btnManagerUser;
    }
}

