using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace Airlines_App
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public static string username;
        public Login()
        {
            InitializeComponent();
        }
        string conString = ConnectionString.conString;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Register register = new Register();
            this.Visibility = Visibility.Collapsed;
            register.Show();
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            
            string selectQuery = "select * from Users where UserName = '" + txt_userName.Text + "' and  Password = '" + p_password.Password + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, con);

            DataSet ds = new DataSet();

            adapter.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("User Name or Password Incorrect");
            }
            else
            {
                //SqlConnection cone = new SqlConnection(conString);

                //string que = ("insert into Login values('" + txt_userName.Text + "','" + p_password.Password + "')");
                //cone.Open();
                //SqlCommand cmd = new SqlCommand(que, cone);
                //cmd.ExecuteNonQuery();
                username = txt_userName.Text;

                Dashboard dashboard = new Dashboard();
                this.Visibility = Visibility.Collapsed;
                dashboard.Show();
            }
        }

        private void btn_adminLogin_Click(object sender, RoutedEventArgs e)
        {
            AdminLogin adminLogin = new AdminLogin();
            this.Visibility = Visibility.Collapsed;
            adminLogin.Show();
        }
    }
}
