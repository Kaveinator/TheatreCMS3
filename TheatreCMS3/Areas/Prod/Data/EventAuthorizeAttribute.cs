using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheatreCMS3.Areas.Prod.Models;

namespace TheatreCMS3.Areas.Prod.Data {
    public class EventAuthorizeAttribute : AuthorizeAttribute {
        public EventAuthorizeAttribute() {
            Roles = nameof(EventPlanner);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext) {
            filterContext.Result = new ViewResult {
                ViewName = "AccessDenied",
            };
        }
    }
}