using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Prod.Models
{
    public class CastDirector : ApplicationUser
    {
        public int HiredCastMembers { get; set; }
        public int FiredCastMembers { get; set; }

        public static void SeedCastDirector(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("CastDirector"))
            {
                var role = new IdentityRole();
                role.Name = "CastDirector";
                roleManager.Create(role);
            }

            var director = new CastDirector
            {
                UserName = "jamesgeorge",
                Email = "jamesgeorge@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "555-555-5555",
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                HiredCastMembers = 20,
                FiredCastMembers = 5
            };

            var chkUser = UserManager.Create(director);

            if (chkUser.Succeeded)
            {
                var result = UserManager.AddToRole(director.Id, "CastDirector");
            }
        }
    }
}
