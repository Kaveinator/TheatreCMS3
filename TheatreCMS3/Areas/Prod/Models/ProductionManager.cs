using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Prod.Models
{
    public class ProductionManager : ApplicationUser
    {
        public string Title { get; set; }
        public DateTime ManagerStartDate { get; set; }

        public static void Seed()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var identityRole = new IdentityRole() { Name = "ProductionManager" };
            roleManager.Create(identityRole);

            var productionManger = new ProductionManager
            {
                UserName = "ProdMaster",
                Email = "admin@prodmanagers.com",
                Title = "Head of Logistics",
                ManagerStartDate = new DateTime(2020, 01, 01)
            };

            var check = userManager.Create(productionManger, "password");

            if (check.Succeeded)
                userManager.AddToRole(productionManger.Id, "ProductionManager");
        }
    }
}