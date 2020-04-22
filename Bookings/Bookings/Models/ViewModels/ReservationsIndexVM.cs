using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookings.Models.ViewModels
{
    public class ReservationsIndexVM
    {
        //public int Id { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Contact { get; set; }
        public int NumberOfPeople { get; set; }
    }
}
