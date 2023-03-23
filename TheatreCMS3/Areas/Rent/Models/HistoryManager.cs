using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Rent.Models
{
    public class HistoryManager : ApplicationUser
    {
        public int RestrictedUsers { get; set; }
        public int RentalReplacementRequests { get; set; }

        public static void Seed(ApplicationDbContext Mycontext)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(Mycontext));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(Mycontext));

            // Creating a HistoryManager role
            var role = new IdentityRole();
            role.Name = "HistoryManager";
            roleManager.Create(role);

            // Instantiating an object of History Manager / Creating an User
            var user = new HistoryManager
            {
                UserName = "Name",
                Email = "name@mail.com",
                RestrictedUsers = 2,
                RentalReplacementRequests = 1
            };

            var userPassword = "password";

            var manager = userManager.Create(user, userPassword);

            if(manager.Succeeded) { userManager.AddToRole(user.Id, "HistoryManager"); }
        }
    }
}