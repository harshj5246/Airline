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


namespace Airlines_App
{
    /// <summary>
    /// Interaction logic for BookingDetails.xaml
    /// </summary>
    public partial class BookingDetails : Window
    {
        string conString = ConnectionString.conString;
        public BookingDetails()
        {
            InitializeComponent();
            load();
        }

        

        private void btn_Admin_Click(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin();
            this.Visibility = Visibility.Collapsed;
            admin.Show();
        }

        private void btn_logout_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            this.Visibility = Visibility.Collapsed;
            login.Show();
        }

        public void load()
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string query = "SELECT * FROM Booking";
            SqlCommand cmd = new SqlCommand(query, con);


            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            if (dt.Rows.Count > 0)
            {
                dtg_GrdFlight.ItemsSource = dt.DefaultView;
            }
            con.Close();
        }
    }
}
