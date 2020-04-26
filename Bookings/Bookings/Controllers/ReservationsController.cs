using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookings.Models;
using Bookings.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bookings.Controllers
{
    public class ReservationsController : Controller
    {
        ReservationsService service;

        public ReservationsController(ReservationsService service)
        {
            this.service = service;
        }

        [Route("")]
        [Route("index")]
        [HttpGet]
        public IActionResult Index()
        {
            var model = service.GetAll();
            return View(model);
        }

        [Route("create")]
        [HttpGet]
        public IActionResult Create()
        {
            //service.GetAll()

            return View();
        }

        [Route("create")]
        [HttpPost]
        public IActionResult Create(ReservationsCreateVM reservation)
        {
            service.AddReservation(reservation);

            return RedirectToAction(nameof(Index));
        }

        [Route("CalendarView/{month}")]
        [Route("CalendarView")]
        [HttpGet]
        public ActionResult CalendarView(int month)
        {
            if (month==0)
            {
              var result = service.GetCalendarView(DateTime.Now.Month);
                return View(result);
            }
            else
            {
                var result = service.GetCalendarView(month);
                return View(result);
            }
           
        }
        [Route("calendar")]
        [HttpGet]
        public IActionResult calender(int month,int people)
        {
            var result = service.GetCalendarView(month);
            var model = new
            {
               
            };
            // Show empty form
            return PartialView("_calendar", result.Length);
           
            
           
        }
       

    }
}