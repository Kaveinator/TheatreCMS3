using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Blog.Models
{
    public class Postmaster : ApplicationUser
    {
        public static int PublishedBlogPosts;
        public static int RejectedBlogPosts;
        public static int PendingPosts;


    }
}