using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheatreCMS3.Areas.Rent.Models
{
    public class RentalHistoryAuthorization : AuthorizeAttribute
    {
        public string ViewName = "~/Rent/RentalHistories/AccessDenied";

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult(ViewName);
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (AuthorizeCore(filterContext.HttpContext))
            {
                base.OnAuthorization(filterContext);
            }
            else
            {
                HandleUnauthorizedRequest(filterContext);
            }
        }

    }
}