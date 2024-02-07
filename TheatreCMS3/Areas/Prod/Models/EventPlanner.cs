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
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var roleUserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser> (context));
            if (!roleUserManager.RoleExists("EventPlanner"))
            {
                var modRole = new IdentityRole();
                modRole.Name = "EventPlanner";
                roleManager.Create(modRole);
                var eventPlanner = new EventPlanner
                {
                    UserName = "Joel",
                    Email = "JJZZ1122@gmail.com",
                };
                string password = "PW123";
                var evtPlanner = roleUserManager.Create(eventPlanner, password);
                if (evtPlanner.Succeeded)
                {
                    roleUserManager.AddToRole(eventPlanner.Id, "EventPlanner");
                }
            }            
        }
    }

}