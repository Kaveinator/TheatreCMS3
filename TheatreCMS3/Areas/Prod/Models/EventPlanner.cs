using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TheatreCMS3.Models;
using TheatreCMS3.Areas.Prod.Models;

namespace TheatreCMS3.Areas.Prod.Models
{
    public class EventPlanner : ApplicationUser
    {
        public DateTime PlannerStartDate { get; set; }

        public static void Seed(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var roleUserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            if (!roleManager.RoleExists("EventPlanner"))
            {
                var addRole = new IdentityRole();
                addRole.Name = "EventPlanner";
                roleManager.Create(addRole);
                var eventPlanner = new EventPlanner
                {
                    UserName = "TheEventPlanner"
                };
                string cleverPassword = "ThisiSthEmosTclevErpasswOrd";
                var EventPlanner = roleUserManager.Create(eventPlanner, cleverPassword);
                if (EventPlanner.Succeeded)
                {
                    roleUserManager.AddToRole(eventPlanner.Id, "TheEventPlanner");
                }
            }
        }
    }
}