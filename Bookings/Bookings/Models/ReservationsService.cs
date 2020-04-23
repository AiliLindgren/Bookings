using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookings.Models
{
    public class ReservationsService
    {
        static List<Reservation> myReservations = new List<Reservation>
        {
            new Reservation{ ID = 1, Contact = "Aili", Date = "21.04.2020", NumberOfVisitors = 1, StartTime = "12.00"},
            new Reservation{ ID = 2, Contact = "Jessica", Date = "22.04.2020", NumberOfVisitors = 1, StartTime = "12.00"},
            new Reservation{ ID = 3, Contact = "Sointu", Date = "23.04.2020", NumberOfVisitors = 6, StartTime = "12.00"},
            new Reservation{ ID = 4, Contact = "Per", Date = "21.04.2020", NumberOfVisitors = 1, StartTime = "12.00"},
            new Reservation{ ID = 5, Contact = "Göran", Date = "22.04.2020", NumberOfVisitors = 1, StartTime = "12.00"},
            new Reservation{ ID = 6, Contact = "bla", Date = "23.04.2020", NumberOfVisitors = 6, StartTime = "12.00"}
        };

        int id = 4;
        int i = 0;
        Reservation reservation;

        public Reservation[] GetAll()
        {
            return myReservations.ToArray();
        }

        public void AddReservation(Reservation reservation)
        {
            myReservations.Add(reservation);
            reservation.ID = id;
            id++;
        }
       
    }
}
