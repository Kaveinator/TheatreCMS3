using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TheatreCMS3.Areas.Rent.Controllers;
using System.Web.Security;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Rent.Models
{
    public class HistoryManager : ApplicationUser
    {
        public int RestrictedUsers { get; set; }
        public int RentalReplacementRequests { get; set; }

        public static void Seed()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            if (!roleManager.RoleExists("HistoryManager"))
            {
                var role = new IdentityRole
                {
                    Name = "HistoryManager"
                };
                roleManager.Create(role);

                HistoryManager HistoryManagerSeed = new HistoryManager
                {
                    UserName = "HistoryManager",
                    Email = "HistoryManager@theatre.com",
                    RestrictedUsers = 0,
                    RentalReplacementRequests = 0
                };
                string HistoryManagerSeedPass = "Password23!";
                var checkPMCreate = userManager.Create(HistoryManagerSeed, HistoryManagerSeedPass);

                if(checkPMCreate.Succeeded)
                {
                    userManager.AddToRole(HistoryManagerSeed.Id, "HistoryManager");
                }

                db.Users.Add(HistoryManagerSeed);
            }
        }

    }
}
    //Redirects Anyone Who Is Not Authorized To Be In Rental Hisotries To Access Denied Page.  
    public class HistoryManagerAuthorize : AuthorizeAttribute
    {
    public override void OnAuthorization(AuthorizationContext filterContext)
    {
        base.OnAuthorization(filterContext);

        if (filterContext.Result is HttpUnauthorizedResult)
        {
            filterContext.Result = new RedirectResult("~/Rent/RentalHistories/AccessDenied");
        }
    }
}