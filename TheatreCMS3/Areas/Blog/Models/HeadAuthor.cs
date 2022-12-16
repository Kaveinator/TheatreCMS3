using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheatreCMS3.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace TheatreCMS3.Areas.Blog.Models
{
    public class HeadAuthor : ApplicationUser
    {

        public int ViewsPerMonth { get; set; }
        public int AuthorsHired { get; set; }
        public int AuthorsLetGo { get; set; }


        public static void Seed(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var roleUserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("HeadAuthor"))
            {

                var modRole = new IdentityRole();
                modRole.Name = "HeadAuthor";
                roleManager.Create(modRole);

                var headauthor = new HeadAuthor { 
                    
                    UserName = "TheHeadAuthor", Email = "headauthor@theatrecms.dev",
                    ViewsPerMonth = 29, AuthorsHired = 3, AuthorsLetGo = 0 };

                string password = "123";

                var HeadA = roleUserManager.Create(headauthor, password);

                if (HeadA.Succeeded)
                {
                    roleUserManager.AddToRole(headauthor.Id, "HeadAuthor");
                }

            }

        }
    }
}
