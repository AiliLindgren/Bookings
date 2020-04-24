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
                var day = new CalendarDayVM { StartDateTime = now, IsWeekend = (now.DayOfWeek == DayOfWeek.Saturday && now.DayOfWeek == DayOfWeek.Sunday), IsFull = false, IsClosed = (now.DayOfWeek == DayOfWeek.Monday), CalendarTimeSlots = new List<CalendarTimeSlotVM>() };


                if (!day.IsClosed)
                {
                    if (day.IsWeekend)
                    {
                        day.StartDateTime = day.StartDateTime.AddHours(10);
                        day.EndDateTime = day.StartDateTime.AddHours(8);
                        //day.EndDateTime = day.EndDateTime.AddMinutes(30);


                        for (day.StartDateTime = day.StartDateTime; day.StartDateTime < day.EndDateTime; day.StartDateTime.AddMinutes(15))
                        {
                            var slot = new CalendarTimeSlotVM { StartDateTime = day.StartDateTime, EndDateTime = day.StartDateTime.AddHours(2)};

                            day.CalendarTimeSlots.Add(slot);

                            // trigger a method that checks how many bookings there is for the day && specific TIMESLOT
                        }
                    }
                    else
                    {
                        day.StartDateTime = day.StartDateTime.AddHours(12);
                        day.EndDateTime = day.StartDateTime.AddHours(6);
                        //day.EndDateTime = day.EndDateTime.AddMinutes(30);

                        for (day.StartDateTime = day.StartDateTime; day.StartDateTime < day.EndDateTime; day.StartDateTime.AddMinutes(15))
                        {
                            var slot = new CalendarTimeSlotVM { StartDateTime = day.StartDateTime, EndDateTime = day.StartDateTime.AddHours(2) };

                            day.CalendarTimeSlots.Add(slot);

                        }
                    }
                }

                // IF all timeSpaces(amountOfFullTimeSlots) were full => Day is full
                result.Add(day);
            }
            //return new CalendarViewVM {IsFull = context.Reservation.Any(o => o.Date == date)};
            return result.ToArray();
        }


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
