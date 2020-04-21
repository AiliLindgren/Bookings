using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookings.Models
{
    public class Reservation
    {
        public int ID { get; set; }
        public string Contact { get; set; }
        public int NumberOfVisitors { get; set; }
        public string StartTime { get; set; } // Datatype?? Double? 

        //public TimeSpan EndTime { get; set; }
        public string Date { get; set; }

    }

    
}
