using System;

namespace Bookings.Models
{
    internal class AiliReservation
    {
        public string Contact { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int NumberOfPeople { get; set; }
    }
}