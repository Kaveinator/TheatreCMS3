using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TheatreCMS3.Helpers
{
    public static class CustomHelpers
    {
        public static IHtmlString ImageActionLink(this HtmlHelper htmlHelper,//this is a custom helper that makes an image into a clickable link
        string linkText, string action, string controller, object routeValues,
        object htmlAttributes, string imageSrc)
        {
            var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            var img = new TagBuilder("img");
            img.Attributes.Add("src", VirtualPathUtility.ToAbsolute(imageSrc));
            var anchor = new TagBuilder("a") { InnerHtml = img.ToString(TagRenderMode.SelfClosing) };
            anchor.Attributes["href"] = urlHelper.Action(action, controller, routeValues);
            anchor.MergeAttributes(new RouteValueDictionary(htmlAttributes));


            return MvcHtmlString.Create(anchor.ToString());
        }
    }
}