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

        [Route("CalendarView")]
        [HttpGet]
        public IActionResult CalendarView()
        {
            var result = service.GetCalendarView();
            return View(result);
        }
        

       
    }
}