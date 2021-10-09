using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Rent.Models
{
    //This history manager will act as an admin for the RentalHistory area
    //and is responsible for keeping track of the history of returned rentals
    public class HistoryManager : ApplicationUser
    {
        //This RestrictedUsers property represents the number of Users that
        //this manager has blocked from renting from the theatre again
        public int RestrictedUsers { get; set; }

        //The RentalReplacementRequests represent the number of Rentals that
        //need to be replaced due to damage.
        public int RentalReplacementRequests { get; set; }

        //Seeding the database
        //creating a method:
        public static void SeedHistoryManager()
        {
            //creating an instance of HistoryManager, saves to DB before page loads
            ApplicationDbContext dbContext = new ApplicationDbContext();

            if (dbContext.HistoryManagers.Count()==0)
            {
                //create a new object of type HistoryManager
                HistoryManager historyManager = new HistoryManager
                {
                    //assign values to properties inherited from ApplicationUser/Identity
                    UserName = "Admin",
                    Email = "Admin@example.com",
                    RestrictedUsers = 1,
                    RentalReplacementRequests = 1,
                };
                dbContext.HistoryManagers.Add(historyManager);
                dbContext.SaveChanges();
            }
        }
    }
}