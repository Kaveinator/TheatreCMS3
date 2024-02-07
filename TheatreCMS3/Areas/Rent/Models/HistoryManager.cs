using TheatreCMS3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Rent.Models
{
    public class HistoryManager : ApplicationUser
    {
        public int RestrictedUsers { get; set; } //the number of user that the HistoryManager has blocked from renting again
        public int RentalReplacementRequests { get; set; } //the number of rentals that need to be replaced due to damage
    }
}