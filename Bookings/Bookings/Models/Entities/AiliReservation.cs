 using System;
using System.Collections.Generic;

namespace Bookings.Models.Entities
{
    public partial class AiliReservation
    {
        public int Id { get; set; }
        public int NumberOfPeople { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Contact { get; set; }
    }
}
