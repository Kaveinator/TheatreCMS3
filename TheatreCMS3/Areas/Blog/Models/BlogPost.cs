using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Blog.Models
{
    public class BlogPost
    {
        [Key]
        public int BlogPostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Posted { get; set; }
        public string Author { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}