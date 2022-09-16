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
using Airlines_App.DAL;

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
            bool ans = UsersDAL.ReadBySearch(txt_userName.Text, p_password.Password);
            if (!ans)
            {
                MessageBox.Show("Incorrect UserName Or Password");
                return;
            }
            username = txt_userName.Text;

                Dashboard dashboard = new Dashboard();
                this.Visibility = Visibility.Collapsed;
                dashboard.Show();
            
        }

        private void btn_adminLogin_Click(object sender, RoutedEventArgs e)
        {
            AdminLogin adminLogin = new AdminLogin();
            this.Visibility = Visibility.Collapsed;
            adminLogin.Show();
        }
    }
}
