using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Admin;
using Teacher;
using Student;
using Conector;
using System.Data.SqlClient;

namespace Login
{
    public partial class frmLogin : Form
    {
        string connectionString = DBEntity.GetConnection();
        public frmLogin()
        {
            InitializeComponent();
            //DBEntity.GetConnection();
        }
        
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {       
           Logining();
        }
        private void Logining()
        {
            string userName = txtUserName.Text.Trim();
            string passWord = txtPassWord.Text.Trim();
            var conn = new SqlConnection(connectionString);
            conn.Open();
            var cmd = new SqlCommand("GetUser", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", userName);
            cmd.Parameters.AddWithValue("@PassWord", passWord);
            var tb = new DataTable();
            var adpt = new SqlDataAdapter(cmd);
            adpt.Fill(tb);
            conn.Close();
            if (tb == null || tb.Rows.Count == 0)
            {
                MessageBox.Show(null, "Tên đăng nhập / mật khẩu không đúng!","Thông báo");
            }
            else
            {
                int type = int.Parse(tb.Rows[0]["Type"].ToString());
                switch (type)
                {
                    case 1://admin
                        {
                            var frm = new frmAdmin();
                            frm.Show();
                            break;
                        }
                    case 2://teacher
                        {
                            var frm = new frmTeacher();
                            frm.Show();
                            break;
                        }
                    case 3://student
                        {
                            var frm = new frmStudent();
                            frm.Show();
                            break;
                        }
                    default:
                        break;
                }
                this.Hide();
            }
           
        }
        private void txtPassWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Logining();
            }
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
