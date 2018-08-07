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

        private void frmStudent_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
