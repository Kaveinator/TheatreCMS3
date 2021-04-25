using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TheatreCMS3.Areas.Rent.Models;

namespace TheatreCMS3.Areas.Rent.ViewModels
{
    public class AllRentals
    {
        public AllRentals(Rental rental)
        {
            RentalId = rental.RentalId;
            RentalName = rental.RentalName;
            RentalCost = rental.RentalCost;
            FlawsAndDamages = rental.FlawsAndDamages;
            if (rental is RentalEquipment equipment)
            {
                ChokingHazard = equipment.ChokingHazard;
                SuffocationHazard = equipment.SuffocationHazard;
                PurchasePrice = equipment.PurchasePrice;
            }
            else if (rental is RentalRoom room)
            {
                RoomNumber = room.RoomNumber;
                SquareFootage = room.SquareFootage;
                MaxOccupancy = room.MaxOccupancy;
            }
        }
         //empty overloaded constructor to edit and create
        public AllRentals() { }

        [Key]
        public int RentalId { get; set; }
        [Required]
        public string RentalName { get; set; }
        [DataType(DataType.Currency)]
        public decimal RentalCost { get; set; }
        public string FlawsAndDamages { get; set; }
        public bool ChokingHazard { get; set; }
        public bool SuffocationHazard { get; set; }
        [DataType(DataType.Currency)]
        public decimal PurchasePrice { get; set; }
        public int RoomNumber { get; set; }
        public int SquareFootage { get; set; }
        public int MaxOccupancy { get; set; }
    }
}