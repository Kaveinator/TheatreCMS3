using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Rent.Models
{
    public class RentalRoom : Rental //inherit Rental properties
    {
        public int RoomNumber { get; set; }
        public int SquareFootage { get; set; }
        public int MaxOccupancy { get; set; }

        public static void Seed(ApplicationDbContext db)
        {
            db.Rentals.AddOrUpdate(x => x.RentalName,
                new RentalRoom() { RentalName = "Choir Room", RentalCost = (decimal)35.50, FlawsAndDamages = "Wallpaper coming off", RoomNumber = 5, SquareFootage = 1000, MaxOccupancy = 50 },
                new RentalRoom() { RentalName = "Stage", RentalCost = 100, FlawsAndDamages = "Ripped Curtains", RoomNumber = 1, SquareFootage = 5000, MaxOccupancy = 400 }
                );
        }
    }
}