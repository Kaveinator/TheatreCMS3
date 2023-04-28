using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Blog.Models
{
    public class HeadAuthor : ApplicationUser
    {
        public int ViewsPerMonth { get; set; }
        public int AuthorsHired { get; set; }
        public int AuthorsLetGo { get; set; }

        public static void Seed()
        {            
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            if (!roleManager.RoleExists("Head Author"))
            {
                var role = new IdentityRole { Name = "Head Author" };
                roleManager.Create(role);
            }

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            var headauthor = new HeadAuthor {
                ViewsPerMonth = 0,
                AuthorsHired = 0,
                AuthorsLetGo = 0,
                Email = "headauthor@admin.com",
                EmailConfirmed = true,
                PhoneNumber = "5131234567",
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                UserName = "headauthor",
            };

            userManager.Create(headauthor, "headauthorpassword");
            userManager.AddToRole(headauthor.Id, "Head Author");
        }
    }
    
}

