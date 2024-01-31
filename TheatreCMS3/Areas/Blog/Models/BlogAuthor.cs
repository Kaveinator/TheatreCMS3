using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Blog.Models
{
    public class BlogAuthor
    {
        //primary Key
        public int BlogAuthorId { get; set; }
        //properties
        public string Name { get; set; }
        public string Bio { get; set; }
        public DateTime Joined { get; set; }
        public DateTime? Left { get; set; } //nullable DateTime for when the author leaves
    }
}