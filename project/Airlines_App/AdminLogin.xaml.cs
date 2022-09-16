using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using Airlines_App.DAL;

namespace Airlines_App
{
    /// <summary>
    /// Interaction logic for AdminLogin.xaml
    /// </summary>
    public partial class AdminLogin : Window
    {
        public AdminLogin()
        {
            InitializeComponent();
        }
        string conString = ConnectionString.conString;
        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            bool ans = AdminDAL.ReadBySearch(txt_userName.Text,p_password.Password);
            if (!ans)
            {
                MessageBox.Show("Incorrect UserName Or Password");
                return;
            }
            

                Admin admin = new Admin();
                this.Visibility = Visibility.Collapsed;
                admin.Show();
            
        }

        private void btn_adminLogin_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            this.Visibility = Visibility.Collapsed;
            login.Show();
        }
    }
}
