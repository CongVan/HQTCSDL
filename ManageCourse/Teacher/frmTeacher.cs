using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Teacher
{
    public partial class frmTeacher : Form
    {
        public frmTeacher()
        {
            InitializeComponent();
        }

        private void frmTeacher_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void btnOpenTopic_Click(object sender, EventArgs e)
        {
            frmAddTopic frm = new frmAddTopic();
            frm.ShowDialog();
        }


        private void btnTopicInfo_Click(object sender, EventArgs e)
        {
            var control = new UCManageTopic();
            control.Width = pnlContainer.Width;
            control.Height = pnlContainer.Height;
            pnlContainer.Controls.Clear();
            pnlContainer.Controls.Add(control);
        }


        private void btnLookUpScore_Click(object sender, EventArgs e)
        {
            var control = new UCManageStudent();
            control.Width = pnlContainer.Width;
            control.Height = pnlContainer.Height;
            pnlContainer.Controls.Clear();
            pnlContainer.Controls.Add(control);
        }


        // resize UserControl after resized frmTeacher
        private void frmTeacher_SizeChanged(object sender, EventArgs e)
        {
            if (pnlContainer.Controls.Count > 0)
            {
                foreach (Control control in pnlContainer.Controls)
                {
                    control.Width = pnlContainer.Width;
                    control.Height = pnlContainer.Height;
                }
            }
        }
    }
}