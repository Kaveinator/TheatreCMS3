using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheatreCMS3.Areas.Blog.Models
{
    public class BlogPhoto
    {
        public int BlogPhotoId { get; set; }
        public string Title { get; set; }
        public byte[] Photo { get; set; }
    }
}