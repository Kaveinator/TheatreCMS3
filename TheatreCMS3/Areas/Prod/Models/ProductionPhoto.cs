﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Prod.Models
{
    public class ProductionPhoto
    {
        [Key]
        public int ProPhotoID { get; set; }
        public Byte[] PhotoFile { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}