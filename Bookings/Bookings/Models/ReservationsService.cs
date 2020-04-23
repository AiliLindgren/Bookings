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
        TimeSpan testTime = new TimeSpan(15, 00, 00);

        MyContext context;
        public ReservationsService(MyContext context)
        {
            this.context = context;
        }

        internal CalendarDayVM[] GetCalendarView()
        {
            //var date = "22.04.1988";
            var date = new DateTime(1988, 04, 01);

            var reservations = context.AiliReservation.ToArray();
            var result = new List<CalendarDayVM>();
            for (int i = 0; i < DateTime.DaysInMonth(date.Year, date.Month); i++)
            {
                // we need to give the new date all the class properties: isFull, isWeekend,  List<TimeSlot> . 
                // the List is full of objects of a TimeSlot: with properties public DateTime Start, DateTime End, int Count
                // we can start with givin ALL DAYS same instances in the <TimeSlot> List!

                var now = date.AddDays(i);
                result.Add(new CalendarDayVM { IsWeekend = (now.DayOfWeek != DayOfWeek.Saturday && now.DayOfWeek != DayOfWeek.Sunday) });
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
            return context.AiliReservation
            .OrderBy(o => o.Date)
            .Select(o => new ReservationsIndexVM
            {
                Date = o.Date,
                StartTime = o.StartTime,
                EndTime = o.EndTime,
                Contact = o.Contact,
                NumberOfPeople = o.NumberOfPeople,
                HasSpace = CheckIfStartTimeIsFull(testTime)
            })
            .ToArray();
        }
        

        //public int VisitorsAtSameTime(string time)
        //{
        //    var visitors = context.Reservation.Where(o => o.Time == time).Select(o => o.NumberOfPeople).Sum();
        //    return visitors;
        //}

        // Kolla hur många id:n som är kopplade till en viss tid.
        public bool CheckIfStartTimeIsFull(TimeSpan testTime)
        {
            //var visitors = context.AiliReservation.Where(o => o.StartTime == timeSpan).ToList();
            //return visitors.Count() <= 5;

            var visitors = context.AiliReservation.Where(o => o.StartTime == testTime).Select(o => o.NumberOfPeople).Sum();

            if (visitors >= 5)
                return true;
            else
                return false;
        }

        public ReservationsIndexVM[] GetDay()
        {
            return context.AiliReservation.
                OrderBy(o => o.Contact)
                .Select(o => new ReservationsIndexVM
                {
                    Date = o.Date
                })
                .ToArray();
        }

        public void AddReservation(ReservationsCreateVM model)
        {
            context.AiliReservation.Add(new AiliReservation
            {
                Contact = model.Contact,
                Date = model.Date,
                StartTime = model.StartTime,
                EndTime = model.EndTime,
                NumberOfPeople = model.NumberOfPeople

            });

            context.SaveChanges();

            //myReservations.Add(model);
            //model.ID = id;
            ////id++;
        }
    }
}
