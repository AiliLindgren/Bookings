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
            return View();
        }

        [Route("create")]
        [HttpPost]
        public IActionResult Create(ReservationsCreateVM reservation)
        {
            service.AddReservation(reservation);

            return RedirectToAction(nameof(Index));
        }

        [Route("CalendarView")]
        public IActionResult CalendarView()
        {
            var result = service.GetCalendarView();
            return View(result);
        }
        [Route("Bookings/details{date}")]
        public IActionResult Booking(DateTime date)
        {
            var result = service.Check(date);
            return View(result);
        }

        [Route("search")]
        [HttpGet]
        public IActionResult search()
        {
            return View();
        }

        [Route("search")]
        [HttpPost]
        public IActionResult search(DateTime date)
        {

            if (!ModelState.IsValid)
                return View(date);

            // Add customer to DB
            var result= service.Check(date);
            return View(result);

            
        }

        [Route("_search")]
        [HttpGet]
        public IActionResult Search()
        {
            return PartialView("_search");
            //letar upp partial view 
        }

        [Route("_search")]
        [HttpPost]
        public IActionResult Search(DateTime date)
        {
            if (!ModelState.IsValid)
                return View(date);

            // Add customer to DB
            var result = service.Check(date);
            
            // Show empty form
            return PartialView(result);
            //letar upp partial view 
        }



    }
}