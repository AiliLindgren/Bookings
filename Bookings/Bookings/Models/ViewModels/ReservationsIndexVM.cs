using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookings.Models.ViewModels
{
    public class ReservationsIndexVM
    {
        public int Id { get; set; }
        public int NumberOfPeople { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Contact { get; set; }
        public CalendarDayVM Calendar { get; set; }

        
    }
}
