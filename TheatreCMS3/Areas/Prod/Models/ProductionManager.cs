using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheatreCMS3.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace TheatreCMS3.Areas.Prod.Models
{
    public class ProductionManager : ApplicationUser
    {
        public string Title { get; set; }
        public DateTime ManagerStartDate { get; set; }

        public static void Seed(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("ProductionManager"))
            {
                // Create ProductionManager Role    
                var role = new IdentityRole();
                role.Name = "ProductionManager";
                roleManager.Create(role);

                //Create a user with ProductionManager as Role
                int newdate = 02022022;
                DateTime datetostring = DateTime.Parse(newdate.ToString());
                var user = new ProductionManager
                {
                    UserName = "ProductionManager1",
                    Email = "admin@theatre.com",
                    Title = "Costume Designer",
                    ManagerStartDate = datetostring

                };

                string userPWD = "TheatreCM";

                var ProdUser = UserManager.Create(user, userPWD);

                //Add default User to Role ProductionManager    
                if (ProdUser.Succeeded)
                {
                    UserManager.AddToRole(user.Id, "ProductionManager");
                }
            }

        }
    }
}