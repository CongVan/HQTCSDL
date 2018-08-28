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

namespace Student
{
    public partial class UCTransferTeam : UserControl
    {
        int _idStudent = 0;
        int _idTeam = 0;
        public UCTransferTeam(int idStudent)
        {
            _idStudent = idStudent;
            InitializeComponent();
            LoadMajor();
            LoadTopics();
            LoadTeamOfStudent();
            LoadTeamOfTopical();
        }

        private void LoadMajor()
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
            cbbMajor.DataSource = tb;
        }
        private void LoadTopics()
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
        private void LoadTeamOfStudent()
        {
            var conn = new SqlConnection(DBEntity.GetConnection());
            conn.Open();
            var cmd = new SqlCommand("GetTeamOfStudent", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TopicID", cbbTopic.SelectedValue??0);
            cmd.Parameters.AddWithValue("@StudentID", _idStudent);
            var tb = new DataTable();
            var adpt = new SqlDataAdapter(cmd);
            adpt.Fill(tb);
            conn.Close();
            if (tb.Rows.Count == 0)
            {
                lblCurrentTeam.Text = "Bạn không có nhóm thuộc chuyên đề này!";
                _idTeam = 0;
            }
            else
            {
                string nameTeam = tb.Rows[0]["NameTeam"].ToString();
                _idTeam= int.Parse(tb.Rows[0]["IDTeam"].ToString());
                lblCurrentTeam.Text = "Nhóm hiện tại của bạn là: " + nameTeam;
            }

            btnSubmitTransfer.Enabled = _idTeam != 0;
            btnSubmitTransfer.ForeColor = _idTeam != 0 ? Color.Tomato : Color.Gray;
            btnSubmitTransfer.Text = _idStudent == 0 ? "Chuyển nhóm" : "Chuyển nhóm ( " + _idTeam + " )";
        }
        private void LoadTeamOfTopical()
        {
            var conn = new SqlConnection(DBEntity.GetConnection());
            conn.Open();
            var cmd = new SqlCommand("GetTeamOfTopical", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TopicalID", cbbTopic.SelectedValue??0);
            //cmd.Parameters.AddWithValue("@StudentID", _idStudent);
            var tb = new DataTable();
            var adpt = new SqlDataAdapter(cmd);
            adpt.Fill(tb);
            conn.Close();
            dgvTeamOfTopic.DataSource = new BindingSource(tb,null);
        }
        private void cbbTopic_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadTeamOfStudent();
            LoadTeamOfTopical();
        }

        
        private void cbbMajor_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTopics();
        }

        private void btnSubmitTransfer_Click(object sender, EventArgs e)
        {
            int rowIndex = dgvTeamOfTopic.CurrentCell.RowIndex;
            if (rowIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn nhóm muốn chuyển!", "Thông báo");
                return;
            }
            int transferID = int.Parse(dgvTeamOfTopic.Rows[rowIndex].Cells["ID"].Value.ToString());
            if (transferID == _idTeam)
            {
                MessageBox.Show("Bạn đã thuộc nhóm này!", "Thông báo");
                return;
            }
            var conn = new SqlConnection(DBEntity.GetConnection());
            conn.Open();
            var cmd = new SqlCommand("TransferTeam", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idOldTeam", _idTeam);
            cmd.Parameters.AddWithValue("@idNewTeam", transferID);
            cmd.Parameters.AddWithValue("@idStudent", _idStudent);
            cmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
            int n=cmd.ExecuteNonQuery();
            conn.Close();
            int ret = int.Parse(cmd.Parameters["@Result"].Value.ToString());
            if (ret == 1)
            {
                MessageBox.Show("Chuyển nhóm thành công!");
                LoadTeamOfStudent();
                LoadTeamOfTopical();
            }
            else
            {
                MessageBox.Show("Chuyển nhóm thất bại. (Mã lỗi: "+ret+")!");
            }

        }

        private void dgvTeamOfTopic_SelectionChanged(object sender, EventArgs e)
        {
            int rowIndex = dgvTeamOfTopic.CurrentCell.RowIndex;
            if (rowIndex < 0)
            {
                //MessageBox.Show("Vui lòng chọn nhóm muốn chuyển!", "Thông báo");
                return;
            }
            int transferID = int.Parse(dgvTeamOfTopic.Rows[rowIndex].Cells["ID"].Value.ToString());
            
            btnSubmitTransfer.Text = transferID == 0 ? "Chuyển nhóm" : "Chuyển nhóm ( " + transferID + " )";

        }
    }
}
