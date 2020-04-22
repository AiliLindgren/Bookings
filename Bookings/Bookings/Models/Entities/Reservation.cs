using System;
using System.Collections.Generic;

namespace Bookings.Models.Entities
{
    public partial class Reservation
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int NumberOfPeople { get; set; }
        public string Contact { get; set; }
    }
}
