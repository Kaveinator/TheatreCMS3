﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Blog.Models
{
    public class BlogPost
    {
        public int BlogPostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime BlogDate { get; set; }
        public string Author { get; set; }

        public BlogPost()
        {
            BlogDate = DateTime.Now;
        }
    }

    
}