using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TheatreCMS3.Areas.Rent.Models
{
    public class RentalRequest
    {
        public RentalRequest()
        {
            RequestedTime = DateTime.Now;

            // Rentals = new List<Rental>();   // Adding empty list of rentals upon initialization.
        }


        public int RentalRequestId { get; set; }
        public string ContactPerson { get; set; }
        public string Company { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime RequestedTime { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime StartTime { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime EndTime { get; set; }
        public string ProjectInfo { get; set; }
        public int RentalCode { get; set; }
        public bool Accepted { get; set; }
        public bool ContractSigned { get; set; }

        public int MyProperty { get; set; }

       // public List<Rental> Rentals { get; set; }

        public TimeSpan GetRentalDuration()
        {
            TimeSpan rentalDuration = EndTime - StartTime;
            return rentalDuration;
        }


        public TimeSpan GetTimeRemaining()
        {
            TimeSpan timeRemaining = EndTime - DateTime.Now;
            return timeRemaining;
        }

        public TimeSpan GetTimeTillStart()
        {
            TimeSpan startsIn = StartTime - DateTime.Now;
            return startsIn;
        }


    }
}