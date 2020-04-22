using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookings.Models;
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
        public IActionResult Create(Reservation reservation)
        {
            service.AddReservation(reservation);

            return RedirectToAction(nameof(Index));
        }
        [Route("form")]
        [HttpGet]
        public IActionResult Form()
        {
            var model = service.GetAll();
           
            // Show empty form
            return PartialView("_Create",model);
            //letar upp partial view 
        }
        
    }
}