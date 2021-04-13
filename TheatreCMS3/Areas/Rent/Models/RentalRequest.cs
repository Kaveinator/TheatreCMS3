using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Rent.Models
{
    public class RentalRequest
    {
        [Key]
        public int RentalRequestID { get; set; }
        public string ContactPerson { get; set; }
        public string Company { get; set; }        
        public DateTime RequestedTime { get; set; }
        [DataType(DataType.Time)]        
        public DateTime StartTime { get; set; }
        [DataType(DataType.Time)]        
        public DateTime EndTime { get; set; }
        public string ProjectInfo { get; set; }
        public int RentalCode { get; set; }
        public bool Accepted { get; set; }
        public bool ContractSigned { get; set; }


        public RentalRequest()
        {
            RequestedTime = DateTime.Now;
        }

        
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
    }
}