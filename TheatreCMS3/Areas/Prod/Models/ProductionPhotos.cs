using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Prod.Models
{
    public class ProductionPhotos
    {
        [Key]
        public int ProPhotoId;
        //public Byte[] PhotoFile;
        public string Title;
        public string Description;
    }
}