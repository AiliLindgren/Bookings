using Bookings.Models.Entities;
using Bookings.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookings.Models
{
    public class ReservationsService
    {

        //static List<Reservation> myReservations = new List<Reservation>
        //{
        //    new Reservation{ ID = 1, Contact = "Aili", Date = "21.04.2020", NumberOfVisitors = 1, StartTime = "12.00"},
        //    new Reservation{ ID = 2, Contact = "Jessica", Date = "22.04.2020", NumberOfVisitors = 1, StartTime = "12.00"},
        //    new Reservation{ ID = 3, Contact = "Sointu", Date = "23.04.2020", NumberOfVisitors = 6, StartTime = "12.00"}
        //};

        //int id = 4;

        MyContext context;
        public ReservationsService(MyContext context)
        {
            this.context = context;
        }

        internal CalendarDayVM[] GetCalendarView()
        {
            //var date = "22.04.1988";
            var date = new DateTime(1988, 04, 01);

            var reservations = context.Reservation.ToArray();
            var result = new List<CalendarDayVM>();
            for (int i = 0; i < DateTime.DaysInMonth(date.Year, date.Month); i++)
            {
                var now = date.AddDays(i);
                result.Add(new CalendarDayVM { IsWeekend = (now.DayOfWeek != DayOfWeek.Saturday && now.DayOfWeek != DayOfWeek.Sunday )});
            }
            //return new CalendarViewVM {IsFull = context.Reservation.Any(o => o.Date == date)};
            return result.ToArray();
        }
        //internal CalendarViewVM[] CheckIfFull()
        //{
        //    var date = "22.04.1988";

        //    return new CalendarViewVM { IsFull = context.Reservation.Any(o => o.Date == date) };
        //}


        //public ReservationsCreateVM IsItFull(string time)
        //{
        //    var amount = context.Reservation.
        //        OrderBy(o => o.Contact)
        //          .Where(o => o.Time == time)
        //          .Select(o => new ReservationsIndexVM
        //          {
        //              Date = o.Date,
        //              Time = o.Time,
        //              Contact = o.Contact,
        //              NumberOfPeople = o.NumberOfPeople,
        //          })
        //        .ToArray().Count();

        //    if (amount > 4)
        //    {

        //    }
        //}


        public ReservationsIndexVM[] GetAll()
        {
            return context.Reservation.
                OrderBy(o => o.Contact)
                  .Select(o => new ReservationsIndexVM
                  {
                      Date = o.Date,
                      Time = o.Time,
                      Contact = o.Contact,
                      NumberOfPeople = o.NumberOfPeople,

                  })
                .ToArray();
        }

        public void AddReservation(ReservationsCreateVM model)
        {
            context.Reservation.Add(new Reservation
            {
                Contact = model.Contact,
                Date = model.Date,
                Time = model.Time,
                NumberOfPeople = model.NumberOfPeople

            });

            context.SaveChanges();

            //myReservations.Add(model);
            //model.ID = id;
            ////id++;
        }


    }
}
