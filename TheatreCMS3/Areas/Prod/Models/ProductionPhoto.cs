using System;
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
        //public Byte[] PhotoFile { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
    }
}