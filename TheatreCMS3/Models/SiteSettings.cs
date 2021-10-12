using Newtonsoft.Json;
using System;
using System.IO;


namespace TheatreCMS3.Models
{

    public class SiteSettings
    {
        public int Copyright { get; set; }
        public string PhoneNumber { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        public static SiteSettings ReadSiteSettings()
        {
            var path = Path.Combine(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "SiteSettings.json"));
            string readJson = File.ReadAllText(path);
            SiteSettings siteSettings = JsonConvert.DeserializeObject<SiteSettings>(readJson);
            return siteSettings;
        }
    }
}