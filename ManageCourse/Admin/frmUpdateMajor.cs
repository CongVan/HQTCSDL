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
    public partial class frmUpdateMajor : Form
    {
        public delegate void UpdateAction();
        public event UpdateAction EventUpdate;
        private string idUpdate = "";
        public frmUpdateMajor()
        {
            InitializeComponent();
            UCManageMajor.UpdateEvent += this.UCManageMajor_UpdateEvent;
        }

        private void UCManageMajor_UpdateEvent(string id)
        {
            idUpdate = id;
            var conn = new SqlConnection(DBEntity.GetConnection());
            conn.Open();
            var cmd = new SqlCommand("SELECT * FROM Major WHERE ID=" + id, conn);

            var tb = new DataTable();
            var adpt = new SqlDataAdapter(cmd);
            adpt.Fill(tb);
            conn.Close();

            if (tb == null || tb.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy thông tin!", "Thông báo");
                return;

            }
            else
            {
                txtNameMajor.Text = tb.Rows[0]["Name"].ToString();
                nudNumberTopical.Value = int.Parse(tb.Rows[0]["NumberTopical"].ToString());
            }

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string name = txtNameMajor.Text;
            int numberTopical = int.Parse(nudNumberTopical.Value.ToString());
            if (String.IsNullOrEmpty(name))
            {
                MessageBox.Show("Vui lòng nhập tên chuyên ngành!", "Thông báo");
                return;
            }
            var conn = new SqlConnection(DBEntity.GetConnection());
            conn.Open();
            var cmd = new SqlCommand("UpdateMajor", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@NumberTopical", numberTopical);
            cmd.Parameters.AddWithValue("@ID", idUpdate);
            int count = cmd.ExecuteNonQuery();
            if (count > 0)
            {
                MessageBox.Show("Thành công!", "Thông báo");
                EventUpdate();
            }
            else
            {
                MessageBox.Show("Thất bại!", "Thông báo");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
