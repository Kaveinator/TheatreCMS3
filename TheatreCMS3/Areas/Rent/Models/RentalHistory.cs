﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Rent.Models
{
    public class RentalHistory
    {
        public int RentalHistoryId { get; set; }
        public bool RentalDamage { get; set; }
        public string DamageIncurred { get; set; }
        public string Rental { get; set; }
    }
}