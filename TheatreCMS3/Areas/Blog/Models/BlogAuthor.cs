using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Blog.Models
{
    public class BlogAuthor
    {
        public int id { get; set; }
        public string Name { get; set; }
        public DateTime Joined { get; set; }
        public DateTime Left { get; set; }
    }
}