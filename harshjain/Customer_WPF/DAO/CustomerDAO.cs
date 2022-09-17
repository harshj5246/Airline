using Customer_WPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_WPF.DAO
{
    
       static public class CustomerDAO
       {
        public static void Create(CustomerModel customer)
        {
            string insertString = @"INSERT INTO customer
(Id,Name,Creadit_limit,Com_Address,Billing_Address) 
VALUES(@Id,@Name,@creadit_limit,@com_address,@billing_address);";

            SqlConnection con = new SqlConnection(DbConfig.ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(insertString, con);
            cmd.Parameters.AddWithValue("@Id", customer.Id);
            cmd.Parameters.AddWithValue("@Name", customer.Name);
            cmd.Parameters.AddWithValue("@creadit_limit", customer.Creadit_limit);
            cmd.Parameters.AddWithValue("@com_address", customer.Com_Address);
            cmd.Parameters.AddWithValue("@billing_address",customer.Billing_Address);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        internal static void Create(object employeeForm)
        {
            throw new NotImplementedException();
        }

        internal static void Update(object employeeForm)
        {
            throw new NotImplementedException();
        }

        public static void Update(CustomerModel customer)
        {
            string insertString = @"UPDATE customer SET 
Name=@name,
Creadit_limit=@creadit_limit,
Com_Address=@com_address ,
Billing_Address=@billing_address
WHERE Id=@Id;";

            SqlConnection con = new SqlConnection(DbConfig.ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(insertString, con);
            cmd.Parameters.AddWithValue("@Id", customer.Id);
            cmd.Parameters.AddWithValue("@Name", customer.Name);
            cmd.Parameters.AddWithValue("@creadit_limit", customer.Creadit_limit);
            cmd.Parameters.AddWithValue("@com_address", customer.Com_Address);
            cmd.Parameters.AddWithValue("@billing_address", customer.Billing_Address);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void Delete(int Id)
        {
            string insertString = @"DELETE FROM customer 
WHERE Id=@Id;";

            SqlConnection con = new SqlConnection(DbConfig.ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(insertString, con);
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static ObservableCollection<CustomerModel> ReadAll()
        {
            ObservableCollection<CustomerModel> customers = new ObservableCollection<CustomerModel>();

            string insertString = @"SELECT Id,Name,
Creadit_limit,Com_Address,
Billing_Address
FROM customer;";

            SqlConnection con = new SqlConnection(DbConfig.ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(insertString, con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                customers.Add(new CustomerModel(
                    (int)reader["Id"],
                    (string)reader["Name"],
                    (double)reader["Creadit_limit"],
                    (string)reader["Com_Address"],
                    (string)reader["Billing_Address"]

                    ));
            }
            con.Close();

            return customers;
        }
    }

}
