using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Blog.Models
{
    public class BlogDbContext : DbContext
    {
        public DbSet<BlogAuthor> BlogAuthors { get; set; }
    }
}