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


        public static void ReadSiteSettings()
        {
            using (StreamReader r = new StreamReader("file.json"))
            {
                string json = r.ReadToEnd();
                SiteSettings items = JsonConvert.DeserializeObject<SiteSettings>(json);
            }
        }
    }  
}