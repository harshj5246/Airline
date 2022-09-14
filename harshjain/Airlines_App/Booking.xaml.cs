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
    /// Interaction logic for Booking.xaml
    /// </summary>
    public partial class Booking : Window
    {
        public Booking()
        {
            InitializeComponent();
            ReadFields();
            txt_usernamebk.Text = Login.username;

            
        }
        string conString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Airlines_App;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void ReadFields()
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string selectQuery = "select * from Flight where flight_id = '" + Dashboard.flightid + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, con);

            DataSet ds = new DataSet();

            adapter.Fill(ds);

            txt_fightid.Text = ds.Tables[0].Rows[0]["flight_id"].ToString();
            txt_destinationbk.Text = ds.Tables[0].Rows[0]["designation"].ToString();
            txt_sourcebk.Text = ds.Tables[0].Rows[0]["source"].ToString();

            con.Close();
            

        }


            private void btn_dashboard_Click(object sender, RoutedEventArgs e)
         {
            Dashboard dashboard = new Dashboard();
            this.Visibility = Visibility.Collapsed;
            dashboard.Show();
        }

        private void BtnBook_click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("l");
        }

        private void btn_dashbord_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            this.Visibility = Visibility.Collapsed;
            login.Show();
        }
    }
}
