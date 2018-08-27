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
    public partial class frmAddTeam : Form
    {
        public frmAddTeam()
        {
            InitializeComponent();
        }


        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (KiemTraDuLieu())
            {
                var tb = MessageBox.Show(string.Format("Bạn có chắc chắn muốn tạo nhóm <{0}> ?", txtTeamName.Text), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (tb == DialogResult.Yes)
                {
                    try
                    {
                        string connectionString = Conector.DBEntity.GetConnection();
                        SqlConnection conn = new SqlConnection(connectionString);
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = "InsertTeam";
                        cmd.CommandType = CommandType.StoredProcedure;
                        
                        cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = txtTeamName.Text;
                        cmd.Parameters.Add("@TopicID", SqlDbType.Int).Value = int.Parse(lbTopicID.Text);
                        cmd.Parameters.Add("@Enable", SqlDbType.Bit).Value = "True";

                        cmd.Connection = conn;
                        conn.Open();
                        int count = cmd.ExecuteNonQuery();

                        if (count > 0)
                        {
                            MessageBox.Show(string.Format("Tạo nhóm <{0}> thành công!", txtTeamName.Text), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Tạo nhóm không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        private bool KiemTraDuLieu()
        {
            ErrorChecker.Clear();  //  giả sử ban đầu mọi dữ liệu là đúng
            
            if (string.IsNullOrWhiteSpace(txtTeamName.Text))
            {
                ErrorChecker.BlinkRate = 500;
                ErrorChecker.SetError(txtTeamName, "Không được để trống.");
                return false;
            }
            else
            {
                ErrorChecker.Clear();
            }
            return true;
        }


        /// <summary>
        /// Không được nhập ký tự đặc biệt ở ô Tên nhóm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTeamName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (char.IsLetter(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsWhiteSpace(e.KeyChar) == true || char.IsDigit(e.KeyChar) == true)
            {
                e.Handled = false;
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
