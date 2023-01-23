using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.IO;

namespace TheatreCMS3.Areas.Prod.Models
{
    public class ProductionPhoto
    {
        public int ProductionPhotoId {get; set;}
        public Byte[] PhotoFile {get; set;}
        public string Title { get; set; }
        public string Description { get; set; }


    }
}