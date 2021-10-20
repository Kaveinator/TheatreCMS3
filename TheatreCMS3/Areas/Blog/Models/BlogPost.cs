using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Blog.Models
{
    public class BlogPost
    {
        public int BlogPostID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Posted { get; set; }
        //public string Author { get; set; }  // Commented out b/c of defined relationship below:

        // Creating (fully defined) relationship between BlogAuthor and BlogPost models
        public virtual int BlogAuthorID { get; set; }
        public virtual BlogAuthor BlogAuthor { get; set; }
    }
}