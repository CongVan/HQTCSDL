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
    public partial class UCManageUser : UserControl
    {
        string connectionString = DBEntity.GetConnection();

        public delegate void ActionUpDateDelegate(string id);
        public static event ActionUpDateDelegate ActionUpDate;
        
       
        public UCManageUser()
        {
            InitializeComponent();


            this.Dock = DockStyle.Fill;
            this.AutoSize = true;
            this.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left);
            LoadData();
            
        }
        private void LoadData()
        {
            var conn = new SqlConnection(connectionString);
            conn.Open();
            var cmd = new SqlCommand("GetAllUser", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            var tb = new DataTable();
            var adpt = new SqlDataAdapter(cmd);
            adpt.Fill(tb);
            conn.Close();
            var ds = new BindingSource();
            ds.DataSource = tb;
            dgvUsers.DataSource = ds;
            ds.ResetBindings(false);
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            var frm = new frmAddUser();
            frm.InsertSuccess += new frmAddUser.ReloadDataDelegate(Frm_InsertSuccess);
            frm.Show();
        }

        private void Frm_InsertSuccess()
        {
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Xác nhận xóa?", "Xác nhận", MessageBoxButtons.YesNo,
        MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
               
                int rowIndex = dgvUsers.CurrentCell.RowIndex;
                if ( rowIndex >= 0)
                {
                    var id = dgvUsers.Rows[rowIndex].Cells[0].Value.ToString();
                    var conn = new SqlConnection(connectionString);
                    conn.Open();
                    var cmd = new SqlCommand("DeleteUser", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);

                    int count = cmd.ExecuteNonQuery();
                    if (count > 0)
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo");
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!", "Thông báo");
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int rowIndex = dgvUsers.CurrentCell.RowIndex;
            if (rowIndex >= 0)
            {
                var id = dgvUsers.Rows[rowIndex].Cells[0].Value.ToString();

                var form = new frmAddUser();
                
               
                form.Show();
                ActionUpDate(id);
            }
        }

       
    }
}
