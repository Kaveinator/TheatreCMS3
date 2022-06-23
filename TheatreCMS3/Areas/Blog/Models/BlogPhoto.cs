using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Blog.Models
{
    public class BlogPhoto
    {
        public int BlogPhotoId { get; set; }

        [DisplayName("Title:")]
        public string Title { get; set; }

        [DisplayName("Photo:")]
        public byte[] Photo { get; set; }
    }
}