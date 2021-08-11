using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Rent.Models
{
    public class Rental
    {
       
        public int RentalId { get; set; }
        [DisplayName("Rental Name:")]
        public string RentalName { get; set; }
        [DisplayName("Rental Cost:")]
        public int RentalCost { get; set; }
        [DisplayName("Flaws and Damages:")]
        public string FlawsAndDamages { get; set; }
    }
}