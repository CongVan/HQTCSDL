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
            var cmd = new SqlCommand("SELECT ID,UserName,Type,Enable,FromDate,ToDate FROM [User] ", conn);          
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
            
        }
    }
}
