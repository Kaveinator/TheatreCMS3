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
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime RequestedTime { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime StartTime { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime EndTime { get; set; }
        public string ProjectInfo { get; set; }
        public int RentalCode { get; set; }
        public bool Accepted { get; set; }
        public bool ContractSigned { get; set; }
    }
}