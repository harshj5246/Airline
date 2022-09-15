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
        public static long flightid;
        public Booking()
        {
            InitializeComponent();
            ReadFields();
            txt_usernamebk.Text = Login.username;
            txt_Arilinenamebk.Text = Dashboard.airline;
            txt_datebk.Text = Dashboard.date;


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

            txt_flightid.Text = ds.Tables[0].Rows[0]["flight_id"].ToString();

            txt_destinationbk.Text = ds.Tables[0].Rows[0]["designation"].ToString();
            txt_sourcebk.Text = ds.Tables[0].Rows[0]["source"].ToString();
            txt_flightcharge.Text = ds.Tables[0].Rows[0]["flight_charge"].ToString();

            con.Close();


        }



        private void BtnBook_click(object sender, RoutedEventArgs e)
        {

            if (txt_noftickets.Text == string.Empty)
            {
                MessageBox.Show("fill the no.of tickets");
                txt_noftickets.Focus();
                return;
            }
            if (cmb_class.SelectedItem == null)
            {
                MessageBox.Show("select the class");
                cmb_class.Focus();
                return;
            }

            SqlConnection con = new SqlConnection(conString);
            con.Open();

            string qur = string.Format("insert into booking(flight_id,username,source,destination,class,date,no_of_tickets,total_amount,Airline_name) values('{0}','{1}','{2}','{3}','{4}','{5}',{6},{7},'{8}');select scope_identity();", txt_flightid.Text, txt_usernamebk.Text, txt_sourcebk.Text, txt_destinationbk.Text, cmb_class.Text.ToString(), txt_datebk.Text, txt_noftickets.Text, txt_totalamount.Text,txt_Arilinenamebk.Text); 

            SqlCommand cmd = new SqlCommand(qur, con);

            int no1 = seats();
            int editno = no1 -int.Parse(txt_noftickets.Text);


            SqlConnection fcon = new SqlConnection(conString);
            fcon.Open();
            string query = ("Update Flight set  Seat_Left = " + editno + " Where flight_id ='" + txt_flightid.Text + "'");


            SqlCommand cmmd = new SqlCommand(query, con);

            cmmd.ExecuteNonQuery();
            fcon.Close();
            cmmd.Dispose();




            long newid = long.Parse(cmd.ExecuteScalar().ToString());
            flightid = newid;


            con.Close();
            MessageBoxResult res = MessageBox.Show("Do you want to Confirm Ticket booking?", "Confirmation", MessageBoxButton.OKCancel);
            if (res == MessageBoxResult.OK)
            {
                ConfirmBooking cb = new ConfirmBooking();
                this.Visibility = Visibility.Collapsed;
                cb.Show();
            }
            else
            {
                Dashboard db = new Dashboard();
                this.Visibility = Visibility.Collapsed;
                db.Show();
            }





        }




        public int seats()
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string flightque = ("Select Seat_Left from Flight where flight_id = '" + txt_flightid.Text + "'");

            SqlDataAdapter flightadapter = new SqlDataAdapter(flightque, con);

            DataSet ds = new DataSet();

            flightadapter.Fill(ds);

            int no = Convert.ToInt32(ds.Tables[0].Rows[0]["Seat_Left"]);
            con.Close();
            return no;

        }



        private void cmb_class_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }



        private void txt_totalamount_MouseEnter(object sender, MouseEventArgs e)
        {

            if (cmb_class.SelectedIndex == 0)
            {



                int ticket_fare = int.Parse(txt_noftickets.Text);
                int t = int.Parse(txt_flightcharge.Text);
                int tick = t * ticket_fare;

                txt_totalamount.Text = tick.ToString();


            }
            else if (cmb_class.SelectedIndex == 1)
            {
                int t = 1000 + int.Parse(txt_flightcharge.Text);
                int ticket_fare = int.Parse(txt_noftickets.Text);
                int tick = t * ticket_fare;
                txt_totalamount.Text = tick.ToString();


            }
            else if (cmb_class.SelectedIndex == 2)
            {
                int t = 2000 + int.Parse(txt_flightcharge.Text);
                int ticket_fare = int.Parse(txt_noftickets.Text);
                int tick = t * ticket_fare;
                txt_totalamount.Text = tick.ToString();


            }

        }

        private void btn_logout_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            this.Visibility = Visibility.Collapsed;
            login.Show();
        }

        private void btn_dashbord_Click(object sender, RoutedEventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            this.Visibility = Visibility.Collapsed;
            dashboard.Show();
        }
    }
}

