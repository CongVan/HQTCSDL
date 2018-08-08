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
    public partial class frmAddTopic : Form
    {
        public frmAddTopic()
        {
            InitializeComponent();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var tb = MessageBox.Show("Bạn có chắc chắn muốn thêm chuyên đề ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (tb == DialogResult.Yes)
            {
                MessageBox.Show("Chức năng đang được bảo trì!", "Hãy thử lại sau", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                return;
            }
        }


        private void frmAddTopic_Load(object sender, EventArgs e)
        {
            string dataSource = @"DESKTOP-K5LOBGC";
            string connectionString = @"Data Source=" + dataSource + ";Initial Catalog=ManageCourse;Integrated Security=True";


            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "GetMajor";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;

            conn.Open();

            reader = cmd.ExecuteReader();
            // Data is accessible through the DataReader object here.

            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("MajorName", typeof(string));

            while (reader.Read())
            {
                DataRow dr = dt.NewRow();
                dr[0] = reader.GetInt32(reader.GetOrdinal("ID"));
                dr[1] = reader.GetString(reader.GetOrdinal("Name"));
                dt.Rows.Add(dr);
            }

            cbbMajor.DataSource = dt;
            cbbMajor.ValueMember = "Id";
            cbbMajor.DisplayMember = "MajorName";

            conn.Close();
        }
    }
}
