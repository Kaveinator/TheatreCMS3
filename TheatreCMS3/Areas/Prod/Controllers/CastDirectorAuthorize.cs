using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TheatreCMS3.Areas.Prod.Models
{
    public class CastDirectorAuthorize : AuthorizeAttribute
    {
        // Called when access is denied
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
            new RouteValueDictionary(new { controller = "CastMembers", action = "AccessDenied" }));
        }
    }
}