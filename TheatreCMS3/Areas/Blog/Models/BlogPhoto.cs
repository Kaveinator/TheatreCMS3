using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace TheatreCMS3.Areas.Blog.Models
{
    public class BlogPhoto
    {
        [Key]
        public int BlogPhotoID { get; set; }
        public string Title { get; set; }
        //public byte[] Photo { get; set; }
    }
}