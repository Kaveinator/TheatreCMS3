using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheatreCMS3.Areas.Rent.Models
{
    public class HistoryManagerAuthorize : AuthorizeAttribute
    {
        public string View { get; set; }

        public HistoryManagerAuthorize()
        {
            View = "AccessDenied";
        }
        public override void OnAuthorization(AuthorizationContext filterContext)

        {
            base.OnAuthorization(filterContext);
            IsUserAuthorized(filterContext);
        }

        private void IsUserAuthorized(AuthorizationContext filterContext)
        {
            // If the Result returns null then the user is Authorized 
            if (filterContext.Result == null)
                return;

            //If the user is Un-Authorized then Navigate to Auth Failed View 
            //if (filterContext.HttpContext.User.Identity.IsAuthenticated)

            //{
            //    var vr = new ViewResult();
            //    vr.ViewName = View;

            //    ViewDataDictionary dict = new ViewDataDictionary();
            //    dict.Add("Message", "Sorry you are not Authorized to Perform this Action");
            //    vr.ViewData = dict;

            //    var result = vr;
            //    filterContext.Result = vr;
            //}

            if (filterContext.HttpContext.User != null && filterContext.HttpContext.User.Identity.IsAuthenticated && filterContext.HttpContext.Response.StatusCode == 401)
            {
                filterContext.HttpContext.Response.RedirectToRoute("AccessDenied");
            }

        }

        //public HistoryManagerAuthorize()
        //{
        //    View = "AccessDenied";
        //    Master = String.Empty;
        //}

        //public String View { get; set; }
        //public String Master { get; set; }

        //public override void OnAuthorization(AuthorizationContext filterContext)
        //{
        //    base.OnAuthorization(filterContext);
        //    CheckIfUserIsAuthenticated(filterContext);
        //}

        //private void CheckIfUserIsAuthenticated(AuthorizationContext filterContext)
        //{
        //    // If Result is null, we're OK: the user is authenticated and authorized. 
        //    if (filterContext.Result == null)
        //        return;

        //    // If here, you're getting an HTTP 401 status code. In particular,
        //    // filterContext.Result is of HttpUnauthorizedResult type. Check Ajax here. 
        //    if (filterContext.HttpContext.User.Identity.IsAuthenticated)
        //    {
        //        if (String.IsNullOrEmpty(View))
        //            return;
        //        var result = new ViewResult { ViewName = View, MasterName = Master };
        //        filterContext.Result = result;
        //    }
        //}



    }
}