using System;
using System.Collections.Generic;

namespace Bookings.Models.Entities
{
    public partial class Reservation
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan SartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int NumberOfPeople { get; set; }
        public string Contact { get; set; }
    }
}
