using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace TheatreCMS3.Areas.Blog.Models
{
    public class BlogAuthor
    {
        [Key]
        public int BlogAuthorId { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public DateTime Joined { get; set; }
        public DateTime Left { get; set; }
    }
}