using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Prod.Models
{
    public class CastDirector : ApplicationUser
    {
        public int HiredCastMembers { get; set; }
        public int FiredCastMembers { get; set; }

        public static void CastDirectorSeed(ApplicationDbContext context)
        {
           
            var CastDirectorManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            
            
            var castDirectors = new CastDirector
            {
                HiredCastMembers = 4, FiredCastMembers = 2,
                Email = "castingDirectors@gmail.com",
                UserName = "CDirector", 
            };

            IdentityRole identityRole = new IdentityRole("CastDirector");
            var RoleConnection = CastDirectorManager.AddToRole(userId: "210-0ac477b8dfe0", role: "CastDirector");

            RoleManager.Create(role: identityRole);
            CastDirectorManager.Create(user: castDirectors, password: "123-ABC");
            context.SaveChanges();
        }

    }  
}