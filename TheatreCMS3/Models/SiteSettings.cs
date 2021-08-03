using System.IO;
using System;
using Newtonsoft.Json;

namespace TheatreCMS3.Models
{
    public class SiteSettings : ApplicationDbContext
    {
        public int Copyright { get; set; }
    }

        public class ReadSiteSettings
    {
            public static void Main()
            {
                string fileName = "SiteSettings.json";
                string jsonString = File.ReadAllText(fileName);
                SiteSettings siteSettings = JsonConvert.DeserializeObject<SiteSettings>(jsonString);
            }
        }
}