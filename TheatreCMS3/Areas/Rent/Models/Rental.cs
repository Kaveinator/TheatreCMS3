using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Rent.Models
{
    public class Rental
    {
        [Key]
        public int RentalId { get; set; }
        [Required]
        public string RentalName { get; set; }
        [DataType(DataType.Currency)]
        public decimal RentalCost { get; set; }
        public string FlawsAndDamages { get; set; }

        public static void Seed(ApplicationDbContext db)
        {

            db.Rentals.AddOrUpdate(x => x.RentalId,
                new Rental() { RentalId = 1, RentalName = "Truck", RentalCost = 50, FlawsAndDamages = "Dented bumper" },
                new Rental() { RentalId = 2, RentalName = "Van", RentalCost = 50, FlawsAndDamages = "Scratch on side" },
                new Rental() { RentalId = 3, RentalName = "Wigs", RentalCost = 5, FlawsAndDamages = "None" },
                new Rental() { RentalId = 4, RentalName = "Risers", RentalCost = 30, FlawsAndDamages = "Missing back bumpers" }
                );
        }
    }

    // authorization class for RentalManager role. 
    public class RentalManagerAuthorize : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)//checks for rental manager role
        {
            if (httpContext.User.Identity.IsAuthenticated)
            {
                if (httpContext.User.IsInRole("RentalManager")) 
                {
                    return true;
                }
            }
            return false;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext) //handles redirect to access denied page
        {
            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Rentals/AccessDenied" }));
        }
    }
}