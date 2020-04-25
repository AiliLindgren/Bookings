using System;
using System.Collections.Generic;

namespace Bookings.Models.Entities
{
    public partial class Reservation
    {
        public int Id { get; set; }
        public int NumberOfPeople { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Contact { get; set; }
    }
}
