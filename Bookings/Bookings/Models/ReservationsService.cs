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
            var date = new DateTime(2020, 01, 01);

            var reservations = context.Reservation.ToArray();

            int NumberOFTheFirstDayOfMonth = (int)new DateTime(date.Year, date.Month, 1).DayOfWeek; //mon = 1, tis = 2 osv...

            var result = new List<CalendarDayVM>();

            for (int i = 0; i < DateTime.DaysInMonth(date.Year, date.Month); i++)
            {
                int j = 0;
                var now = date.AddDays(j);

                // Innan vi lägger till värdet, kollar vi
                if (i == NumberOFTheFirstDayOfMonth)
                {
                    var day = new CalendarDayVM { StartDateTime = now, IsWeekend = (now.DayOfWeek == DayOfWeek.Saturday || now.DayOfWeek == DayOfWeek.Sunday), IsClosed = (now.DayOfWeek == DayOfWeek.Monday), CalendarTimeSlots = new List<CalendarTimeSlotVM>() };
                    //lägg now in i Arrayn

                    if (!day.IsClosed)
                    {
                        if (day.IsWeekend)
                        {
                            day.StartDateTime = day.StartDateTime.AddHours(10);
                            //day.EndDateTime = day.StartDateTime.AddHours(8);
                            int openinghours = 8;
                            //day.EndDateTime = day.EndDateTime.AddMinutes(30);

                            //for (day.StartDateTime = day.StartDateTime; day.StartDateTime < day.EndDateTime; day.StartDateTime.AddMinutes(15))
                            //{
                            //    var slot = new CalendarTimeSlotVM { StartDateTime = day.StartDateTime, EndDateTime = day.StartDateTime.AddHours(2) };

                            //    day.CalendarTimeSlots.Add(slot);

                            //    // trigger a method that checks how many bookings there is for the day && specific TIMESLOT
                            //}
                            for (double t = 0; t < openinghours; t += 0.25)
                            {
                                var slot = new CalendarTimeSlotVM { StartDateTime = day.StartDateTime.AddHours(t) };
                                slot.IsFull = reservations.Where(r => r.StartDateTime == slot.StartDateTime).Select(r => r.NumberOfPeople).Sum() > 4;
                                day.CalendarTimeSlots.Add(slot);

                            }


                        }
                        else
                        {
                            day.StartDateTime = day.StartDateTime.AddHours(12);
                            //day.EndDateTime = day.StartDateTime.AddHours(6);
                            int openinghours = 6;

                            //day.EndDateTime = day.EndDateTime.AddMinutes(30);

                            //for (day.StartDateTime = day.StartDateTime; day.StartDateTime < day.EndDateTime; day.StartDateTime.AddMinutes(15))
                            //{
                            //    var slot = new CalendarTimeSlotVM { StartDateTime = day.StartDateTime, EndDateTime = day.StartDateTime.AddHours(2) };

                            //    day.CalendarTimeSlots.Add(slot);

                            //}

                            for (int t = 0; t < openinghours; t++)
                            {
                                var slot = new CalendarTimeSlotVM { StartDateTime = day.StartDateTime.AddHours(t) };
                                day.CalendarTimeSlots.Add(slot);
                            }
                        }
                    }

                    // IF all timeSpaces(amountOfFullTimeSlots) were full => Day is full
                    result.Add(day);
                    j++;
                }
                else
                {
                    var day = new CalendarDayVM();
                    //lägg till null i arrayn
                    result.Add(day);
                }




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
