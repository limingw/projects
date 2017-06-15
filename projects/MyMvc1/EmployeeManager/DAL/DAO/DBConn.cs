using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmployeeManager.DAL.DAO
{
    public class DBConn
    {
        public const string CONN_STRING = @"Data Source=YOUNG\SQLEXPRESS;Initial Catalog=EmployeeManager;Persist Security Info=True;User ID=sa;Password=123";

        public static SqlConnection GetConn()
        {
            
            SqlConnection conn = new SqlConnection(CONN_STRING);
            conn.Open();
            return conn;
        }
    }
}