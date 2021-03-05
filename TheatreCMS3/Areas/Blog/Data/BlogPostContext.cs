using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TheatreCMS3.Areas.Blog.Models;

namespace TheatreCMS3.Areas.Blog.Data
{
    public class BlogPostContext : DbContext
    {
        public DbSet<BlogPost> BlogPosts {get; set;}
    }
}