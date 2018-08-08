using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Conector;

namespace Admin
{
    public partial class UCManageMajor : UserControl
    {
        public delegate void ActionUpdate(string id);
        public static event ActionUpdate UpdateEvent;
        public UCManageMajor()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData()
        {
            var conn = new SqlConnection(DBEntity.GetConnection());
            conn.Open();
            var cmd = new SqlCommand("SELECT * FROM Major ", conn);
            //cmd.CommandType = CommandType.StoredProcedure;
            var tb = new DataTable();
            var adpt = new SqlDataAdapter(cmd);
            adpt.Fill(tb);
            conn.Close();
            var ds = new BindingSource();
            ds.DataSource = tb;
            dgvMajor.DataSource = ds;
            ds.ResetBindings(false);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            int numberTopical = int.Parse(nudNumberTopical.Value.ToString());
            if (String.IsNullOrEmpty(name))
            {
                lblMessage.Text = "Vui lòng nhập tên chuyên ngành!";
                return;
            }
            var conn = new SqlConnection(DBEntity.GetConnection());
            conn.Open();
            var cmd = new SqlCommand("InsertMajor", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@NumberTopical", numberTopical);
            int count = cmd.ExecuteNonQuery();
            conn.Close();
            if (count > 0)
            {
                lblMessage.Text = "Thành công!";
                //MessageBox.Show("", "Thông báo");
                LoadData();
            }
            else
            {
                lblMessage.Text = "Thất bại!";
                //MessageBox.Show("Thất bại!", "Thông báo");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            nudNumberTopical.Value = 0;
            lblMessage.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int rowIndex = dgvMajor.CurrentCell.RowIndex;
            if (rowIndex >= 0)
            {
                string id = dgvMajor.Rows[rowIndex].Cells[0].Value.ToString();
                var frm = new frmUpdateMajor();
                frm.EventUpdate += new frmUpdateMajor.UpdateAction(LoadData);
                frm.Show();
                UpdateEvent(id);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            DialogResult dr = MessageBox.Show("Xác nhận xóa?", "Xác nhận", MessageBoxButtons.YesNo,
        MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                int rowIndex = dgvMajor.CurrentCell.RowIndex;
                if (rowIndex >= 0)
                {
                    string id = dgvMajor.Rows[rowIndex].Cells[0].Value.ToString();
                    var conn = new SqlConnection(DBEntity.GetConnection());
                    conn.Open();
                    var cmd = new SqlCommand("DeleteMajor", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    
                    int count = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (count > 0)
                    {
                        lblMessage.Text = "Thành công!";
                        //MessageBox.Show("", "Thông báo");
                        LoadData();
                    }
                    else
                    {
                        lblMessage.Text = "Thất bại!";
                        //MessageBox.Show("Thất bại!", "Thông báo");
                    }
                }
            }


        }
    }
}
