using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        //Relationship to Requests
        [ForeignKey("RentalRequest")]
        public int? RentalRequestID { get; set; }
        public virtual RentalRequest RentalRequest { get; set; }

        //Seeds Database
        public static void Seed(ApplicationDbContext db)
        {
            db.Rentals.AddOrUpdate(x => x.RentalName, //match on rentalname because id will be created newly each time
                new Rental() { RentalName = "Truck", RentalCost = 50, FlawsAndDamages = "Dented bumper" },
                new Rental() { RentalName = "Van", RentalCost = 50, FlawsAndDamages = "Scratch on side" },
                new Rental() { RentalName = "Wigs", RentalCost = 5, FlawsAndDamages = "None" },
                new Rental() { RentalName = "Risers", RentalCost = 30, FlawsAndDamages = "Missing back bumpers" }
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