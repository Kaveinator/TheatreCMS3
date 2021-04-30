using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Rent.Models
{
    public class RentalEquipment : Rental //inherit parent rental properties
    {
        public bool ChokingHazard { get; set; }
        public bool SuffocationHazard { get; set; }
        [DataType(DataType.Currency)]
        public decimal PurchasePrice { get; set; }

        public static void Seed(ApplicationDbContext db)
        {
            db.Rentals.AddOrUpdate(x => x.RentalName,
                new RentalEquipment() { RentalName = "Sword", RentalCost = 7, FlawsAndDamages = "Handle comes off easily", ChokingHazard = true, SuffocationHazard = false, PurchasePrice = 30 },
                new RentalEquipment() { RentalName = "Camera", RentalCost = 100, FlawsAndDamages = "Missing strap", ChokingHazard = false, SuffocationHazard = false, PurchasePrice = 1000 },
                new RentalEquipment() { RentalName = "Beads", RentalCost = 10, FlawsAndDamages = "None", ChokingHazard = true, SuffocationHazard = false, PurchasePrice = 30 },
                new RentalEquipment() { RentalName = "Bags", RentalCost = 1, FlawsAndDamages = "None", ChokingHazard = false, SuffocationHazard = true, PurchasePrice = 10 },
                new RentalEquipment() { RentalName = "Water Bottles", RentalCost = 50, FlawsAndDamages = "Cracked and don't hold water", ChokingHazard = true, SuffocationHazard = true, PurchasePrice = 5 }
                );
        }
    }


}