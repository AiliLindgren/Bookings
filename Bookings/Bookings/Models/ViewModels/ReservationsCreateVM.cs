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
        //public DateTime Date { get; set; }
        //public TimeSpan StartTime
        //{ get; set; }
        //public TimeSpan EndTime
        //{ get; set; }
        //public int NumberOfPeople { get; set; }
        //public string Contact { get; set; }


        // ::::A NEW TRY WITH ANOTHER DB WITH DATETIME" DATATYPE::::
        //public int Id { get; set; }

        [Required(ErrorMessage = "Enter the number of visitors")]
        public int NumberOfPeople { get; set; }

        [Required(ErrorMessage = "Enter time")]
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        [Required(ErrorMessage = "Enter e-mail address")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Contact { get; set; }


    }
}
