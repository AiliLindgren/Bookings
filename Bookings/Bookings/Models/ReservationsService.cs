using Bookings.Models.Entities;
using Bookings.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            var reservations = context.Reservation.ToArray();
            var result = new List<CalendarDayVM>();

            var date = new DateTime(2020, 04, 12);
            var calendarDate = new DateTime(date.Year, date.Month, 1);
            int weekdayInt = (int)new DateTime(date.Year, date.Month, 1).DayOfWeek - 1; //mon = 1, tis = 2 osv...
            int totalCalendarSpots = (DateTime.DaysInMonth(date.Year, date.Month) + weekdayInt);

            for (int i = 0; weekdayInt < totalCalendarSpots; i++)
            {
                if (i == weekdayInt)
                {
                    var day = new CalendarDayVM { StartDateTime = calendarDate, FakeDay = false, IsWeekend = (calendarDate.DayOfWeek == DayOfWeek.Saturday || calendarDate.DayOfWeek == DayOfWeek.Sunday), IsClosed = (calendarDate.DayOfWeek == DayOfWeek.Monday), CalendarTimeSlots = new List<CalendarTimeSlotVM>() };

                    weekdayInt++;
                    calendarDate = calendarDate.AddDays(1);

                    result.Add(day);
                }
                else
                {
                    var day = new CalendarDayVM { FakeDay = true, CalendarTimeSlots = new List<CalendarTimeSlotVM>() };
                    result.Add(day);
                }
            }

            return result.ToArray();
                    //if (!day.IsClosed)
                    //{
                    //    if (day.IsWeekend)
                    //    {
                    //        day.StartDateTime = day.StartDateTime.AddHours(10);
                    //        //day.EndDateTime = day.StartDateTime.AddHours(8);
                    //        int openinghours = 8;
                    //        //day.EndDateTime = day.EndDateTime.AddMinutes(30);

                    //        //for (day.StartDateTime = day.StartDateTime; day.StartDateTime < day.EndDateTime; day.StartDateTime.AddMinutes(15))
                    //        //{
                    //        //    var slot = new CalendarTimeSlotVM { StartDateTime = day.StartDateTime, EndDateTime = day.StartDateTime.AddHours(2) };

                    //        //    day.CalendarTimeSlots.Add(slot);

                    //        //    // trigger a method that checks how many bookings there is for the day && specific TIMESLOT
                    //        //}
                    //        for (double t = 0; t < openinghours; t += 0.25)
                    //        {
                    //            var slot = new CalendarTimeSlotVM { StartDateTime = day.StartDateTime.AddHours(t) };
                    //            slot.IsFull = reservations.Where(r => r.StartDateTime == slot.StartDateTime).Select(r => r.NumberOfPeople).Sum() > 4;
                    //            day.CalendarTimeSlots.Add(slot);

                    //        }


                    //    }
                    //    else
                    //    {
                    //        day.StartDateTime = day.StartDateTime.AddHours(12);
                    //        //day.EndDateTime = day.StartDateTime.AddHours(6);
                    //        int openinghours = 6;

                    //        //day.EndDateTime = day.EndDateTime.AddMinutes(30);

                    //        //for (day.StartDateTime = day.StartDateTime; day.StartDateTime < day.EndDateTime; day.StartDateTime.AddMinutes(15))
                    //        //{
                    //        //    var slot = new CalendarTimeSlotVM { StartDateTime = day.StartDateTime, EndDateTime = day.StartDateTime.AddHours(2) };

                    //        //    day.CalendarTimeSlots.Add(slot);

                    //        //}

                    //        for (int t = 0; t < openinghours; t++)
                    //        {
                    //            var slot = new CalendarTimeSlotVM { StartDateTime = day.StartDateTime.AddHours(t) };
                    //            day.CalendarTimeSlots.Add(slot);
                    //        }
                    //    }
                    //}

                    // IF all timeSpaces(amountOfFullTimeSlots) were full => Day is full
        }


        public ReservationsIndexVM[] GetAll()
        {
            return context.Reservation.
                OrderBy(o => o.Contact)
                .Select(o => new ReservationsIndexVM
                {
                    EndDateTime = o.EndDateTime,
                    StartDateTime = o.StartDateTime,
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
                    StartDateTime = o.StartDateTime
                })
                .ToArray();
        }

        public void AddReservation(ReservationsCreateVM model)
        {
            context.Reservation.Add(new Reservation
            {
                Contact = model.Contact,
                StartDateTime = model.StartDateTime,
                EndDateTime = model.EndDateTime,
                NumberOfPeople = model.NumberOfPeople

            });

            context.SaveChanges();

            //myReservations.Add(model);
            //model.ID = id;
            ////id++;
        }


    }
}
