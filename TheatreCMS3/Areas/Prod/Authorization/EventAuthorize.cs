using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheatreCMS3.Areas.Prod.Authorization;

namespace TheatreCMS3.Areas.Prod.Authorization
{
    public class EventAuthorize : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (!httpContext.User.IsInRole("EventPlanner"))
            {
                return false;
            }
            return true;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("~/Prod/CalendarEvents/AccessDenied");
        }
    }
}