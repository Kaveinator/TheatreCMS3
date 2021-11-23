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
        public bool Damaged { get; set; }
        public string Notes { get; set; }
        public string Rental { get; set; }
    }
}