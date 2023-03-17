using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Collections.Generic;
using System.Web;
using TheatreCMS3.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Mvc;
using TheatreCMS3.Areas.Blog.Models;

namespace TheatreCMS3.Areas.Blog.Models
{


    public class HeadAuthor : ApplicationUser
    {
        public int ViewsPerMonth { get; set; }
        public int AuthorsHired { get; set; }
        public int AuthorsLetGo { get; set; }

        public static void Seed(ApplicationDbContext context)
        {
            var RoleUserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // Create HeadAuthor Role
            var modRole = new IdentityRole();
            modRole.Name = "HeadAuthor";
            RoleManager.Create(modRole);

            // Creating HeadAuthor
            var headAuth = new HeadAuthor
            {
                UserName = "Broman",
                Email = "broman@hmail.com",
                ViewsPerMonth = 1,
                AuthorsHired = 2,
                AuthorsLetGo = 3
            };

            string password = "password123";

            //Creating user so it can have role added
            var HeadA = RoleUserManager.Create(headAuth, password);

            // Checks if creating user succeeded
            if (HeadA.Succeeded)
            {
                // If yes, adds user to role
                RoleUserManager.AddToRole(headAuth.Id, "HeadAuthor";)
            }

        }
    }

    public class HeadAuthorAuthorize : AuthorizeAttribute
    {

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            if (filterContext.Result is HttpUnauthorizedResult)
            {

                filterContext.Result = new RedirectResult("~/Blog/BlogAuthors/AccessDenied");
            }

        }
    }

}

