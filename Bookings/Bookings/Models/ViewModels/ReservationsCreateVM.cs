using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookings.Models.ViewModels
{
    public class ReservationsCreateVM
    {
        //public int Id { get; set; }
        public string Date { get; set; }

        [Required(ErrorMessage = "Enter time")]
        public string Time { get; set; }
        
        [Required(ErrorMessage = "Enter the number of visitors")]
        public int NumberOfPeople { get; set; }

        [Required(ErrorMessage = "Enter e-mail address")]
        [Display (Name = "Email")]
        [EmailAddress]
        public string Contact { get; set; }
    }
}
