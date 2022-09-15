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
using System.Data.SqlClient;
using System.Data;

namespace Airlines_App
{
    
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        string conString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Airlines_App;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static string flightid;
        public static string airline;
        public static string date;



        public Dashboard()
        {
            InitializeComponent();
            lblwelcome.Content = "Welcome " + Login.username;
            dp_date.DisplayDateStart = DateTime.Now;

        }


      

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            if (txt_source.Text == String.Empty)
            {
                txt_source.Focus();
                MessageBox.Show("fill the Source  fields");
                return;

            }
            else if (txt_destination.Text == String.Empty)
            {
                txt_destination.Focus();
                MessageBox.Show("fill the Destination fields");
                return;

            }
            else if(dp_date.Text == String.Empty)
            {
                txt_destination.Focus();
                MessageBox.Show("Select the Date ");
                return;
            }
            else
            {
                //source = txt_source.Text;
                //destination = txt_destination.Text;
                //date = dp_date.Text;

                //FlightList flightList = new FlightList();
                //this.Visibility = Visibility.Collapsed;
                //flightList.Show();

                dtg_GrdFlight.Visibility = Visibility.Visible;
              

                SqlConnection con = new SqlConnection(conString);
                con.Open();

                string query = "SELECT flight_id,Airline_name,source,designation,seat_capacity,depature,arraival_time,flight_charge FROM Flight where source like '" + txt_source.Text + "' and designation like '" + txt_destination.Text+ "'";
                SqlCommand cmd = new SqlCommand(query, con);


                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dtg_GrdFlight.ItemsSource = dt.DefaultView;
                if (dt.Rows.Count > 0)
                {
                    btn_Book.Visibility = Visibility.Visible;
                }
                else
                {
                    MessageBox.Show("NO FLIGHT Avilable");
                }
                con.Close();

            }
        }

        private void btn_logout_Click(object sender, RoutedEventArgs e)
        {
            lblwelcome.Content = "";
            Login login = new Login();
            this.Visibility = Visibility.Collapsed;
            login.Show();
        }

        private void btn_Book_Click(object sender, RoutedEventArgs e)
        {

            flightid = txt_flightid.Text;
            airline = txt_airlinename.Text;
            date = dp_date.Text;
            Booking booking = new Booking();
            this.Visibility = Visibility.Collapsed;
            booking.Show();
        }

        private void btn_cancle_Click(object sender, RoutedEventArgs e)
        {
            Cancelation cancelation = new Cancelation();
            this.Visibility = Visibility.Collapsed;
            cancelation.Show();
        }
    }
}
