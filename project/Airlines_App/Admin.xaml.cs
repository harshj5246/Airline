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
using Airlines_App.Model;
using Airlines_App.DAL;

namespace Airlines_App
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
            TxtSeatCapicity.Text = txt_seat_left.Text;
        }

        string conString = ConnectionString.conString;

        private void btn_dashbord_Click(object sender, RoutedEventArgs e)
        {
           if( MessageBox.Show("Are you really want to logout","Confirmation", MessageBoxButton.YesNo) != MessageBoxResult.Yes ){
                return;
            }
            AdminLogin adminLogin = new AdminLogin();
            this.Visibility = Visibility.Collapsed;
            adminLogin.Show();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
       

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            FlightModel model = new FlightModel();
            model.flight_id = TxtFlightID.Text;
            model.Airline_name = TxtAirlineName.Text;
            model.source = TxtSource.Text;
            model.designation = TxtDestination.Text;
            model.seat_capacity = int.Parse(TxtSeatCapicity.Text);
            model.depature = txt_depature.Text;
            model.arraival_time = txt_arrival.Text;
            model.flight_charge = double.Parse(txt_flightcharge.Text);
            model.Seat_Left = int.Parse(txt_seat_left.Text);
            bool res = FlightDAL.Create(model);
            if(!res)
            {
                MessageBox.Show("Flight is not saved....");
                return;
            }
            MessageBox.Show("Flight is saved succesfully");
            BtnLoad_Click(null, null);
            BtnNew_Click(null, null);

            //SqlConnection con = new SqlConnection(conString);
            //con.Open();
            //SqlCommand cmd = new SqlCommand();
            //string que = ("insert into Flight values ('" + TxtFlightID.Text + "','" + 
            //    TxtAirlineName.Text + "','" + TxtSource.Text + "','" + TxtDestination.Text + "'," + 
            //    TxtSeatCapicity.Text + ",'" + txt_depature.Text + "' ,'" + txt_arrival.Text + "'," + 
            //    txt_flightcharge.Text +  ","+ txt_seat_left.Text+ " )");

            //cmd.CommandText = que;
            //cmd.Connection = con;

            //if (cmd.ExecuteNonQuery() != 0)
            //{
            //    MessageBox.Show("Data insert succesfully");
            //}
            //BtnLoad_Click(null, null);
            //BtnNew_Click(null, null);

            //    con.Close();
            //    cmd.Dispose();



        }

        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            List<FlightModel> flights = FlightDAL.ReadAll();
            dtg_GrdFlight.ItemsSource = flights;

            //SqlConnection con = new SqlConnection(conString);
            //con.Open();
            //string query = "SELECT flight_id,Airline_name,source,designation,seat_capacity,depature,arraival_time,flight_charge,Seat_Left FROM Flight";
            //SqlCommand cmd = new SqlCommand(query, con);


            //SqlDataReader reader = cmd.ExecuteReader();
            //DataTable dt = new DataTable();
            //dt.Load(reader);
            //dtg_GrdFlight.ItemsSource = dt.DefaultView;
            //con.Close();
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            txt_arrival.Clear();
            txt_depature.Clear();
            txt_flightcharge.Clear();
            TxtAirlineName.Clear();
            TxtDestination.Clear();
            TxtFlightID.Clear();
            TxtSeatCapicity.Clear();
            TxtSource.Clear();

        }




        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!isAppClosing)
                e.Cancel = true;
        }
        bool isAppClosing = false;
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            isAppClosing = true;
            System.Windows.Application.Current.Shutdown();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            
            string que = ("delete from Flight where flight_id = '" + TxtFlightID.Text+"'");
            SqlCommand cmd = new SqlCommand(que,con);
           
            if(MessageBox.Show("Do you really want to Delete", "Confirmation", MessageBoxButton.YesNo) != MessageBoxResult.Yes)
            {

                return;
            }

            cmd.ExecuteNonQuery();
            
            MessageBox.Show("Data Delete Successfully");

            con.Close();
            cmd.Dispose();
            BtnLoad_Click(null, null);
            BtnNew_Click(null, null);
            
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            string que = ("Update Flight set  Airline_name = '" + TxtAirlineName.Text + "',source = '" + TxtSource.Text + "',  designation = '" + TxtDestination.Text + "', seat_capacity = " + TxtSeatCapicity.Text + ", depature = '" + txt_depature.Text + "', arraival_time = '" + txt_arrival.Text +"',flight_charge = " +txt_flightcharge.Text + ", Seat_Left = " + txt_seat_left.Text + " Where flight_id ='" + TxtFlightID.Text+"'");
          

            cmd.CommandText = que;
            cmd.Connection = con;
            if( MessageBox.Show("Do you really want to update", "Confirmation", MessageBoxButton.YesNo) != MessageBoxResult.Yes) {

                return;
               
            }
            if (cmd.ExecuteNonQuery() != 0)
            {
                MessageBox.Show("Data Update Successfully");
            }
            BtnLoad_Click(null, null);
            BtnNew_Click(null, null);

        }

        private void btn_booking_Click(object sender, RoutedEventArgs e)
        {
            BookingDetails bookingDetails = new BookingDetails();
            this.Visibility = Visibility.Collapsed;
            bookingDetails.Show();
        }
    }
}
