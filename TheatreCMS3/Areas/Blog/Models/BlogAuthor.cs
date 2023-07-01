using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Blog.Models
{
    public class BlogAuthor
    {
        public int BlogAuthorId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Bio { get; set; }
        [Required]
        public DateTime JoinedDate { get; set; }
        public DateTime? LeftDate { get; set; }
    }
}