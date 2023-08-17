using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Rent.Models
{
    public class RequestManager : ApplicationUser
    {
        public int RejectedRequests { get; set; }
        public int AcceptedRequests { get; set; }

        public static void SeedRequestManager(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var roleUserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("RentalManager"))
            {
                var requestRole = new IdentityRole();
                requestRole.Name = "RentalManager";
                roleManager.Create(requestRole);

                var rentalManager = new RequestManager
                {
                    UserName = "RentalManager",
                    Email = "RentalManager@gmail.com",
                };

                string password = "Password123!";
                var requestManagerResult = roleUserManager.Create(rentalManager, password);

                if (requestManagerResult.Succeeded)
                {
                    roleUserManager.AddToRole(rentalManager.Id, "RentalManager");
                }
            }
        }
    }
}