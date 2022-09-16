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
    public class UsersDAL
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
FROM Users 
where (UserName='{0}') and 
(Password='{1}')",
UserName, Password);
            SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, con);

            DataSet ds = new DataSet();

            adapter.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                return false;
            }
            return true;

        }
    
    public static bool Create(UsersModel model)
        {
            SqlConnection con = new SqlConnection(ConnectionString.conString);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            string que = string.Format(@"insert into Users 
values ('{0}','{1}','{2}',{3},'{4}',
'{5}','{6}','{7}');",
model.UserName,
model.FullName,
model.EmailId,
model.PhoneNo,
model.Gender,
model.Password,
model.ConfirmPassword,
model.DOB);


            cmd.CommandText = que;
            cmd.Connection = con;

            int resCount = cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();

            return resCount != 0;
        }
    }

}
