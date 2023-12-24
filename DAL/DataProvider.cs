using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataProvider
    {
        private static DataProvider instance;

        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataProvider();
                }
                return instance;
            }
        }

        private DataProvider() { }

        public SqlConnection Openconnect()
        {
            string scon = @"Data Source=.;Initial Catalog=QuanLyBanGiay;Integrated Security=True";
            SqlConnection conn = new SqlConnection(scon);
            conn.Open();
            return conn;
        }
    }
}
