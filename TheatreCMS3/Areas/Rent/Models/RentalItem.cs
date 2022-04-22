using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Rent.Models
{
    public class RentalItem
    {
        public int RentalItemId { get; set; }
        public string Item { get; set; }
        public string ItemDescription { get; set; }
        DateTime PickupDate { get; set; }
        DateTime? ReturnDate { get; set; }
        //Byte[] ItemPhoto { get; set; }

        public RentalItem()
        {
            RentalItemId = -1;
            Item = "None";
            ItemDescription = "None";
            PickupDate = DateTime.Now;
            ReturnDate = DateTime.Now;

        }

        public RentalItem(int rentalItemId, string item, string itemDescription, DateTime pickupDate, DateTime? returnDate)
        {
            RentalItemId = rentalItemId;
            Item = item;
            ItemDescription = itemDescription;
            PickupDate = pickupDate;
            ReturnDate = returnDate;
        }
    }
}