using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Rent.Models
{
    public class RentalEquipment : Rental
    {
        public bool ChokingHazard { get; set; }
        public bool SuffocationHazard { get; set; }
        [DataType(DataType.Currency)]
        public decimal PurchasePrice { get; set; }
    }
}