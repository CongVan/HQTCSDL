using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Conector;
namespace Student
{
    public partial class frmChuyenNhom : Form
    {
        public frmChuyenNhom()
        {
            InitializeComponent();
        }

        private void loadLoadNhom()
        {
            string infor = frmStudent.infor;
            string[] Temp = infor.Split('/');
            string idCD = Temp[0];
            string idNhom = Temp[1];
            string sql = "select * from Team_Topical where TopicalID = '" + idCD + "'  and Enable = 'True' and ID != '"+idNhom+"'";
            DataTable tb = DBEntity.GetTable(sql);
            if (tb.Rows.Count > 0)
            {
                cbNhom.DataSource = tb.DefaultView;
                cbNhom.DisplayMember = "Name";
                cbNhom.ValueMember = "ID";
            }
            else
            {
                cbNhom.DataSource = null;
            }
        }
        // load sl toi da cua nhom
        private string LoadSLTVToiDa()
        {
            string infor = frmStudent.infor;
            string[] Temp = infor.Split('/');
            string idCD = Temp[0];          
            string sl = DBEntity.GetField("Topical", "NumberTeam", "ID", idCD);
            return sl;
        }
        // load Sl da dang ky 
        private string LoadSLSVDangKy()
        {
            string idNhom = cbNhom.SelectedValue.ToString();
            string sql = "select count(*) from Student_Team where TeamID = '" + idNhom + "' and Enable = 'True'";
            DataTable tb = DBEntity.GetTable(sql);
            string sl = tb.Rows[0][0].ToString();
            return sl;
        }
        // Kiểm tra đăng ký chưa 
        private bool KTDaDangKy()
        {
            string infor = frmStudent.infor;
            string[] Temp = infor.Split('/');
            string IDSV = Temp[2];
            string idNhom = cbNhom.SelectedValue.ToString();
            string sql = "select * from Student_Team where TeamID = '" + idNhom + "'  and StudentID = '" + IDSV + "' and Enable = 'True'";
            DataTable tb = DBEntity.GetTable(sql);
            if (tb.Rows.Count > 0)
                return true;
            return false;
        }
        private bool KTDaDuThanhVien()
        {
            int SLTD = int.Parse(LoadSLTVToiDa());
            int SLDK = int.Parse(LoadSLSVDangKy());
            if (SLTD == SLDK)
            {
                return false;
            }
            return true;
        }
        private void frmChuyenNhom_Load(object sender, EventArgs e)
        {
            loadLoadNhom();
        }

        private void cbNhom_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtSLTV.Text = LoadSLTVToiDa();
                txtSLDK.Text = LoadSLSVDangKy();
            }
            catch { 
            
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            string infor = frmStudent.infor;
            string[] Temp = infor.Split('/');
            string IDSV = Temp[2];
            string nhom = Temp[1];
            try
            {
                int TD = int.Parse(LoadSLTVToiDa());
                int DK = int.Parse(LoadSLSVDangKy());
                string idNhom = cbNhom.SelectedValue.ToString();
                if (TD > DK)
                {
                    string sql2 = "update Student_Team set Enable = 'False' where StudentID = '" + IDSV + "' and TeamID = '" + nhom + "' ";
                    DBEntity.Exec(sql2);
                    string sql1 = "select * from Student_Team where TeamID = '" + idNhom + "'  and StudentID = '" + IDSV + "' and Enable = 'False'";
                    DataTable tb = DBEntity.GetTable(sql1);
                    if (tb.Rows.Count > 0)
                    {
                        sql1 = "update Student_Team set Enable = 'True' where StudentID = '" + IDSV + "' and TeamID = '" + idNhom + "' ";
                        bool kt = DBEntity.Exec(sql1);
                        if (kt)
                        {
                            MessageBox.Show("Chuyển nhóm thành công");
                            txtSLDK.Text = LoadSLSVDangKy();
                            this.Close();
                        }

                    }
                    else
                    {
                        string sql = "insert into Student_Team (StudentID,TeamID,Enable) values('" + IDSV + "','" + idNhom + "','True')";
                        bool check = DBEntity.Exec(sql);
                        if (check)
                        {
                            MessageBox.Show("Chuyển nhóm thành công!");
                            txtSLDK.Text = LoadSLSVDangKy();
                            this.Close();
                        }
                    }
                }
                else {
                    MessageBox.Show("SL thành viên nhóm đã đủ");
                }
            }
            catch { 
            
            }
        }
    }
}
