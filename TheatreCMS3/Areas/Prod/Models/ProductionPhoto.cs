﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Prod.Models
{
    public class ProductionPhoto
    {
        public int ProductionPhotoId { get; set; }
        public byte[] PhotoFile { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}