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
        public bool IsClosed { get; set; }

        public bool IsFull { get; set; }
        public int OpeningHours { get; set; }

        public List<CalendarTimeSlotVM> CalendarTimeSlots { get; set; }


    }

    public class CalendarTimeSlotVM
    {
        public int Start { get; set; }
        public int End { get; set; }

    }
}
