using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheatreCMS3.Areas.Rent.Models;

namespace TheatreCMS3.Areas.Rent.ViewModels
{
    public class AllRentals
    {
        public Rental Rental { get; set; }
        public RentalEquipment RentalEquipment { get; set; }
        public RentalRoom RentalRoom { get; set; }
    }
}