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
        public const string RoleName = nameof(EventPlanner);
        public const string SeededUsername = "Event Planner";
        public const string SeededPassword = "NotAGoodPassword";
        public const string SeededEmail = "user@example.com";

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
                UserName = SeededUsername,
                Email = SeededEmail,
                PlannerStartDate = DateTime.Now
            };
            // Add the event planner
            userManager.Create(eventPlanner, SeededPassword);
            userManager.AddToRole(eventPlanner.Id, RoleName);
        }
    }
}