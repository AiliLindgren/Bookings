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

        MyContext context;
        public ReservationsService(MyContext context)
        {
            this.context = context;
        }


        internal CalendarDayVM[] GetCalendarView(int month)
        {
            var reservations = context.Reservation.ToArray();
            var result = new List<CalendarDayVM>();

            //DateTime date = DateTime.Now;
            DateTime date = new DateTime(2020, month, 1);
            var calendarDate = new DateTime(date.Year, date.Month, 1);
            int weekdayInt = (int)new DateTime(date.Year, date.Month, 1).DayOfWeek - 1; //mon = 1, tis = 2 osv...
            int totalCalendarSpots = (DateTime.DaysInMonth(date.Year, date.Month) + weekdayInt);

            for (int i = 0; weekdayInt < totalCalendarSpots; i++)
            {
                if (i == weekdayInt)
                {
                    var day = new CalendarDayVM
                    {
                        StartDateTime = calendarDate,
                        FakeDay = false,
                        IsWeekend = (calendarDate.DayOfWeek == DayOfWeek.Saturday || calendarDate.DayOfWeek == DayOfWeek.Sunday),
                        IsClosed = (calendarDate.DayOfWeek == DayOfWeek.Monday),
                        CalendarTimeSlots = new List<CalendarTimeSlotVM>()
                    };

                    weekdayInt++;
                    calendarDate = calendarDate.AddDays(1);


                    if (!day.IsClosed)
                    {
                        if (day.IsWeekend)
                        {
                            day.StartDateTime = day.StartDateTime.AddHours(10);
                            //day.EndDateTime = day.StartDateTime.AddHours(1);
                            day.EndDateTime = day.StartDateTime.AddMinutes(60);

                            for (var start = day.StartDateTime; start <= day.EndDateTime; start = start.AddMinutes(15))
                            {
                                var slot = new CalendarTimeSlotVM { StartDateTime = start };


                                if (start == day.EndDateTime)
                                {
                                    slot.EndDateTime = start.AddHours(1.5);
                                }
                                else if (start == day.EndDateTime.AddMinutes(-15))
                                {
                                    slot.EndDateTime = start.AddHours(1.75);
                                }
                                else
                                    slot.EndDateTime = start.AddHours(2);

                                slot.IsFull = reservations.Where(r => r.StartDateTime == slot.StartDateTime).Select(r => r.NumberOfPeople).Sum() > 4;
                                slot.PlacesLeft = 5 - CheckForPeople(slot.StartDateTime);
                                day.CalendarTimeSlots.Add(slot);
                            }

                        }
                        else
                        {
                            day.StartDateTime = day.StartDateTime.AddHours(10);
                            //day.EndDateTime = day.StartDateTime.AddHours(1);
                            day.EndDateTime = day.StartDateTime.AddMinutes(30);

                            for (var start = day.StartDateTime; start <= day.EndDateTime; start = start.AddMinutes(15))
                            {
                                var slot = new CalendarTimeSlotVM { StartDateTime = start };


                                if (start == day.EndDateTime)
                                {
                                    slot.EndDateTime = start.AddHours(1.5);
                                }
                                else if (start == day.EndDateTime.AddMinutes(-15))
                                {
                                    slot.EndDateTime = start.AddHours(1.75);
                                }
                                else
                                    slot.EndDateTime = start.AddHours(2);

                                slot.IsFull = reservations.Where(r => r.StartDateTime == slot.StartDateTime).Select(r => r.NumberOfPeople).Sum() > 4;
                                slot.PlacesLeft= 5 - CheckForPeople(slot.StartDateTime);

                                day.CalendarTimeSlots.Add(slot);
                                
                               
                            }
                        }

                        if (day.CalendarTimeSlots.All(s => s.IsFull == true))
                        {
                            day.IsFull = true;
                        }

                    }


                    result.Add(day);
                }
                else
                {
                    var day = new CalendarDayVM { FakeDay = true, CalendarTimeSlots = new List<CalendarTimeSlotVM>() };
                    result.Add(day);
                }

            }//For loop

            return result.ToArray();

        }//GetCalendarView()

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
                NumberOfPeople = model.NumberOfPeople

            });

            context.SaveChanges();



        }
        public int CheckForPeople(DateTime Timeslot)
        {
            var result = context.Reservation.Where(o => o.StartDateTime == Timeslot).Select(o => o.NumberOfPeople).Sum();
            return result;
        }
        //public CalendarDayVM[] GetCalendarView(int people)
        //{

        //}
    }
}
