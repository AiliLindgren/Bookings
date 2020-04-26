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

        // Tillfällig kommentar.

        //internal CalendarDayVM[] next()
        //{
        //    var currentYear = DateTime.Today.Year;
        //    var currentMonth= DateTime.Today.Month;
        //    currentYear = (currentMonth ==11) ? currentYear + 1 : currentYear;
        //    currentMonth = (currentMonth + 1) % 12;
        //    return GetCalendarView(currentMonth,currentYear);
        //}

        //internal CalendarDayVM[] previous()
        //{
        //    var currentYear = DateTime.Today.Year;
        //    var currentMonth = DateTime.Today.Month;
        //    currentYear = (currentMonth == 0) ? currentYear - 1 : currentYear;
        //    currentMonth = (currentMonth == 0) ? 11 : currentMonth - 1;
        //    //return GetCalendarView(currentMonth, currentYear);
        //}


        internal CalendarDayVM[] GetCalendarView(int month,int people)
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
                        IsClosed = (calendarDate.DayOfWeek == DayOfWeek.Monday), CalendarTimeSlots = new List<CalendarTimeSlotVM>() 
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

                                day.CalendarTimeSlots.Add(slot);
                            }
                            //int openinghours = 2;
                            //day.StartDateTime = day.StartDateTime.AddHours(10);
                            //day.EndDateTime = day.StartDateTime.AddHours(openinghours);

                            //for (int time = 0; time < openinghours; time++)
                            //{
                            //    var slot = new CalendarTimeSlotVM { StartDateTime = day.StartDateTime.AddHours(time), EndDateTime = day.StartDateTime.AddHours(time + 2) };

                            //    //if (start == day.EndDateTime)
                            //    //{
                            //    //    slot.EndDateTime = start.AddHours(1.5);
                            //    //}
                            //    //else if (start == day.EndDateTime.AddMinutes(-15))
                            //    //{
                            //    //    slot.EndDateTime = start.AddHours(1.75);
                            //    //}
                            //    //else
                            //    //slot.EndDateTime = start.AddHours(2);

                            //    //slot.IsFull = reservations.Where(r => r.StartDateTime == slot.StartDateTime).Select(r => r.NumberOfPeople).Sum() > 4;

                            //    day.CalendarTimeSlots.Add(slot);
                            //}

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

                                day.CalendarTimeSlots.Add(slot);
                            }
                        }

                        //if (day.CalendarTimeSlots.Any(s => s.IsFull == false))
                        if (day.CalendarTimeSlots.All(s => s.IsFull == true))
                        {
                            day.IsFull = true;
                        }

                    }//If fay is not closed


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
