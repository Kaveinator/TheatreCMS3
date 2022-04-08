using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace TheatreCMS3.Areas.Blog.Models
{
    public class BlogPhoto
    {
        [Key]
        public int BlogPhotoId { get; set; }

        public string PhotoName { get; set; }

        public byte[] Photo { get; set; }


    }

}