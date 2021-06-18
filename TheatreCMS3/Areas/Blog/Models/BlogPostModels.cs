using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace TheatreCMS3.Areas.Blog.Models
{

    public class BlogPostModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Posted { get; set; }
        public string Author { get; set; }
    }
