using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookings.Models.ViewModels
{
    public class CalendarDayVM

    {
        //27-31 days 
        //Array of Timeslots 
        public bool IsWeekend { get; set; } 
        public bool IsFull { get; set; }
        public bool IsClosed { get; set; }

        public List<TimeSlotVM> TimeSlots { get; set; }


        //public int OpeningHours { get; set; } // Behövs nog inte
    }

    public class TimeSlotVM
    {
        public DateTime Start { get; set; }
        public bool TimeIsFull { get; set; } 

        //public DateTime End { get; set; } // Behövs inte än iaf
        //public int Count { get; set; } // Behövs nog inte

    }
}
