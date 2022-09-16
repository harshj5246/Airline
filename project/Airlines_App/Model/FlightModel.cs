using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airlines_App.Model
{
    public class FlightModel
    {
        public string flight_id { get; set; }
        public string Airline_name { get; set; }
        public string source { get; set; }
        public string designation { get; set; }
        public int seat_capacity { get; set; }
        public string depature { get; set; }
        public string arraival_time { get; set; }
        public double flight_charge { get; set; }
        public int Seat_Left { get; set; }

        public FlightModel():
            this(string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                0,
                string.Empty,
                string.Empty,
                0,
                0)
        {
        }

        public FlightModel(
            string flight_id,
            string airline_name,
            string source,
            string designation,
            int seat_capacity,
            string depature,
            string arraival_time,
            double flight_charge,
            int seat_Left)
        {
            this.flight_id = flight_id;
            Airline_name = airline_name;
            this.source = source;
            this.designation = designation;
            this.seat_capacity = seat_capacity;
            this.depature = depature;
            this.arraival_time = arraival_time;
            this.flight_charge = flight_charge;
            Seat_Left = seat_Left;
        }
    }
}
