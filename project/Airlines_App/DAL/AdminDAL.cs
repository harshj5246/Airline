using Airlines_App.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airlines_App.DAL
{
    public class AdminDAL
    {
        public static bool ReadBySearch(
            string UserName,
            string Password
            )
        {

            //Move code here
            SqlConnection con = new SqlConnection(ConnectionString.conString);
            con.Open();
            string selectQuery = string.Format(@"SELECT 
UserName,Password
FROM Admin 
where (UserName='{0}') and 
(Password='{1}')",
UserName, Password);
            SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, con);

            DataSet ds = new DataSet();

            adapter.Fill(ds);
            if(ds.Tables[0].Rows.Count == 0)
            {
                return false;
            }
            return true;
           
        }
    }
}
