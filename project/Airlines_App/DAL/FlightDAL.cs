using Airlines_App.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airlines_App;

namespace Airlines_App.DAL
{
    public class FlightDAL
    {
        public static List<FlightModel> ReadBySearch(
            string source,
            string destination,
            DateTime travelDate
            )
        {
            List<FlightModel> flights = new List<FlightModel>();

            //Move code here
            SqlConnection con = new SqlConnection(ConnectionString.conString);
            con.Open();

            string query = string.Format(@"SELECT 
flight_id,Airline_name,source,
designation,seat_capacity,depature,
arraival_time,flight_charge 
FROM Flight 
where (source='{0}') and 
(designation='{1}')",
source, destination);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            con.Close();

            foreach (DataRow row in dt.Rows)
            {
                FlightModel model = new FlightModel();
                model.flight_id =(string) row["flight_id"];
                model.Airline_name = (string)row["Airline_name"];
                model.source = (string)row["source"];
                model.designation = (string)row["designation"];
                model.seat_capacity = (int) row["seat_capacity"];
                model.depature = (string)row["depature"];
                model.arraival_time = (string)row["arraival_time"];
                model.flight_charge = (double)row["flight_charge"];
                //model.Seat_Left = row["Seat_Left"];

                //Use the arg construction to replace no-arg construction and setters
                flights.Add(model);
            }

            return flights;
        }
        public static List<FlightModel> ReadAll(
            
            )
        {
            List<FlightModel> flights = new List<FlightModel>();

            //Move code here
            SqlConnection con = new SqlConnection(ConnectionString.conString);
            con.Open();

            string query = string.Format(@"SELECT 
flight_id,Airline_name,source,
designation,seat_capacity,depature,
arraival_time,flight_charge,Seat_Left 
FROM Flight");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            con.Close();

            foreach (DataRow row in dt.Rows)
            {
                FlightModel model = new FlightModel();
                model.flight_id = (string)row["flight_id"];
                model.Airline_name = (string)row["Airline_name"];
                model.source = (string)row["source"];
                model.designation = (string)row["designation"];
                model.seat_capacity = (int)row["seat_capacity"];
                model.depature = (string)row["depature"];
                model.arraival_time = (string)row["arraival_time"];
                model.flight_charge = (double)row["flight_charge"];
                model.Seat_Left = (int)row["Seat_Left"];

                //Use the arg construction to replace no-arg construction and setters
                flights.Add(model);
            }

            return flights;
        }
        public static bool Create(FlightModel model)
        {
            SqlConnection con = new SqlConnection(ConnectionString.conString);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            string que = string.Format(@"insert into Flight 
values ('{0}','{1}','{2}','{3}',{4},
'{5}','{6}',{7},{8});",
model.flight_id,
model.Airline_name,
model.source,
model.designation,
model.seat_capacity,
model.depature,
model.arraival_time,
model.flight_charge,
model.Seat_Left);


            cmd.CommandText = que;
            cmd.Connection = con;

            int resCount = cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();

            return resCount != 0;
        }
    }
}
