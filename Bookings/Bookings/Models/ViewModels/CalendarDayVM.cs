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
        public DateTime Month { get; set; }
        public DateTime Year { get; set; }

        
        


        //public int OpeningHours { get; set; }

        public List<CalendarTimeSlotVM> CalendarTimeSlots { get; set; }

       
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        public bool FakeDay { get; set; }
    }

    public class CalendarTimeSlotVM
    {
        public bool IsFull { get; set; }
        public DateTime StartDateTime { get; set; } 
        public DateTime EndDateTime { get; set; }

        public override string ToString()
        {
            return $"{StartDateTime}";
        }

    }
}
