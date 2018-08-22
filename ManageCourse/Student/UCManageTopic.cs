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

        private void cbbMajor_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadTopics();
        }

        private void btnRegisterTopic_Click(object sender, EventArgs e)
        {

        }
    }
}
