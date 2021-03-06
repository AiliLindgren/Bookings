﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookings.Models.ViewModels
{
    public class ReservationsIndexVM
    {
        //public int Id { get; set; }
        //public DateTime Date { get; set; }
        //public TimeSpan StartTime { get; set; }
        //public TimeSpan EndTime { get; set; }
        //public string Contact { get; set; }
        //public int NumberOfPeople { get; set; }


        public int Id { get; set; }
        public int NumberOfPeople { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Contact { get; set; }
    }
}
