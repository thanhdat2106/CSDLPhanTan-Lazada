using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lazada
{
    public class DBSQLServerUtils
    {
        public static Boolean
              GetDBConnection(string datasource, string database, string username, string password)
        {
            //
            // Data Source=TRAN-VMWARE\SQLEXPRESS;Initial Catalog=simplehr;Persist Security Info=True;User ID=sa;Password=12345
            //
            //
            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;

            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}