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
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // Create HeadAuthor Role
            string roleName = "HeadAuthor";
            IdentityResult roleResult;
            IdentityResult userResult;

            if (!RoleManager.RoleExists(roleName))
            {
                roleResult = RoleManager.Create(new IdentityRole(roleName));
            }

            var author = new List<HeadAuthor>
            {
                new HeadAuthor { ViewsPerMonth = 1, AuthorsHired = 2, AuthorsLetGo = 3 }
            };
            


            var authorUser = new HeadAuthor{ UserName = "Broman", Email = "broman@hmail.com", ViewsPerMonth = 1, AuthorsHired = 2, AuthorsLetGo = 3 };
            string password = "password123";
            userResult = UserManager.Create(authorUser, password);
        }
    }



}

