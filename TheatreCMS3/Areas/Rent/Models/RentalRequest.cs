using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Rent.Models
{
    public class RentalRequest
    {
        public int RentalRequestID { get; set; }
        public string ContactPerson { get; set; }
        public string Company { get; set; }
        public DateTime RequestedTime { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string ProjectInfo { get; set; }
        public int RentalCode { get; set; }
        public bool Accepted { get; set; }
        public bool ContractSigned { get; set; }


        public string GetRentalDuration()
        {
            var now = DateTime.Now;

            if (EndTime > now && now > StartTime)
            {
                TimeSpan timeRemaining = EndTime - now;
                string formattedTimeRemaining = string.Format("{0} days, {1} hours, {2} minutes, {3} seconds.",
                timeRemaining.Days, timeRemaining.Hours, timeRemaining.Minutes, timeRemaining.Seconds);

                return formattedTimeRemaining;
            }
            
            if (StartTime > now)
            {
                TimeSpan timeUntilRentalStarts = StartTime - now;
                string formattedTimeUntilRentalStarts = string.Format("{0} days, {1} hours, {2} minutes, {3} seconds.",
                timeUntilRentalStarts.Days, timeUntilRentalStarts.Hours, timeUntilRentalStarts.Minutes, timeUntilRentalStarts.Seconds);

                return formattedTimeUntilRentalStarts;
            }
        }

    }
}