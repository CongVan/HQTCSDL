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
    }
}