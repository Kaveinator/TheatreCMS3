﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Prod.Models
{
    public class ProductionPhoto
    {
        [Key]
        public int ProductionPhotodId { get; set; }
        public byte[] Photo { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PathPhoto { get; set; }
    }
}