using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Models
{
    public class SiteSettings
    {
        public int Copyright { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }


        public static SiteSettings ReadSiteSettings()
        {
            SiteSettings items;
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = System.IO.Path.Combine(sCurrentDirectory, "SiteSettings.json");

            using (StreamReader r = new StreamReader(sFile)) 
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<SiteSettings>(json);
            }

            return items;
        }
    }  

}