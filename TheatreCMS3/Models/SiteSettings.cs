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
        public string PhoneNumber { get; set; }
        public AddressDetails Address { get; set; }

        public class AddressDetails
        {
            public string Street { get; set; }
            public string CityStateZip { get; set; }
        }

        public static SiteSettings ReadSiteSettings()
        {
            string filename = HttpContext.Current.Server.MapPath("SiteSettings.json");
            SiteSettings siteSettings1 = JsonConvert.DeserializeObject<SiteSettings>(File.ReadAllText(filename));
            return siteSettings1;
        }
        
    }
}
