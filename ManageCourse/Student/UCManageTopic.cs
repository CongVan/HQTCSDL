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
        public UCManageTopic()
        {
            InitializeComponent();
            LoadMajor();
            LoadTopics();
            LoadTeams();
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
            cmd.Parameters.AddWithValue("@idStudent", new Random().Next(1, 100));
            cmd.Parameters.AddWithValue("@idTeam", idTeam);
            cmd.Parameters.AddWithValue("@idTopical", cbbTopic.SelectedValue);
            int count = cmd.ExecuteNonQuery();
            int returnValue = (int)cmd.Parameters["@RETURN_VALUE"].Value;
            if (returnValue > 0)
            {
                MessageBox.Show("Đăng ký nhóm thành công!","Thông báo");
                LoadStudentTeams();
            }
            else
            {
                MessageBox.Show("Đăng ký nhóm thất bại!","Thông báo");
            }
        }

        private void cbbTopic_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void dgvTeams_SelectionChanged(object sender, EventArgs e)
        {
            LoadStudentTeams();
        }
        void LoadStudentTeams()
        {
            var idTeam = dgvTeams.Rows[dgvTeams.CurrentCell.RowIndex].Cells["ID"].Value;
            if (idTeam == null)
            {
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
