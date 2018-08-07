using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin
{
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
        }

        private void frmAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnManagerUser_Click(object sender, EventArgs e)
        {
            var control = new UCManageUser();
            control.Width = pnlContainer.Width;
            control.Height = pnlContainer.Height;
            pnlContainer.Controls.Clear();
            pnlContainer.Controls.Add(control);
        }
    }
}
