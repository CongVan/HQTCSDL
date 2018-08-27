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
    public partial class UCManageStudent : UserControl
    {
        public UCManageStudent()
        {
            InitializeComponent();
        }


        private void UCManageStudent_Load(object sender, EventArgs e)
        {
            LoadData();
        }


        /// <summary>
        /// Load danh sách sinh viên vào datagridview
        /// </summary>
        private void LoadData()
        {
            string connectionString = Conector.DBEntity.GetConnection();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "GetStudents";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;

            conn.Open();

            reader = cmd.ExecuteReader();
            // Data is accessible through the DataReader object here.

            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Code", typeof(string));
            dt.Columns.Add("FullName", typeof(string));
            dt.Columns.Add("Gender", typeof(string));
            dt.Columns.Add("DayOfBirth", typeof(DateTime));
            dt.Columns.Add("Address", typeof(string));
            dt.Columns.Add("MajorName", typeof(string));

            while (reader.Read())
            {
                DataRow dr = dt.NewRow();
                dr[0] = reader.GetInt32(reader.GetOrdinal("ID"));
                dr[1] = reader.GetString(reader.GetOrdinal("Code"));
                dr[2] = reader.GetString(reader.GetOrdinal("FullName"));
                if (reader.GetInt32(reader.GetOrdinal("Gender")) == 1)
                {
                    dr[3] = "Nam";
                }
                if (reader.GetInt32(reader.GetOrdinal("Gender")) == 2)
                {
                    dr[3] = "Nữ";
                }
                dr[4] = reader.GetDateTime(reader.GetOrdinal("DayOfBirth"));
                dr[5] = reader.GetString(reader.GetOrdinal("Address"));
                dr[6] = reader.GetString(reader.GetOrdinal("MajorName"));
                dt.Rows.Add(dr);
            }

            dgvStudents.DataSource = dt;

            conn.Close();
        }


        private void btnDetails_Click(object sender, EventArgs e)
        {
            int index = dgvStudents.SelectedRows.Count;

            if (index > 0)
            {
                frmScoreDetails frm = new frmScoreDetails();
                frm.lbStudentID.Text = dgvStudents.SelectedRows[0].Cells["ID"].Value.ToString();
                frm.lbStudentCode.Text = dgvStudents.SelectedRows[0].Cells["Code"].Value.ToString();
                frm.lbStudentName.Text = dgvStudents.SelectedRows[0].Cells["FullName"].Value.ToString();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Chưa chọn sinh viên !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
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
        /// Tìm kiếm sinh viên theo mã / họ tên
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

                cmd.CommandText = "GetStudentsByKeyWord";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@KeyWord", SqlDbType.NVarChar).Value = tukhoa;
                cmd.Connection = conn;

                conn.Open();

                reader = cmd.ExecuteReader();
                // Data is accessible through the DataReader object here.

                DataTable dt = new DataTable();
                //dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("Code", typeof(string));
                dt.Columns.Add("FullName", typeof(string));
                dt.Columns.Add("Gender", typeof(string));
                dt.Columns.Add("DayOfBirth", typeof(DateTime));
                dt.Columns.Add("Address", typeof(string));
                dt.Columns.Add("MajorName", typeof(string));

                while (reader.Read())
                {
                    DataRow dr = dt.NewRow();
                    //dr[0] = reader.GetInt32(reader.GetOrdinal("ID"));
                    dr[0] = reader.GetString(reader.GetOrdinal("Code"));
                    dr[1] = reader.GetString(reader.GetOrdinal("FullName"));
                    if (reader.GetInt32(reader.GetOrdinal("Gender")) == 1)
                    {
                        dr[2] = "Nam";
                    }
                    if (reader.GetInt32(reader.GetOrdinal("Gender")) == 2)
                    {
                        dr[2] = "Nữ";
                    }
                    dr[3] = reader.GetDateTime(reader.GetOrdinal("DayOfBirth"));
                    dr[4] = reader.GetString(reader.GetOrdinal("Address"));
                    dr[5] = reader.GetString(reader.GetOrdinal("MajorName"));
                    dt.Rows.Add(dr);
                }

                dgvStudents.DataSource = dt;

                conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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