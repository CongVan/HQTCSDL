using Conector;
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

namespace Admin
{
    public partial class frmAddUser : Form
    {
        public delegate void ReloadDataDelegate();
        public event ReloadDataDelegate InsertSuccess;
        
        public enum ActionType
        {
            Insert,Update
        }
        ActionType actionMain;
        string idUserUpdate = "";
        public frmAddUser()
        {
            InitializeComponent();
            LoadSourceGender();
            LoadSourceType();
            LoadSourceStatus();
            actionMain = ActionType.Insert;
            UCManageUser.ActionUpDate += new UCManageUser.ActionUpDateDelegate(LoadDataUpdate);
        }
        private void LoadSourceGender()
        {
            var sourceGender = new Dictionary<string, string>();
            sourceGender.Add("1", "Nam");
            sourceGender.Add("2", "Nữ");
            cbbGender.ValueMember = "Key";
            cbbGender.DisplayMember = "Value";

            cbbGender.DataSource = new BindingSource(sourceGender, null);
        }
        private void LoadSourceType()
        {
            var sourceGender = new Dictionary<string, string>();
            sourceGender.Add("1", "Admin");
            sourceGender.Add("2", "Giáo viên");
            sourceGender.Add("3", "Sinh viên");
            cbbType.ValueMember = "Key";
            cbbType.DisplayMember = "Value";

            cbbType.DataSource = new BindingSource(sourceGender, null);
        }
        private void LoadSourceStatus()
        {
            var sourceGender = new Dictionary<string, string>();
            sourceGender.Add("1", "Kích hoạt");
            sourceGender.Add("0", "Hủy");
            //sourceGender.Add("3", "Sinh viên");
            cbbStatus.ValueMember = "Key";
            cbbStatus.DisplayMember = "Value";

            cbbStatus.DataSource = new BindingSource(sourceGender, null);
        }
        private void LoadDataUpdate(string id)
        {
            idUserUpdate = id;
            lblTitleMain.Text = "CẬP NHẬT TÀI KHOẢN";
            this.Text = "Cập nhật tài khoản";
            var conn = new SqlConnection(DBEntity.GetConnection());
            conn.Open();
            var cmd = new SqlCommand("GetUserFromID", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            var tb = new DataTable();
            var adpt = new SqlDataAdapter(cmd);
            adpt.Fill(tb);
            if(tb==null || tb.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy tài khoản!", "Thông báo");
                return;
            }
            txtUserName.Text = tb.Rows[0]["UserName"].ToString();
            txtPassWord.Text = tb.Rows[0]["PassWord"].ToString();
            cbbType.SelectedValue = tb.Rows[0]["Type"].ToString();
            cbbStatus.SelectedValue = tb.Rows[0]["Enable"].ToString()=="True"?"1":"0";
            if (cbbStatus.SelectedValue.ToString() == "0")
            {
                string[] fd = tb.Rows[0]["FromDate"].ToString().Split('/');
                string[] td = tb.Rows[0]["ToDate"].ToString().Split('/');
                dtpFromDate.Value = new DateTime(int.Parse(fd[0]),int.Parse(fd[1]),int.Parse(fd[2]));
                dtpToDate.Value = new DateTime(int.Parse(td[0]), int.Parse(td[1]), int.Parse(td[2]));
            }
            if (cbbType.SelectedValue.ToString() == "3")
            {
                cmd.CommandText = "GetStudentFromUser";
                adpt.SelectCommand = cmd;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID", id);
                tb = new DataTable();
                adpt.Fill(tb);
                if (tb == null || tb.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy tài khoản!", "Thông báo");
                    return;
                }
                txtFullName.Text= tb.Rows[0]["FullName"].ToString();
                txtAdress.Text= tb.Rows[0]["Address"].ToString();
                cbbGender.SelectedValue= tb.Rows[0]["Gender"].ToString();
                string[] dob = tb.Rows[0]["DayOfBirth"].ToString().Split('/');
                dtpDayOfBirth.Value = new DateTime(int.Parse(dob[0]), int.Parse(dob[1]), int.Parse(dob[2]));

            }


        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (actionMain == ActionType.Update&& idUserUpdate=="")
            {
                MessageBox.Show("Không tìm thấy User!","Thông báo");
                return;
            }

            string userName = txtUserName.Text;
            string passWord = txtPassWord.Text;
            int Type = int.Parse(cbbType.SelectedValue.ToString());
            int Enable = int.Parse(cbbStatus.SelectedValue.ToString());
            string fromDate = Enable == 0 ? dtpFromDate.Value.ToString("yyyy/MM/dd") : null;
            string toDate = Enable == 0 ? dtpToDate.Value.ToString("yyyy/MM/dd") : null;
            string fullName = txtFullName.Text;
            int Gender = int.Parse(cbbGender.SelectedValue.ToString());
            string dayOfBirth = Type == 3 ? dtpDayOfBirth.Value.ToString("yyyy/MM/dd") : null;
            string address = txtAdress.Text;

            var conn = new SqlConnection(DBEntity.GetConnection());
            conn.Open();
            var cmd = new SqlCommand(actionMain==ActionType.Insert?"InsertUser":"UpdateUser", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", userName);
            cmd.Parameters.AddWithValue("@PassWord", passWord);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@Enable", Enable);
            if (fromDate == null)
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@FromDate", fromDate);
            }

            if (toDate == null)
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ToDate", toDate);
            }
            cmd.Parameters.AddWithValue("@FullName", fullName);
            cmd.Parameters.AddWithValue("@Gender", Gender);
            if (dayOfBirth == null)
            {
                cmd.Parameters.AddWithValue("@DayOfBirth", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@DayOfBirth", dayOfBirth);
            }
            //cmd.Parameters.AddWithValue("@DayOfBirth",dayOfBirth);
            cmd.Parameters.AddWithValue("@Address", address);
            if (actionMain == ActionType.Update)
            {
                cmd.Parameters.AddWithValue("@ID", idUserUpdate);
            }
            int count = cmd.ExecuteNonQuery();
            conn.Close();
            if (count > 0)
            {
                InsertSuccess();
                MessageBox.Show(null, "Thành công!", "Thông báo");
            }
            else
            {
                MessageBox.Show(null, "Thất bại!", "Thông báo");
            }

        }

        private void cbbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = cbbType.SelectedValue!=null?cbbType.SelectedValue.ToString():"";
            
            if (value == "3")
            {
                grbDetailMore.Enabled = true;
                for (int i = 0; i < grbDetailMore.Controls.Count; i++)
                {
                    grbDetailMore.Controls[i].Enabled = true;
                }
            }
            else
            {
                grbDetailMore.Enabled = false;
                for (int i = 0; i < grbDetailMore.Controls.Count; i++)
                {
                    grbDetailMore.Controls[i].Enabled = false;
                }
            }
        }

        private void cbbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = cbbStatus.SelectedValue != null ? cbbStatus.SelectedValue.ToString() : "";
           
            if (value == "0")
            {
                lblFromDate.Enabled = true;
                lblToDate.Enabled = true;
                dtpFromDate.Enabled = true;
                dtpToDate.Enabled = true;
            }
            else
            {
                lblFromDate.Enabled = false;
                lblToDate.Enabled = false;
                dtpFromDate.Enabled = false;
                dtpToDate.Enabled = false;
            }
        }
    }
}
