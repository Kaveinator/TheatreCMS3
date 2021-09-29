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
            string fileName = "/SiteSettings.json";
            string readJson = File.ReadAllText(fileName);
            SiteSettings siteSettings = JsonConvert.DeserializeObject<SiteSettings>(readJson);
            Console.ReadLine();
        }
    }
}