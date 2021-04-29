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
            TimeSpan x = EndTime.Subtract(StartTime);
            TimeSpan y = EndTime.Subtract(StartTime);
            int days = x.Days;
            int hours = y.Hours;
     
            if (days == 1)
                return "time started";
            if (days > 1)
                return string.Format("{0} days", days);
            if (hours > 0)
                return string.Format("{0} hours", hours);
            return "time left" + x + y;
        }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTime EndTime { get; set; }

        public string GetTimeRemaining()
        {
            TimeSpan x = (DateTime.Now - EndTime).Duration();
            TimeSpan y = (DateTime.Now - EndTime).Duration();
            int days = x.Days;
            int hours = y.Hours;
            
            if (days == 1)
                return "";
            if (days > 1)
                return string.Format("{0} days", days);
            if (hours > 0)
                return string.Format("{0} hours", hours);
            return "time left" + x + y;
        }
        

        public string ProjectInfo { get; set; }
        public int RentalCode { get; set; }
        public bool Accepted { get; set; }
        public bool ContractSigned { get; set; }

    }
}