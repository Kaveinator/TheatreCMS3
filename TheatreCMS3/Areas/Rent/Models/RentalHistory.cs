using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Rent.Models
{
    public class RentalHistory
    {
        public int RentalHistoryId { get; set; }
        [Display(Name = "Rental Damaged")]
        public bool RentalDamaged { get; set; }
        [Display(Name = "Damages Incurred")]
        public string DamagesIncurred { get; set; }
        public string Rental { get; set; }
    }
}