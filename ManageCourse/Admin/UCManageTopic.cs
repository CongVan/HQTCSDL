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
    public partial class UCManageTopic : UserControl
    {
        public UCManageTopic()
        {
            InitializeComponent();
            LoadStatus();
            LoadMajors();
            LoadTopics();
            //DisablePanelUpdate();
        }
        private void LoadStatus()
        {

            var sourceGender = new Dictionary<string, string>();
            sourceGender.Add("1", "Kích hoạt");
            sourceGender.Add("0", "Hủy");
            //sourceGender.Add("3", "Sinh viên");
            cbbStatus.ValueMember = "Key";
            cbbStatus.DisplayMember = "Value";
            cbbStatus.DataSource = new BindingSource(sourceGender, null);
        }
        private void LoadMajors()
        {
            var conn = new SqlConnection(DBEntity.GetConnection());
            conn.Open();
            var cmd = new SqlCommand("SELECT m.Name MName,m.ID MID FROM dbo.Major m", conn);
            var tb = new DataTable();
            var adpt = new SqlDataAdapter(cmd);
            adpt.Fill(tb);
            conn.Close();
            var row = tb.NewRow();
            row["MName"] = "Tất cả";
            row["MID"] = "0";
            tb.Rows.InsertAt(row, 0);

            cbbFMajor.ValueMember = "MID";
            cbbFMajor.DisplayMember = "MName";
            cbbFMajor.DataSource = new BindingSource(tb, null);

        }
        private void LoadTopics()
        {
            var conn = new SqlConnection(DBEntity.GetConnection());
            conn.Open();
            var cmd = new SqlCommand("GetTopicFromMajor", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDMajor", cbbFMajor.SelectedValue.ToString());
            var tb = new DataTable();
            var adpt = new SqlDataAdapter(cmd);
            adpt.Fill(tb);
            conn.Close();
            dgvTopic.DataSource = new BindingSource(tb, null);

            //dgvTopic.Columns["ID"].Visible = false;
        }

        private void DisablePanelUpdate()
        {

            for (int i = 0; i < grbUpdate.Controls.Count; i++)
            {

                grbUpdate.Controls[i].Enabled = false;
            }
            grbUpdate.Enabled = false;

        }
        private void EnablePanelUpdate()
        {

            for (int i = 0; i < grbUpdate.Controls.Count; i++)
            {
                if (grbUpdate.Controls[i] is DateTimePicker)
                {
                    continue;
                }
                grbUpdate.Controls[i].Enabled = true;
            }
            grbUpdate.Enabled = true;
            //txtNameTopic.Enabled = true;
            //cbbStatus.Enabled = true;
            //btnSubmit.Enabled = true;
        }

        private void dgvTopic_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var index = dgvTopic.CurrentCell.RowIndex;
            if (index >= 0)
            {
                string id = dgvTopic.Rows[index].Cells[0].Value.ToString();
                if (String.IsNullOrEmpty(id))
                {
                    MessageBox.Show("Mã chuyên đề không tồn tại!", "Thông báo");
                    return;
                }
                //EnablePanelUpdate();
                var conn = new SqlConnection(DBEntity.GetConnection());
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM dbo.Topical t WHERE t.ID=" + id, conn);
                var tb = new DataTable();
                var adpt = new SqlDataAdapter(cmd);
                adpt.Fill(tb);
                conn.Close();
                txtNameTopic.Text = tb.Rows[0]["Name"].ToString();
                cbbStatus.SelectedValue = tb.Rows[0]["Enable"].ToString() == "True" ? "1" : "0";
                string[] fd = tb.Rows[0]["FromDate"].ToString().Split('/');
                string[] td = tb.Rows[0]["ToDate"].ToString().Split('/');
                dtpFromDate.Value = fd.Length == 3 ? new DateTime(int.Parse(fd[0]), int.Parse(fd[1]), int.Parse(fd[2])) : DateTime.Now;
                dtpToDate.Value = td.Length == 3 ? new DateTime(int.Parse(td[0]), int.Parse(td[1]), int.Parse(td[2])) : DateTime.Now;
            }
        }

        private void cbbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbStatus.SelectedValue.ToString() == "1")
            {
                dtpFromDate.Enabled = false;
                dtpToDate.Enabled = false;
            }
            else
            {
                dtpFromDate.Enabled = true;
                dtpToDate.Enabled = true;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var index = dgvTopic.CurrentCell.RowIndex;
            if (index < 0)
            {
                MessageBox.Show("Chuyên đề không tồn tại","Thông báo");
                return;
            }

            string id = dgvTopic.Rows[index].Cells[0].Value.ToString();
            if (String.IsNullOrEmpty(id))
            {
                MessageBox.Show("Mã chuyên đề không tồn tại!", "Thông báo");
                return;
            }
            //EnablePanelUpdate();
            var conn = new SqlConnection(DBEntity.GetConnection());
            conn.Open();
            var cmd = new SqlCommand("UpdateTopicalAdmin", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDT", id);
            cmd.Parameters.AddWithValue("@Enable", cbbStatus.SelectedValue.ToString());
            if(cbbStatus.SelectedValue.ToString() == "0")
            {
                cmd.Parameters.AddWithValue("@FromDate", dtpFromDate.Value.ToString("yyyy/MM/dd"));
                cmd.Parameters.AddWithValue("@ToDate", dtpToDate.Value.ToString("yyyy/MM/dd"));
            }
            else
            {
                cmd.Parameters.AddWithValue("@FromDate",DBNull.Value);
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            
            int count = cmd.ExecuteNonQuery();
            if (count > 0)
            {
                MessageBox.Show("Thành công!", "Thông báo");
                LoadTopics();
            }
            else
            {
                MessageBox.Show("Thất bại!", "Thông báo");
            }
        }
    }
}
