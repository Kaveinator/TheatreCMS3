using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheatreCMS3.Models;

// NEED TO USE IDENTITY/IDENTITY-EF NAMESPACES FOR ROLE/USER MANAGERS
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TheatreCMS3.Areas.Rent.Models
{
    public class RentalManager : ApplicationUser
    {
        public int RestrictedUsers { get; set; }
        public int RentalReplacementRequests { get; set;  }

         

       public static void Seed(ApplicationDbContext db)
        {
            // The RoleManager provides APIs for creating roles in the application
            // Must include 'using Microsoft.AspNet.Identity;' namespace
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var roleUserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            if (!roleManager.RoleExists("RentalManager"))
            {
                // create History Manager role
                var rentalManagerRole = new IdentityRole();
                rentalManagerRole.Name = "RentalManager";
                roleManager.Create(rentalManagerRole);

                // create a new Rental Manager
                var rentManager = new RentalManager()
                {
                    UserName = "RentalManager1",
                    Email = "rentalmanager1@email.com",
                    RestrictedUsers = 2000,
                    RentalReplacementRequests = 13452
                };

                var pw = "password";

                var user = roleUserManager.Create(rentManager, pw);

                if (user.Succeeded)
                {
                    Console.WriteLine("Successfully created Rental Manager role");
                }

            }
        }
    }
}