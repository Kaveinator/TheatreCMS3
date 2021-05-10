using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Blog.Models
{
    public class BlogPhoto
    {
        private byte photo;

        [Key]
        public int PK { get; set; }
        public int BlogPhotoId { get; set; }
        public string Title { get; set; }
        public Byte Photo { get => photo; set => photo = value; }
    }
}