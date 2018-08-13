using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
                    try
                    {
                        string connectionString = Conector.DBEntity.GetConnection();
                        SqlConnection conn = new SqlConnection(connectionString);
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = "UpdateTopic";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@MajorID", SqlDbType.Int).Value = int.Parse(lbMajorID.Text);
                        cmd.Parameters.Add("@TopicCode", SqlDbType.VarChar).Value = lbTopicCode.Text;
                        cmd.Parameters.Add("@Deadline", SqlDbType.DateTime).Value = dtpDeadline.Value.ToString("yyyy-MM-dd");
                        cmd.Parameters.Add("@NumberTeam", SqlDbType.Int).Value = int.Parse(mudNumberTeam.Value.ToString());
                        cmd.Parameters.Add("@NumberStudent", SqlDbType.Int).Value = int.Parse(mudNumberStudent.Value.ToString());

                        cmd.Connection = conn;
                        conn.Open();
                        int count = cmd.ExecuteNonQuery();

                        if (count > 0)
                        {
                            MessageBox.Show(string.Format("Sửa thông tin chuyên đề {0} thành công!", lbTopicName.Text), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Sửa thông tin chuyên đề không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        conn.Close();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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