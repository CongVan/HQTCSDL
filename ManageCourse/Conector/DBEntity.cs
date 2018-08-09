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
            string dataSource = @"DESKTOP-K5LOBGC";
            //string dataSource = @"VANHC\SQLEXPRESS";
            string connectionString = @"Data Source="+ dataSource + ";Initial Catalog=ManageCourse;Integrated Security=True";
            return connectionString;
        }
    }
}
