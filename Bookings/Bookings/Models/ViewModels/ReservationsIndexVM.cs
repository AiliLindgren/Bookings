using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookings.Models.ViewModels
{
    public class ReservationsIndexVM
    {
        //public int Id { get; set; }
        //public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        //public DateTime CreatedAt { get; set; }
        public string Contact { get; set; }
        public int NumberOfPeople { get; set; }

        public bool Isfull { get; set; }

    }
}
