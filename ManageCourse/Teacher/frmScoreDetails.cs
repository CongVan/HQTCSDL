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
    public partial class frmScoreDetails : Form
    {
        public frmScoreDetails()
        {
            InitializeComponent();
        }


        private void frmScoreDetails_Load(object sender, EventArgs e)
        {
            cbbSemester.SelectedIndex = 0;
        }
    }
}