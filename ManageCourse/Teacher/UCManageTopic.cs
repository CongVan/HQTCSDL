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
            dt.Columns.Add("MajorID", typeof(int));
            dt.Columns.Add("TopicID", typeof(int));
            dt.Columns.Add("TopicCode", typeof(string));
            dt.Columns.Add("TopicName", typeof(string));
            dt.Columns.Add("MajorCode", typeof(string));
            dt.Columns.Add("MajorName", typeof(string));
            dt.Columns.Add("Deadline", typeof(DateTime));
            dt.Columns.Add("NumberOfTeam", typeof(int));
            dt.Columns.Add("NumberTeam", typeof(int));
            dt.Columns.Add("NumberStudent", typeof(int));
            dt.Columns.Add("Enable", typeof(string));
            //dt.Columns.Add("FromDate", typeof(DateTime));
            //dt.Columns.Add("ToDate", typeof(DateTime));

            while (reader.Read())
            {
                DataRow dr = dt.NewRow();
                dr[0] = reader.GetInt32(reader.GetOrdinal("MajorID"));
                dr[1] = reader.GetInt32(reader.GetOrdinal("TopicID"));
                dr[2] = reader.GetString(reader.GetOrdinal("TopicCode"));
                dr[3] = reader.GetString(reader.GetOrdinal("TopicName"));
                dr[4] = reader.GetString(reader.GetOrdinal("MajorCode"));
                dr[5] = reader.GetString(reader.GetOrdinal("MajorName"));
                dr[6] = reader.GetDateTime(reader.GetOrdinal("Deadline"));
                dr[7] = reader.GetInt32(reader.GetOrdinal("NumberOfTeam"));
                dr[8] = reader.GetInt32(reader.GetOrdinal("NumberTeam"));
                dr[9] = reader.GetInt32(reader.GetOrdinal("NumberStudent"));
                if (reader.GetBoolean(reader.GetOrdinal("Enable")) == true)
                {
                    dr[10] = "Đang mở";
                }
                if (reader.GetBoolean(reader.GetOrdinal("Enable")) == false)
                {
                    dr[10] = "Hủy";
                }
                //dr[11] = reader.GetDateTime(reader.GetOrdinal("FromDate"));
                //dr[12] = reader.GetDateTime(reader.GetOrdinal("ToDate"));
                dt.Rows.Add(dr);
            }

            dgvTopics.DataSource = dt;

            conn.Close();
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKeyword.Text))
            {
                LoadData();
            }
            if (Validation.isAllWhiteSpace(txtKeyword.Text))
            {
                MessageBox.Show("Chưa nhập từ khóa !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                LoadData(txtKeyword.Text);
            }
        }


        /// <summary>
        /// Tìm kiếm chuyên đề theo mã / tên
        /// </summary>
        /// <param name="tukhoa"></param>
        private void LoadData(string tukhoa)
        {
            try
            {
                string connectionString = Conector.DBEntity.GetConnection();
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = "GetTopicsByKeyWord";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@KeyWord", SqlDbType.NVarChar).Value = tukhoa;
                cmd.Parameters.Add("@TeacherID", SqlDbType.Int).Value = TeacherID;
                cmd.Connection = conn;

                conn.Open();

                reader = cmd.ExecuteReader();
                // Data is accessible through the DataReader object here.

                DataTable dt = new DataTable();
                dt.Columns.Add("MajorID", typeof(int));
                dt.Columns.Add("TopicID", typeof(int));
                dt.Columns.Add("TopicCode", typeof(string));
                dt.Columns.Add("TopicName", typeof(string));
                dt.Columns.Add("MajorCode", typeof(string));
                dt.Columns.Add("MajorName", typeof(string));
                dt.Columns.Add("Deadline", typeof(DateTime));
                dt.Columns.Add("NumberOfTeam", typeof(int));
                dt.Columns.Add("NumberTeam", typeof(int));
                dt.Columns.Add("NumberStudent", typeof(int));
                dt.Columns.Add("Enable", typeof(string));
                //dt.Columns.Add("FromDate", typeof(DateTime));
                //dt.Columns.Add("ToDate", typeof(DateTime));

                while (reader.Read())
                {
                    DataRow dr = dt.NewRow();

                    dr[0] = reader.GetInt32(reader.GetOrdinal("MajorID"));
                    dr[1] = reader.GetInt32(reader.GetOrdinal("TopicID"));
                    dr[2] = reader.GetString(reader.GetOrdinal("TopicCode"));
                    dr[3] = reader.GetString(reader.GetOrdinal("TopicName"));
                    dr[4] = reader.GetString(reader.GetOrdinal("MajorCode"));
                    dr[5] = reader.GetString(reader.GetOrdinal("MajorName"));
                    dr[6] = reader.GetDateTime(reader.GetOrdinal("Deadline"));
                    dr[7] = reader.GetInt32(reader.GetOrdinal("NumberOfTeam"));
                    dr[8] = reader.GetInt32(reader.GetOrdinal("NumberTeam"));
                    dr[9] = reader.GetInt32(reader.GetOrdinal("NumberStudent"));
                    if (reader.GetBoolean(reader.GetOrdinal("Enable")) == true)
                    {
                        dr[10] = "Đang mở";
                    }
                    if (reader.GetBoolean(reader.GetOrdinal("Enable")) == false)
                    {
                        dr[10] = "Hủy";
                    }
                    //dr[11] = reader.GetDateTime(reader.GetOrdinal("FromDate"));
                    //dr[12] = reader.GetDateTime(reader.GetOrdinal("ToDate"));
                    dt.Rows.Add(dr);
                }

                dgvTopics.DataSource = dt;

                conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int index = dgvTopics.SelectedRows.Count;

            if (index > 0)
            {
                frmUpdateTopic frm = new frmUpdateTopic();
                frm.lbMajorCode.Text = dgvTopics.SelectedRows[0].Cells["MajorCode"].Value.ToString();
                frm.lbMajorID.Text = dgvTopics.SelectedRows[0].Cells["MajorID"].Value.ToString();
                frm.lbTopicCode.Text = dgvTopics.SelectedRows[0].Cells["TopicCode"].Value.ToString();
                frm.lbTopicName.Text = dgvTopics.SelectedRows[0].Cells["TopicName"].Value.ToString();
                frm.dtpDeadline.Value = (DateTime)dgvTopics.SelectedRows[0].Cells["Deadline"].Value;
                frm.mudNumberTeam.Value = int.Parse(dgvTopics.SelectedRows[0].Cells["NumberTeam"].Value.ToString());
                frm.mudNumberStudent.Value = int.Parse(dgvTopics.SelectedRows[0].Cells["NumberStudent"].Value.ToString());
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Chưa chọn chuyên đề !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }


        private void btnCreateTeam_Click(object sender, EventArgs e)
        {
            int index = dgvTopics.SelectedRows.Count;

            if (index > 0)
            {
                frmAddTeam frm = new frmAddTeam();
                frm.lbTopicCode.Text = dgvTopics.SelectedRows[0].Cells["TopicCode"].Value.ToString();
                frm.lbTopicName.Text = dgvTopics.SelectedRows[0].Cells["TopicName"].Value.ToString();
                frm.lbTopicID.Text = dgvTopics.SelectedRows[0].Cells["TopicID"].Value.ToString();
                frm.lbNumberOfTeam.Text = dgvTopics.SelectedRows[0].Cells["NumberOfTeam"].Value.ToString();
                frm.lbNumberTeam.Text = dgvTopics.SelectedRows[0].Cells["NumberTeam"].Value.ToString();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Chưa chọn chuyên đề !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }


        /// <summary>
        /// Nhấn Enter sẽ gọi đến sự kiện Click của nút Tìm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtKeyword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(this, new EventArgs());
            }
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadData();
        }


        /// <summary>
        /// Không được nhập ký tự đặc biệt ở ô tìm kiếm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtKeyword_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (char.IsLetter(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsWhiteSpace(e.KeyChar) == true || char.IsDigit(e.KeyChar) == true)
            {
                e.Handled = false;
            }
        }
    }
}