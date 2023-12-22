using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;


namespace TheatreCMS3.Areas.Prod.Models
{
    public class EventAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            // Check if the user has EventPlanner role
            return httpContext.User.IsInRole("EventPlanner");
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            {
                // Redirect to the AccessDenied page 
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        { "area", "Prod" },
                        { "controller", "CalendarEvents" },
                        { "action", "AccessDenied" }
                    });
            }
        }
    }
}