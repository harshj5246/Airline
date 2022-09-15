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
    /// Interaction logic for ConfirmBooking.xaml
    /// </summary>
    public partial class ConfirmBooking : Window
    {
        public ConfirmBooking()
        {
            InitializeComponent();
            
            ReadFields();
        }

        string conString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Airlines_App;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public void ReadFields()
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string selectQuery = ("select * from Booking where ticket_id = " + Booking.flightid) ;
            SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, con);

            DataSet ds = new DataSet();

            adapter.Fill(ds);


            txt_fightid.Text = ds.Tables[0].Rows[0]["flight_id"].ToString();
            txt_username.Text = ds.Tables[0].Rows[0]["UserName"].ToString();
            txt_source.Text = ds.Tables[0].Rows[0]["source"].ToString();
            txt_nooftickets.Text = ds.Tables[0].Rows[0]["No_Of_Tickets"].ToString();
            txt_totalamount.Text = ds.Tables[0].Rows[0]["Total_Amount"].ToString();
            txt_destination.Text = ds.Tables[0].Rows[0]["destination"].ToString();
            txt_Arilinename.Text = ds.Tables[0].Rows[0]["Airline_name"].ToString();
            txt_class.Text = ds.Tables[0].Rows[0]["Class"].ToString();
            txt_date.Text = ds.Tables[0].Rows[0]["Date"].ToString();
            lbl_ticketid.Content = Booking.flightid;
            con.Close();


        }

        private void lbl_dashboard_Click(object sender, RoutedEventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            this.Visibility = Visibility.Collapsed;
            dashboard.Show();
        }

        private void btn_logout_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            this.Visibility = Visibility.Collapsed;
            login.Show();
        }
    }
}
