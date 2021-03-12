using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Rental.Models
{
    public class RentalEquipment : TheaterRental
    {
        public int RentalEquipmentID { get; set; }
        public bool ChokingHazard { get; set; }
        public bool SuffocationHazard { get; set; }
        public int PurchasePrice { get; set; }
    }
}