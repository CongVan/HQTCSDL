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

namespace Teacher
{
    public partial class UCManageTopic : UserControl
    {
        private static int TeacherID = 1;  //  we have to change to CurUser's ID

        public UCManageTopic()
        {
            InitializeComponent();
        }


        private void UCManageTopic_Load(object sender, EventArgs e)
        {
            LoadData();
        }


        /// <summary>
        /// Load danh sách chuyên đề vào datagridview
        /// </summary>
        private void LoadData()
        {
            string connectionString = Conector.DBEntity.GetConnection();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "GetTopics";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TeacherID", SqlDbType.Int).Value = TeacherID;
            cmd.Connection = conn;

            conn.Open();

            reader = cmd.ExecuteReader();
            // Data is accessible through the DataReader object here.

            DataTable dt = new DataTable();
            //dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Code", typeof(string));
            dt.Columns.Add("TopicName", typeof(string));
            dt.Columns.Add("MajorName", typeof(string));
            dt.Columns.Add("Deadline", typeof(DateTime));
            dt.Columns.Add("NumberTeam", typeof(int));
            dt.Columns.Add("NumberStudent", typeof(int));
            dt.Columns.Add("Enable", typeof(string));
            //dt.Columns.Add("FromDate", typeof(DateTime));
            //dt.Columns.Add("ToDate", typeof(DateTime));

            while (reader.Read())
            {
                DataRow dr = dt.NewRow();
                //dr[0] = reader.GetInt32(reader.GetOrdinal("ID"));
                dr[0] = reader.GetString(reader.GetOrdinal("Code"));
                dr[1] = reader.GetString(reader.GetOrdinal("TopicName"));
                dr[2] = reader.GetString(reader.GetOrdinal("MajorName"));
                dr[3] = reader.GetDateTime(reader.GetOrdinal("Deadline"));
                dr[4] = reader.GetInt32(reader.GetOrdinal("NumberTeam"));
                dr[5] = reader.GetInt32(reader.GetOrdinal("NumberStudent"));
                if (reader.GetBoolean(reader.GetOrdinal("Enable")) == true)
                {
                    dr[6] = "Đang mở";
                }
                if (reader.GetBoolean(reader.GetOrdinal("Enable")) == false)
                {
                    dr[6] = "Hủy";
                }
                //dr[7] = reader.GetDateTime(reader.GetOrdinal("FromDate"));
                //dr[8] = reader.GetDateTime(reader.GetOrdinal("ToDate"));
                dt.Rows.Add(dr);
            }

            dgvTopics.DataSource = dt;

            conn.Close();
        }
    }
}