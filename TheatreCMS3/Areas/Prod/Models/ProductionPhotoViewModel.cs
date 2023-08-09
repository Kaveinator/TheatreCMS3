using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Prod.Models
{
    public class ProductionPhotoViewModel
    {
        public string ProductionTitle { get; set; }
        public IEnumerable<ProductionPhoto> ProdPhotos { get; set; }
    }
}