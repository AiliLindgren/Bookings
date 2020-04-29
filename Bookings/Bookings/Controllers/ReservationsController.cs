using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookings.Models;
using Bookings.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Bookings.Controllers
{
    public class ReservationsController : Controller
    {
        ReservationsService service;
        IMemoryCache cache;
        
        public ReservationsController(ReservationsService service,IMemoryCache cache)
        {
            this.service = service;
            this.cache = cache;
        }
       

        [Route("")]
        [Route("index")]
        [HttpGet]
        public IActionResult Index()
        {
            
            return View();
        }
      
        [Route("Confirm")]
        [HttpGet]
        public IActionResult Confirmation()
        {            
            return Content((string)TempData["Message"]);         
        }

        [Route("create")]
        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }

        [Route("CalendarView")]
        [HttpGet]
        public ActionResult CalendarView()
        {
            var model = new ReservationsCreateVM
            {
                StartDateTime = DateTime.Today.AddDays(1).AddHours(10),
                NumberOfPeople = 0,
                //Contact = "email@email.com"
            };
            return View(model);

        }
        [Route("CalendarView")]
        [HttpPost]
        public IActionResult CalendarView(ReservationsCreateVM reservation)
        {
            if (!ModelState.IsValid)
                return View(reservation);

            service.AddReservation(reservation);

            TempData["Message"]= $"Thank you {reservation.Contact.ToString()}, your order has been submitted! Reservation for {reservation.NumberOfPeople} people { reservation.StartDateTime}";
           
            return RedirectToAction(nameof(Confirmation));
        }
        

        [Route("calender/{month}")]
        [HttpGet]
        public IActionResult Calendar(int month)
        {
            var result = service.GetCalendarView(month);
            return PartialView("_calender", result);

        }


        //[Route("timebox-data")]
        //[HttpGet]
        //public IActionResult TimeboxData(CalendarTimeSlotVM dayAndTime)
        //{
        //    // Show empty form
        //    var model = new
        //    {
        //        StartDateTime = dayAndTime.StartDateTime.Date.ToString()
        //    };
        //    return Json(model);
        //}

       
    }
}