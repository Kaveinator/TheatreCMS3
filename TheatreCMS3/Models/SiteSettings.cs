using Newtonsoft.Json;
using System;
using System.IO;


namespace TheatreCMS3.Models
{

    public class SiteSettings
    {
        public int Copyright { get; set; }

        public static void ReadSiteSettings()
        {
            var path = Path.Combine(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "SiteSettings.json"));
            string readJson = File.ReadAllText(path);
            SiteSettings siteSettings = JsonConvert.DeserializeObject<SiteSettings>(readJson);
            
        }
    }
}