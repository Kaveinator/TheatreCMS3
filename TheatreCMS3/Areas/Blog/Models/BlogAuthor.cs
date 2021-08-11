using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Blog.Models
{
    public class BlogAuthor
    {
        public int BlogAuthorId { get; set; }
        [DisplayName("Author:")]
        public string Name { get; set; }
        [DisplayName("Bio:")]
        public string Bio { get; set; }
        [DisplayName("Date Joined:")]
        public DateTime Joined { get; set; }
        [DisplayName("Date Left:")]
        public DateTime Left { get; set; }
    }
}