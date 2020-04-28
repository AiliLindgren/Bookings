using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookings.Models.ViewModels
{
    public class ReservationsCreateVM
    {
        [Required(ErrorMessage = "Enter the number of visitors")]
        public int NumberOfPeople { get; set; }

        //[Required(ErrorMessage = "Enter time")]
        public DateTime StartDateTime { get; set; }
        //public DateTime EndDateTime { get; set; }

        //[Required(ErrorMessage = "Enter e-mail address")]
        //[Display(Name = "Email")]
        //[EmailAddress]
        //public string Contact { get; set; }
       

    }
}
