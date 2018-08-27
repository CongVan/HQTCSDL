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
        public frmStudent()
        {
            InitializeComponent();
        }

        private void btnManageTopic_Click(object sender, EventArgs e)
        {
            var control = new UCManageTopic();
            control.Dock = DockStyle.Fill;
            pnlContainer.Controls.Clear();
            pnlContainer.Controls.Add(control);
        }

        private void btnTransferTeam_Click(object sender, EventArgs e)
        {

        }
    }
}
