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
        public List<CalendarTimeSlotVM> CalendarTimeSlots { get; set; }

    }

    public class CalendarTimeSlotVM
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Count { get; set; }

    }
}
