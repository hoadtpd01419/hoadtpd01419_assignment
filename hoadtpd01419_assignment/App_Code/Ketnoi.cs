using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace hoadtpd01419_assignment.App_Code
{
    public class Ketnoi
    {
        SqlConnection con;
        public int update(string sql) {
            int kq = 0;
            try {
                getConnect();
                SqlCommand cmd = new SqlCommand(sql,con);
                kq = cmd.ExecuteNonQuery();
            }
            catch (System.Exception ex) {
                kq = 0;
            }
            finally {
                closeConnect();
            }
            return kq;
        }
        public DataTable getData(String sql) {
            DataTable dt = new DataTable();
            try
            {
                getConnect();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                adapter.Fill(dt);
            }
            catch (System.Exception ex)
            {
                dt = null;
            }
            finally {
                closeConnect();
            }
            return dt;
        }
        private void getConnect() {
          
            con = new SqlConnection("Data Source=HOADT\\SQLEXPRESS;Initial Catalog=master;Persist Security Info=True;User ID=sa;Password=nthlhh20071996");
            con.Open();
        }
        private void closeConnect() {
            if (con.State==ConnectionState.Open) {
                con.Close();
            }
            
        }
    }
}