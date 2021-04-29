using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

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
    }

    public class RentalManagerAuthorize : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
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
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Rentals/AccessDenied" }));
            }
            
        }
    }
}