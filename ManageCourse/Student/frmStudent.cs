using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student
{
    public partial class frmStudent : Form
    {
        int idStudent = 0;
        public frmStudent(int id)
        {
            idStudent = id;
            InitializeComponent();
            btnLogout.Text += "- " + id;
        }
       
        private void btnManageTopic_Click(object sender, EventArgs e)
        {
            var control = new UCManageTopic(idStudent);
            control.Dock = DockStyle.Fill;
            pnlContainer.Controls.Clear();
            pnlContainer.Controls.Add(control);
        }

        private void btnTransferTeam_Click(object sender, EventArgs e)
        {
            var control = new UCTransferTeam(idStudent);
            control.Dock = DockStyle.Fill;
            pnlContainer.Controls.Clear();
            pnlContainer.Controls.Add(control);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmStudent_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
