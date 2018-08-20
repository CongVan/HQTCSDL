using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Conector
{
    public class DBEntity
    {
        public static string GetConnection()
        {
            //string dataSource = @"WINCTRL-N182QAL\SQLEXPRESS";
            //  string dataSource = @"DESKTOP-K5LOBGC";
            string dataSource = @"VANHC\SQLEXPRESS";
            string connectionString = @"Data Source="+ dataSource + ";Initial Catalog=ManageCourse;Integrated Security=True";
            return connectionString;
        }
        public static SqlConnection Connect(string s)
        {
            SqlConnection con = new SqlConnection(s);
            return con;
        }
        public static DataTable GetTable(string sql)
        {
            string s = GetConnection();
            SqlConnection con = Connect(s);
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter ad = new SqlDataAdapter();
            ad.SelectCommand = cmd;
            DataTable tb = new DataTable();
            ad.Fill(tb);
            return tb;
        }
        public static bool Exec(string strCommandText)
        {
            string s = GetConnection();
            SqlConnection Conn = Connect(s);
            bool flag = false;
            try
            {
                SqlCommand Cmd = new SqlCommand(strCommandText, Conn);
                Cmd.CommandType = CommandType.Text;
                Cmd.Parameters.Clear();
                if (Conn.State == ConnectionState.Closed)
                {
                    Conn.Open();
                }
                Cmd.ExecuteNonQuery();
                if (Conn.State == ConnectionState.Open)
                    Conn.Close();
                flag = true;
            }
            catch (Exception)
            {
                if (Conn.State == ConnectionState.Open)
                    Conn.Close();
                flag = false;
            }

            return flag;
        }
        public static string GetField(string Bang, string ThongTinLay, string DieuKien, string DKSS)
        {
            string rs = "";
            string sql = "select " + ThongTinLay + "  from " + Bang + " where " + DieuKien + " = '" + DKSS + "' ";
            DataTable tb = GetTable(sql);
            if (tb.Rows.Count > 0)
                rs = tb.Rows[0][0].ToString();
            return rs;
        }
    }
}
