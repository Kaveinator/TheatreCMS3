using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;


namespace TheatreCMS3.Areas.Rent.Models
{
    public class RentalRequest
    {


        [Key]
        public int RentalRequestID { get; set; }
        public string ContactPerson { get; set; }
        public string Company { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTime RequestedTime { get; set; }


        public RentalRequest()
        {
            
            RequestedTime = DateTime.UtcNow.ToUniversalTime();
        }
        

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }

        public string GetRentalDuration()
        {
            TimeSpan diff = EndTime.Subtract(StartTime);
            int days = diff.Days;
            int hours = diff.Hours;
            int minutes = diff.Minutes;
            int seconds = diff.Seconds;

            if (days == 1)
                return "Yesterday";
            if (days > 1)
                return string.Format("{0} days ago", days);
            if (hours > 0)
                return string.Format("{0} hours ago", hours);
            if (minutes > 0)
                return string.Format("{0} minutes ago", minutes);
            if (seconds > 0)
                return string.Format("{0} seconds", seconds);
            return "Just now";
        }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTime EndTime { get; set; }

        public string GetTimeRemaining()
        {
            TimeSpan diff = (DateTime.Now - EndTime).Duration();
            int days = diff.Days;
            int hours = diff.Hours;
            int minutes = diff.Minutes;
            int seconds = diff.Seconds;

            if (days == 1)
                return "Yesterday";
            if (days > 1)
                return string.Format("{0} days ago", days);
            if (hours > 0)
                return string.Format("{0} hours ago", hours);
            if (minutes > 0)
                return string.Format("{0} minutes ago", minutes);
            if (seconds > 0)
                return string.Format("{0} seconds", seconds);
            return "Just now";
        }
        

        public string ProjectInfo { get; set; }
        public int RentalCode { get; set; }
        public bool Accepted { get; set; }
        public bool ContractSigned { get; set; }

    }
}