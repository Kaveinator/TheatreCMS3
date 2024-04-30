using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using TheatreCMS3.Models;
using System.Data.Entity.Migrations;

namespace TheatreCMS3.Areas.Prod.Models {
    public class EventPlanner : ApplicationUser {
        const string RoleName = nameof(EventPlanner);
        public DateTime PlannerStartDate { get; set; }

        /// <summary>Seeded in <see cref="TheatreCMS3.Migrations.Configuration"/></summary>
        /// <param name="context"></param>
        public static void Seed(ApplicationDbContext context) {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.RoleExists(RoleName)) // Create role if not exists
                roleManager.Create(new IdentityRole(RoleName));

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            // Create Event Planner user
            var eventPlanner = new EventPlanner() {
                UserName = "Event Planner",
                Email = "user@example.com",
                PlannerStartDate = DateTime.Now
            };
            // Add the event planner
            userManager.Create(eventPlanner, "NotAGoodPassword");
            userManager.AddToRole(eventPlanner.Id, RoleName);
        }
    }
}