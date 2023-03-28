using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheatreCMS3.Areas.Prod.Models
{
    public class ProductionAuthorize : AuthorizeAttribute
    {
        //Setting the authorized role to Production Manager
        public ProductionAuthorize()
        {
            Roles = "ProductionManager";
        }

        //HandleUnauthorizedRequest to redirect to new Access Denied view
        public string PMAccessDenied = "~/Prod/Productions/AccessDenied";
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult(PMAccessDenied);
        }
    }
}