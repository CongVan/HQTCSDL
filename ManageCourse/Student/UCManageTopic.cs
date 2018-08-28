using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Conector;
using System.Data.SqlClient;

namespace Student
{
    public partial class UCManageTopic : UserControl
    {
        int _idStudent = 0;
        public UCManageTopic(int idStudent)
        {
            this._idStudent = idStudent;
            InitializeComponent();
            LoadMajor();
            LoadTopics();
            LoadTeams();
            dgvStudentTeam.AutoGenerateColumns = false;
            dgvTeams.AutoGenerateColumns = false;
        }
        public void LoadMajor()
        {
            var conn = new SqlConnection(DBEntity.GetConnection());
            conn.Open();
            var cmd = new SqlCommand("GetMajors", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            var tb = new DataTable();
            var adpt = new SqlDataAdapter(cmd);
            adpt.Fill(tb);
            conn.Close();
            cbbMajor.ValueMember = "ID";
            cbbMajor.DisplayMember = "Name";
            cbbMajor.DataSource = new BindingSource(tb, null);
        }
        public void LoadTopics()
        {
            var conn = new SqlConnection(DBEntity.GetConnection());
            conn.Open();
            var cmd = new SqlCommand("[GetTopic]", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDMajor", cbbMajor.SelectedValue);
            var tb = new DataTable();
            var adpt = new SqlDataAdapter(cmd);
            adpt.Fill(tb);
            conn.Close();
            cbbTopic.ValueMember = "ID";
            cbbTopic.DisplayMember = "TopicName";
            cbbTopic.DataSource = new BindingSource(tb, null);
        }
        public void LoadTeams()
        {
            var conn = new SqlConnection(DBEntity.GetConnection());
            conn.Open();
            var cmd = new SqlCommand("GetTeams", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDTopic", cbbTopic.SelectedValue);
            var tb = new DataTable();
            var adpt = new SqlDataAdapter(cmd);
            adpt.Fill(tb);
            conn.Close();
            dgvTeams.DataSource = tb;

        }
        private void cbbMajor_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadTopics();
        }

        private void btnRegisterTopic_Click(object sender, EventArgs e)
        {
            var idTeam = dgvTeams.Rows[dgvTeams.CurrentCell.RowIndex].Cells["ID"].Value;
            if (idTeam == null)
            {
                MessageBox.Show("Vui lòng chọn Nhóm đăng ký!");
                return;
            }

            var conn = new SqlConnection(DBEntity.GetConnection());
            conn.Open();
            var cmd = new SqlCommand("StudentRegisterTeam", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idStudent", _idStudent);
            cmd.Parameters.AddWithValue("@idTeam", idTeam);
            cmd.Parameters.AddWithValue("@idTopical", cbbTopic.SelectedValue);
            cmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
            int count = cmd.ExecuteNonQuery();
            int returnValue = int.Parse(cmd.Parameters["@Result"].Value.ToString());
            //int returnValue = (int)cmd.Parameters["@RETURN_VALUE"].Value;
            if (returnValue > 0)
            {
                MessageBox.Show("Đăng ký nhóm thành công!","Thông báo");
                LoadStudentTeams();
            }
            else
            {
                MessageBox.Show("Đăng ký nhóm thất bại. Mã lỗi ("+returnValue+")","Thông báo");
            }
        }

        private void cbbTopic_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadTeams();
            LoadStudentTeams();
        }

        private void dgvTeams_SelectionChanged(object sender, EventArgs e)
        {
            LoadStudentTeams();
        }
        void LoadStudentTeams()
        {
            if ( dgvTeams.Rows.Count==0)
            {
                dgvStudentTeam.DataSource = null;
                return;
            }
            int rowIndex = dgvTeams.CurrentCell==null?-1:dgvTeams.CurrentCell.RowIndex;
            if (rowIndex <0)
            {
                dgvStudentTeam.DataSource = null;
                
                return;
            }
            var idTeam = dgvTeams.Rows[rowIndex].Cells["ID"].Value;
            if (idTeam == null)
            {
                dgvStudentTeam.DataSource = null;
                return;
            }
            var conn = new SqlConnection(DBEntity.GetConnection());
            conn.Open();
            var cmd = new SqlCommand("GetStudentTeam", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idTeam", idTeam);
            var tb = new DataTable();
            var adpt = new SqlDataAdapter(cmd);
            adpt.Fill(tb);
            conn.Close();
            dgvStudentTeam.DataSource = tb;
        }
    }
}
