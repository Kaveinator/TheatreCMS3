using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Models
{
    
    // Class created to deserialize "SiteSettings.json" file and creates an object based on this class and assigns it the value obtained from the json file
    public class SiteSettings
    {
        public int Copyright { get; set; }
        
        // This is the method that deserializes "SiteSettings.json" and assigns the value to the "SiteSettings" class object "Copyright" property.
        public static void ReadSiteSettings()
        {
            var path = Path.Combine(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "SiteSettings.json"));
                        
            // This code block deserializes the json file and this one creates an object based off the class and assigns the property "Copyright" the value of "2021"
            var jsonContent = File.ReadAllText(path);
            SiteSettings siteSettings = JsonConvert.DeserializeObject<SiteSettings>(jsonContent);
            Console.WriteLine(siteSettings.Copyright);
        }
    }
}