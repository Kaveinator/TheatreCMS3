using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Rent.Models
{
    public class RentalHistory
    {
        [Key]
        public int ID { get; set; }
        [DisplayAttribute(Name = "Damaged?")]
        public bool RentalDamaged { get; set; }
        [DisplayAttribute(Name = "Notes")]
        public string DamagesIncurred { get; set; }
        public string Rental { get; set; }
    }
}