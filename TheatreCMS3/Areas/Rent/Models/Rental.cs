using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Rent.Models
{
    public class Rental
    {
        public int RentalId { get; set; }
        public string RentalName { get; set; }
        public int RentalCost { get; set; }
        public string FlawsAndDamages { get; set; }
        public byte Photo { get; set; } // this attribute is in the UML diagram for the Rental Area
    }

    public class RentalEquipment : Rental
    {
        public bool ChokingHazard { get; set; }
        public bool SuffocationHazard { get; set; }
        public int PurchasePrice { get; set; }
    }

    public class RentalRoom : Rental
    {
        public int RoomNUmber { get; set; }
        public int SquareFootage { get; set; }
        public int MaxOccupancy { get; set; }
    }
}