using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Rent.Models
{
    public class RentalHistory
    {
        // Creating the table columns for Rental History's Table
        public int RentalHistoryID { get; set; }
        public bool RentalDamaged { get; set; }
        public string DamagesIncurred { get; set; }
        public string Rental { get; set; }
    }
}