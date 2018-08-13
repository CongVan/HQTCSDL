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
    public partial class frmScoreDetails : Form
    {
        DataTable dt = new DataTable();

        public frmScoreDetails()
        {
            InitializeComponent();
        }


        private void frmScoreDetails_Load(object sender, EventArgs e)
        {
            cbbSemester.SelectedIndex = 0;
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = Conector.DBEntity.GetConnection();
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = "LookUpScore";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@StudentID", SqlDbType.Int).Value = int.Parse(lbStudentID.Text);
                cmd.Parameters.Add("@Semester", SqlDbType.Int).Value = cbbSemester.SelectedItem;
                cmd.Parameters.Add("@Year", SqlDbType.Int).Value = dtpYear.Value.Year;
                cmd.Connection = conn;

                conn.Open();

                reader = cmd.ExecuteReader();
                // Data is accessible through the DataReader object here.

                DataTable dt = new DataTable();
                dt.Columns.Add("TopicCode", typeof(string));
                dt.Columns.Add("TopicName", typeof(string));
                dt.Columns.Add("Point", typeof(decimal));

                while (reader.Read())
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = reader.GetString(reader.GetOrdinal("TopicCode"));
                    dr[1] = reader.GetString(reader.GetOrdinal("TopicName"));
                    dr[2] = reader.GetDecimal(reader.GetOrdinal("Point"));
                    dt.Rows.Add(dr);
                }

                dgvScore.DataSource = dt;

                conn.Close();
            }
            catch (SqlException ex)
            {
                ((DataTable)dgvScore.DataSource).Rows.Clear();  // xóa tất cả các dòng kết quả hiện có của DataGridView
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}