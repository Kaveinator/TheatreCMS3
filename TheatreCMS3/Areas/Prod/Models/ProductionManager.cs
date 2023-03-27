using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Prod.Models
{
    public class ProductionManager : ApplicationUser
    {
        public ProductionManager() : base() { }
        public string Title { get; set; }
        public DateTime ManagerStartDate { get; set; }
        public static void SeedProductionManager(ApplicationDbContext ProductionManagerContext)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(ProductionManagerContext));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(ProductionManagerContext));

            // Creating a ProductionManager role
            var role = new IdentityRole();
            role.Name = "ProductionManager";
            roleManager.Create(role);

            // Instantiating an object of ProductionManager / Seeding object
            var productionManager = new ProductionManager
            {
                UserName = "username",
                Email = "email@email.com",
                Title = "ProductionManagerTestSeed",
                ManagerStartDate = DateTime.Now
            };

            var productionManagerPassword = "password";
            var manager = userManager.Create(productionManager, productionManagerPassword);
            if (manager.Succeeded)
            {
                userManager.AddToRole(productionManager.Id, "ProductionManager");
            }
        }
    }
}