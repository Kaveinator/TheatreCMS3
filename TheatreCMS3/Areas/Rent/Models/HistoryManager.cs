using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Rent.Models
{
    public class HistoryManager : ApplicationUser
    {
        public int RestrictedUsers { get; set; }
        public int RentalReplacementRequests { get; set; }


        public static void HistoryManagerSeed(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("HistoryManager"))
            {
                var role = new IdentityRole();
                role.Name = "HistoryManager";
                roleManager.Create(role);

                
                var historyManager = new HistoryManager
                {
                    UserName = "historyManager",
                    Email = "historyManager@theatrevertigo.com",
                    RestrictedUsers = 47,
                    RentalReplacementRequests = 123
                };
                string historyManagerPass = "vertigoHistoryManager";

                var checkHistoryMan = userManager.Create(historyManager, historyManagerPass);
                
                if (checkHistoryMan.Succeeded)
                {
                    userManager.AddToRole(historyManager.Id, "HistoryManager");
                }

            }
        }
    }
}