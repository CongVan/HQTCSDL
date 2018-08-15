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
    public partial class frmStudent : Form
    {
       public static string infor = "";
        string IDSV = "1";
        public frmStudent()
        {
            InitializeComponent();
        }
        private void LoadCBChuyenNganh()
        {

            string sql = "select * from Major";
            DataTable tb = DBEntity.GetTable(sql);
            cbChuyenNganh.DataSource = tb.DefaultView;
            cbChuyenNganh.DisplayMember = "Name";
            cbChuyenNganh.ValueMember = "ID";
        }
        private void LoadCBChuyenDe()
        {
            string cd = cbChuyenNganh.SelectedValue.ToString();
            string sql = "select * from Topical where MajorID = '" + cd + "' and Enable = 'True'";
            DataTable tb = DBEntity.GetTable(sql);
            if (tb.Rows.Count > 0)
            {
                cbCD.DataSource = tb.DefaultView;
                cbCD.DisplayMember = "Name";
                cbCD.ValueMember = "ID";
            }

        }
        private void LoadNhom()
        {

            string idCD = cbCD.SelectedValue.ToString().Trim();
            //int check;
            //try
            //{
            //  check = int.Parse(idCD);
            string sql = "select * from Team_Topical where TopicalID = '" + idCD + "'  and Enable = 'True'";
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
            //}
            //catch { }     
        }
        // load sl toi da cua nhom
        private string LoadSLTVToiDa()
        {
            string idCD = cbCD.SelectedValue.ToString();
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
            string idNhom = cbNhom.SelectedValue.ToString();
            string sql = "select * from Student_Team where TeamID = '" + idNhom + "'  and StudentID = '" + IDSV + "' and Enable = 'True'";
            DataTable tb = DBEntity.GetTable(sql);
            if (tb.Rows.Count > 0)
                return true;
            return false;
        }
        // kiểm tra sinh viên đã đăng ký nhóm của chuyên đề
        private bool KTDKNhomCD()
        {
            string idCD = cbCD.SelectedValue.ToString();
            string sql = "select * from Team_Topical where TopicalID = '" + idCD + "'  and Enable = 'True' and StudentID = '" + IDSV + "'";
            DataTable tb = DBEntity.GetTable(sql);
            if (tb.Rows.Count > 0)
            {
                return false;
            }
            return true;
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
        private void LoadDataGrid()
        {
            string idNhom = cbNhom.SelectedValue.ToString();

            string sql = @"select T.STT,tp.Name as 'Nhóm',s.FullName as 'Họ Tên',s.Code as 'Mã SV',T.Point as 'Điểm' from 
                  (select ROW_NUMBER() over (order by ID desc) as STT,* from Student_Team where TeamID = '" + idNhom + @"' and Enable = 'True') as T,Student s,Team_Topical as tp
                    where T.StudentID = s.ID and T.TeamID = tp.ID";
            DataTable tb = DBEntity.GetTable(sql);
            dgDSTVNhom.DataSource = tb;
        }
        private void frmStudent_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void cbChuyenNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadCBChuyenDe();
            }
            catch { }
            

        }

        private void frmStudent_Load(object sender, EventArgs e)
        {
            LoadCBChuyenNganh();
            LoadCBChuyenDe();
            btnHuyDangKy.Enabled = false;
            btnChuyenNhom.Enabled = false;
        }

        private void cbCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadNhom();
            }
            catch { }
        }

        private void cbNhom_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string SVTD = LoadSLTVToiDa();
                string SVDk = LoadSLSVDangKy();
                txtSLTV.Text = SVTD;
                txtSLDK.Text = SVDk;
                LoadDataGrid();
                if (KTDaDuThanhVien())
                {
                    btnDangKy.Enabled = true;
                    if (KTDaDangKy())
                    {
                        btnDangKy.Enabled = false;
                        btnHuyDangKy.Enabled = true;
                        btnChuyenNhom.Enabled = true;
                    }
                    else
                    {
                        btnDangKy.Enabled = true;
                        btnHuyDangKy.Enabled = false;
                        btnChuyenNhom.Enabled = false;
                    }
                }
                else
                {
                    btnDangKy.Enabled = false;
                }
            }
            catch { }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            try
            {
                if (KTDKNhomCD())
                {
                    string idNhom = cbNhom.SelectedValue.ToString();
                    string sql1 = "select * from Student_Team where TeamID = '" + idNhom + "'  and StudentID = '" + IDSV + "' and Enable = 'False'";
                    DataTable tb = DBEntity.GetTable(sql1);
                    if (tb.Rows.Count > 0)
                    {
                        sql1 = "update Student_Team set Enable = 'True' where StudentID = '" + IDSV + "' and TeamID = '" + idNhom + "' ";
                        bool kt = DBEntity.Exec(sql1);
                        if (kt)
                        {
                            MessageBox.Show("Đăng ký thành công");
                            txtSLDK.Text = LoadSLSVDangKy();
                            LoadDataGrid();
                        }

                    }
                    else
                    {
                        string sql = "insert into Student_Team (StudentID,TeamID,Enable) values('" + IDSV + "','" + idNhom + "','True')";
                        bool check = DBEntity.Exec(sql);
                        if (check)
                        {
                            MessageBox.Show("Đăng ký thành công");
                            txtSLDK.Text = LoadSLSVDangKy();
                            LoadDataGrid();
                        }
                    }
                    btnDangKy.Enabled = false;
                    btnChuyenNhom.Enabled = true;
                    btnHuyDangKy.Enabled = true;
                }
                else {
                    MessageBox.Show("Bạn đã đăng ký nhóm CD này rồi!");                
                }
             

            }
            catch
            {
                MessageBox.Show("Chọn thông tin đầy đủ");
            }
            
        }

        private void btnChuyenNhom_Click(object sender, EventArgs e)
        {
            var idCD = cbCD.SelectedValue.ToString();
            var idNhom = cbNhom.SelectedValue.ToString();
            infor = idCD + "/" + idNhom+"/"+IDSV;
            Form frm = new frmChuyenNhom();
            frm.ShowDialog();
            LoadDataGrid();
        }

        private void btnHuyDangKy_Click(object sender, EventArgs e)
        {
            try
            {
                string idNhom = cbNhom.SelectedValue.ToString();
                if (MessageBox.Show("ban co chắc muốn hủy đăng ký") == System.Windows.Forms.DialogResult.OK)
                {
                    string sql1 = "update Student_Team set Enable = 'False' where StudentID = '" + IDSV + "' and TeamID = '" + idNhom + "' ";
                    bool kt = DBEntity.Exec(sql1);
                    if (kt)
                    {
                        MessageBox.Show("Hủy đăng ký thành công");
                        txtSLDK.Text = LoadSLSVDangKy();
                        LoadDataGrid();
                        btnDangKy.Enabled = true;
                        btnHuyDangKy.Enabled = false;
                        btnChuyenNhom.Enabled = false;
                    }
                }


            }
            catch { }
        }

    }
}
