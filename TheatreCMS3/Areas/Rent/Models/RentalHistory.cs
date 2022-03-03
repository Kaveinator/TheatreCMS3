using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace TheatreCMS3.Areas.Rent.Models
{
    public class RentalHistory
    {
        public int RentalHistoryId { get; set; }
        public bool RentalDamaged { get; set; }
        public string DamagedIncurred { get; set; } 
        public string Rental { get; set; }
    }
}