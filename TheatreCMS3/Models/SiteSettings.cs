using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Models
{
    public class SiteSettings : ApplicationDbContext
    {
        // Create an integer property for this class
        public int ReadSiteSettings { get; set; } 
    }
}