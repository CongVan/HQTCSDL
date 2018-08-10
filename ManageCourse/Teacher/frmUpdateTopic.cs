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
    public partial class frmUpdateTopic : Form
    {
        public frmUpdateTopic()
        {
            InitializeComponent();
        }


        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (KiemTraDuLieu())
            {
                var tb = MessageBox.Show(string.Format("Bạn có chắc chắn muốn chỉnh sửa thông tin chuyên đề {0} ?", lbTopicName.Text), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (tb == DialogResult.Yes)
                {
                    MessageBox.Show("Loading... ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    return;
                }
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            var tb = MessageBox.Show("Bạn có chắc chắn hủy việc chỉnh sửa chuyên đề ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (tb == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                return;
            }
        }


        private bool KiemTraDuLieu()
        {
            ErrorChecker.Clear();  //  giả sử ban đầu mọi dữ liệu là đúng

            if (mudNumberTeam.Value == 0)
            {
                ErrorChecker.BlinkRate = 500;
                ErrorChecker.SetError(mudNumberTeam, "Không được để trống.");
                return false;
            }
            if (mudNumberStudent.Value == 0)
            {
                ErrorChecker.BlinkRate = 500;
                ErrorChecker.SetError(mudNumberStudent, "Không được để trống.");
                return false;
            }
            else
            {
                ErrorChecker.Clear();
            }
            return true;
        }
    }
}