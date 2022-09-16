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
    /// Interaction logic for Cancelation.xaml
    /// </summary>
    public partial class Cancelation : Window
    {
        string conString = ConnectionString.conString;
        
        int ticket_id =0;
        public Cancelation()
        {
            InitializeComponent();
            Loadtickets();
        }

     
        public void Loadtickets()
        {
            //dtg_GrdFlight.Visibility = Visibility.Visible;
            //btn_Book.Visibility = Visibility.Visible;

            SqlConnection con = new SqlConnection(conString);
            con.Open();

            string query = "SELECT * FROM Booking where UserName like '" + Login.username + "'";
            SqlCommand cmd = new SqlCommand(query, con);


            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dtg_GrdTicket.ItemsSource = dt.DefaultView;
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);

            DataSet ds = new DataSet();

            adapter.Fill(ds);
            if(dt.Rows.Count > 0)
            {
                ticket_id = int.Parse(ds.Tables[0].Rows[0]["ticket_id"].ToString());

            }
          
            
           

            con.Close();
           
        }

        private void btn_dashboard_Click(object sender, RoutedEventArgs e)
        {
           Dashboard dashboard = new Dashboard();
            this.Visibility = Visibility.Collapsed;
            dashboard.Show();
        }

        private void btn_dashbord_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            this.Visibility = Visibility.Collapsed;
            login.Show();
        }

      

        private void btn_Calcle_Click(object sender, RoutedEventArgs e)
        {
            if (ticket_id == 0)
            {
                MessageBox.Show("No Booked Tickets Avilable for cancle");

            }
            else
            {

                SqlConnection con = new SqlConnection(conString);
                con.Open();

                string que = ("delete from Booking where ticket_id = " + ticket_id);
                SqlCommand cmd = new SqlCommand(que, con);

                if (MessageBox.Show("Do you really want to Cancle", "Confirmation", MessageBoxButton.YesNo) != MessageBoxResult.Yes)
                {

                    return;
                }
                else
                {


                    int no1 = seats();
                    int editno = no1 + int.Parse(txt_noOfTickets.Text);

                    SqlConnection fcon = new SqlConnection(conString);
                    fcon.Open();
                    string query = ("Update Flight set  Seat_Left = " + editno + " Where flight_id ='" + txt_flight_id.Text + "'");


                    SqlCommand cmmd = new SqlCommand(query, con);

                    cmmd.ExecuteNonQuery();
                    fcon.Close();
                    cmmd.Dispose();

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Ticket Cancled Successfully");


                }
                con.Close();
                cmd.Dispose();
            }
            
        }

        public int seats()
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string flightque = ("Select Seat_Left from Flight where flight_id = '" + txt_flight_id.Text + "'" );

            SqlDataAdapter flightadapter = new SqlDataAdapter(flightque, con);

            DataSet ds = new DataSet();

            flightadapter.Fill(ds);

            int no = Convert.ToInt32(ds.Tables[0].Rows[0]["Seat_Left"]);
            con.Close();
            return no;
            
        }
    }
}
