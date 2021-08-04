using System.IO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web;

namespace TheatreCMS3.Models
{
    public class SiteSettings : ApplicationDbContext
    {
        public int Copyright { get; set; }

        public static void ReadSiteSettings()
        {
            string filename = HttpContext.Current.Server.MapPath("SiteSettings.json");
            SiteSettings siteSettings1 = JsonConvert.DeserializeObject<SiteSettings>(File.ReadAllText(filename));
        }
        
    }
}
