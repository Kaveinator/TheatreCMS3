using TheatreCMS3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TheatreCMS3.Areas.Rent.Models
{
    public class HistoryManager : ApplicationUser
    {
        public int RestrictedUsers { get; set; } //the number of user that the HistoryManager has blocked from renting again
        public int RentalReplacementRequests { get; set; } //the number of rentals that need to be replaced due to damage

        public virtual RentalHistory RentalHistory { get; set; }

        public static void SeedHistoryManager(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("HistoryManager"))
            {
                var role = new IdentityRole();
                role.Name = "HistoryManager";
                roleManager.Create(role);
            }

            var historymanager = new HistoryManager
            {
                UserName = "historymanagerusername1",
                Email = "historymanagerusername1@historymanager.com",
                PhoneNumber = "5034445555"
            };

            var result = userManager.Create(historymanager, "passwordtest6677");

            if (result.Succeeded)
            {
                result = userManager.AddToRole(historymanager.Id, "HistoryManager");
                string newId = historymanager.Id;
            }

        }
    }
}