using Bookings.Models.Entities;
using Bookings.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
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
                // we need to give the new date all the class properties: isFull, isWeekend,  List<TimeSlot> . 
                // the List is full of objects of a TimeSlot: with properties public DateTime Start, DateTime End, int Count
                // we can start with givin ALL DAYS same instances in the <TimeSlot> List!

                var now = date.AddDays(i);
                var day = new CalendarDayVM { IsWeekend = (now.DayOfWeek == DayOfWeek.Saturday && now.DayOfWeek == DayOfWeek.Sunday), IsFull = false, IsClosed = (now.DayOfWeek == DayOfWeek.Monday), CalendarTimeSlots = new List<CalendarTimeSlotVM>() };


                if (!day.IsClosed)
                {
                    if (day.IsWeekend)
                    {
                        day.OpeningHours = 10;
                        var hour = 10;

                        for (int t = 0; t < day.OpeningHours / 2; t++)
                        {
                            // DateTime dt = 23.04.2019 12:00:00
                            // dt.AddHours(2);

                            var slot = new CalendarTimeSlotVM { Start = hour };

                            // StartEndTime, EndDateTime

                            //var amountOfFullTimeSlots = 0;
                            // IsFull = context.Reservations.Where(r => r.StartDateTime = ).Select(r.NumberofPeople).Sum() > 5;
                            // if (isFull) amountOfFullTimeSlots++

                            hour += 2;
                            slot.End = hour;
                            day.CalendarTimeSlots.Add(slot);

                            // trigger a method that checks how many bookings there is for the day && specific TIMESLOT
                        }
                    }
                    else
                    {
                        day.OpeningHours = 6;
                        var hour = 12;

                        for (int t = 0; t < day.OpeningHours / 2; t++)
                        {

                            var slot = new CalendarTimeSlotVM { Start = hour };
                            hour += 2;
                            slot.End = hour;
                            day.CalendarTimeSlots.Add(slot);

                            // trigger a method that checks how many bookings there is for the day && specific TIMESLOT
                        }
                    }

                }


                // IF all timeSpaces(amountOfFullTimeSlots) were full => Day is full
                result.Add(day);
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
                    EndTime = o.EndTime,
                    StartTime = o.StartTime,
                    Contact = o.Contact,
                    NumberOfPeople = o.NumberOfPeople,

                })
                .ToArray();
        }

        public ReservationsIndexVM[] GetDay()
        {
            return context.Reservation.
                OrderBy(o => o.Contact)
                .Select(o => new ReservationsIndexVM
                {
                    StartTime = o.StartTime
                })
                .ToArray();
        }

        public void AddReservation(ReservationsCreateVM model)
        {
            context.Reservation.Add(new Reservation
            {
                Contact = model.Contact,
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
