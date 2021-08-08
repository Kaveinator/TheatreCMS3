using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Prod.Models
{
    public class ProductionManager : ApplicationUser
    {
        public string Title { get; set; }
        public DateTime ManagerStartDate { get; set; }

        public static void Seed(ApplicationDbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var productionManger = new ProductionManager
            {
                Email = "admin@prodmanagers.com",
                Title = "Head of Logistics",
                ManagerStartDate = new DateTime(2020, 01, 01)
            };

            var identityRole = new IdentityRole("ProductionManager");

            roleManager.Create(role: identityRole);
            userManager.Create(user: productionManger, password: "Passw0rd"); //missing password
            context.SaveChanges();

            var user = userManager.FindByEmail(productionManger.Email);

            userManager.AddToRole(userId: user.Id, role: "ProductionManager");
        }
    }
}