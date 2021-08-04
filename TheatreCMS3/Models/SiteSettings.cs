using System.IO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TheatreCMS3.Models
{
    public class SiteSettings : ApplicationDbContext
    {
        public int ReadSiteSettings { get; set; }

        public void Deserializer()
        {
            SiteSettings siteSettings1 = JsonConvert.DeserializeObject<SiteSettings>(File.ReadAllText(@"C:\Users\8 7\Desktop\LiveProject\TheatreCMS3\SiteSettings.json"));

            using (StreamReader file = File.OpenText(@"C:\Users\8 7\Desktop\LiveProject\TheatreCMS3\SiteSettings.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                SiteSettings siteSettings = (SiteSettings)serializer.Deserialize(file, typeof(SiteSettings));
            }
            return;
        }
        
    }

   





}

