using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Blog.Models
{
    public class BlogAuthor
    {
        public int BlogAuthorId { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public DateTime JoinedDate { get; set; }
        public DateTime LeftDate { get; set; }
    }
}