using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheatreCMS3.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TheatreCMS3.Areas.Rent.Models
{
    public class RentalHistoryModel
    {
        public int RentalHistoryId { get; set; }
        public bool RentalDamaged { get; set; }
        public string DamagesIncurred { get; set; }
        public string Rental { get; set; }

    }
}