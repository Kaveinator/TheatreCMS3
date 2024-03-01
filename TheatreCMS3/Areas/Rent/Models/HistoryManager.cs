using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Rent.Models
{
    public class HistoryManager : ApplicationUser
    {
        //creating new table from same db
        public int RestrictedUsers { get; set; }
        public int RentalReplacementRequests { get; set; }

        // Seed method to plant 1 History Manager into the database in a static method
        public static void Seed(ApplicationDbContext context)
        {
            //instantiating UserManager and RoleManager b/c need classes to create a user role called "HistoryManager" in line 31
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            //checking db to see if role of history manager exists, if not create and add one to db
            if (!roleManager.RoleExists("HistoryManager"))
            {
                {
                    //creating a new user role as rentalRole
                    var rentalRole = new IdentityRole();
                    //giving rentalRole the title HistoryManager and assigning to HistoryManager being seeded
                    rentalRole.Name = "HistoryManager";
                    roleManager.Create(rentalRole);
                    var historyManager = new HistoryManager
                    {
                        //given properties to HistoryManager
                        UserName = "HistoryManager",
                        Email = "historymanager@theater.com"
                    };
                    string password = "tHeAtErKiD90!";
                    //creating User Manager as hstryManager
                    var historyUserMgmt = userManager.Create(historyManager, password);
                    if(historyUserMgmt.Succeeded)
                    {
                        userManager.AddToRole(historyManager.Id, "HistoryManager"); //now need to call seed method in configuration.cs to add created data into tables
                    }
                }               
            }
        }
    }
}