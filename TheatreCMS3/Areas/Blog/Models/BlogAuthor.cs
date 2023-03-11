using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheatreCMS3.Areas.Blog.Models
{
    public static class DatePickerHelper
    {
        public static HtmlString DatePicker(this HtmlHelper helper, string id)
        {
            var input = new TagBuilder("input");
                input.Attributes.Add("type", "date");
                return new MvcHtmlString(input.ToString());
            MvcHtmlString html = new MvcHtmlString(
                input.ToString(TagRenderMode.SelfClosing));
        }
    
    }

    public class BlogAuthor
    {
        [Key]
        public int BlogAuthorId { get; set; }

        public string Name { get; set; }
        public string Bio { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public System.DateTime Joined { get; set; }
        [DataType(DataType.DateTime)]

        public DateTime Left { get; set; }
    }
}