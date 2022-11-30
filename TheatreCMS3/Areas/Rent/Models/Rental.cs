using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheatreCMS3.Areas.Rent.Models
{
    public class Rental
    {
        [Display(Name = "ID")]
        public int RentalId { get; set; }
        [Display(Name = "Name")]
        public string RentalName { get; set; }
        [Display(Name = "Cost per hour")]
        public int RentalCost { get; set; }
        [Display(Name = "Current flaws or damages")]
        public string FlawsAndDamages { get; set; }

        public ERentalType RentalOptions { get; set; }
    }

    public class RentalEquipment : Rental
    {
        [Display(Name = "Choking hazard")]
        public bool ChokingHazard { get; set; }
        [Display(Name = "Sufocation hazard")]
        public bool SuffocationHazard { get; set; }
        [Display(Name = "Purchase price")]
        public int? PurchasePrice { get; set; }
    }

    public class RentalRoom : Rental
    {
        [Display(Name = "Room number")]
        public int? RoomNumber { get; set; }
        [Display(Name = "Square footage of room")]
        public int? SquareFootage { get; set; }
        [Display(Name = "Maximum occupancy of room")]
        public int? MaxOccupancy { get; set; }
    }

    public enum ERentalType
    {
        Rental,
        //[Display(Name = "Rental Equipment")]
        RentalEquipment,
        //[Display(Name = "Rental Room")]
        RentalRoom
    }

}