using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Prod.Models
{
    public class EventPlanner : ApplicationUser
    {
        public DateTime PlannerStartDate { get; set; }

        public static void SeedEventPlanner(ApplicationDbContext context)
        {
            var userManager = new UserManager<EventPlanner>(new UserStore<EventPlanner>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // Create "EventPlanner" role if it doesn't exist
            if (!roleManager.RoleExists("EventPlanner"))
            {
                var role = new IdentityRole("EventPlanner");
                roleManager.Create(role);
            }

            // Create a new EventPlanner user
            var eventPlanner = new EventPlanner
            {
                UserName = "user",
                Email = "user@theatre.com",    
                PlannerStartDate = DateTime.Now
            };

            // EventPlanner user with a password
            var roleUserManager = userManager.Create(eventPlanner, "Password");
            if (roleUserManager.Succeeded)
            {
                // Assign role to the user
                userManager.AddToRole(eventPlanner.Id, "EventPlanner");
            }
                   

        }
    }
}