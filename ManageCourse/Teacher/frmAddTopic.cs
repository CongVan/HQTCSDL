using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
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
                string connectionString = Conector.DBEntity.GetConnection();
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "InsertTopic";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Code", SqlDbType.VarChar).Value = txtTopicCode.Text;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = txtTopicName.Text;
                cmd.Parameters.Add("@Deadline", SqlDbType.DateTime).Value = dtpDeadline.Value.ToString("yyyy-MM-dd");
                cmd.Parameters.Add("@NumberTeam", SqlDbType.Int).Value = int.Parse(mudNumberTeam.Value.ToString());
                cmd.Parameters.Add("@NumberStudent", SqlDbType.Int).Value = int.Parse(mudNumberStudent.Value.ToString());
                cmd.Parameters.Add("@Enable", SqlDbType.Bit).Value = "True";
                cmd.Parameters.Add("@MajorID", SqlDbType.Int).Value = int.Parse(cbbMajor.SelectedValue.ToString());
                cmd.Parameters.Add("@TeacherID", SqlDbType.Int).Value = 1;  //  we have to change to CurUser

                cmd.Connection = conn;
                conn.Open();
                int count = cmd.ExecuteNonQuery();

                if (count > 0)
                {
                    MessageBox.Show("Thêm chuyên đề thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm chuyên đề không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                conn.Close();
            }
            else
            {
                return;
            }
        }


        private void frmAddTopic_Load(object sender, EventArgs e)
        {
            string connectionString = Conector.DBEntity.GetConnection();
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