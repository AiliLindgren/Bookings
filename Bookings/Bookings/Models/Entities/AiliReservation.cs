using System;
using System.Collections.Generic;

namespace Bookings.Models.Entities
{
    public partial class AiliReservation
    {
        public int Id { get; set; }
        public int NumberOfPeople { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Contact { get; set; }
    }
}
