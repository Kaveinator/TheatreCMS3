using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Blog.Models
{
    public class BlogAuthor
    {
        public int BlogAuthorId { get; set; }

        //Required field
        public string Name { get; set; }
        public string Bio { get; set; }

        // Required field
        public DateTime Joined { get; set; }
        
        // Optional field
        public DateTime? Left { get; set; }
    }
}