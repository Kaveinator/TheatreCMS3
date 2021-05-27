using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace TheatreCMS3.Models
{   
    public class SiteSettings
    {
        public int copyright { get; set; }

        public static void ReadSiteSettings()
        {
            //Grab the file path.
            var filePath = HostingEnvironment.MapPath("~/SiteSettings.json");
            //Read the file into a string format and deserialize JSON to a type.
            StreamReader r = new StreamReader(filePath);
            string jsonString = r.ReadToEnd();
            //Deserializes the JSON directly from the file.
            SiteSettings ss = JsonConvert.DeserializeObject<SiteSettings>(jsonString);
        }
    }  
}