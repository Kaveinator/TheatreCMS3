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
        public int number { get; set; }

        public static void ReadSiteSettings()
        {
            //Read the file into a string format and deserialize JSON to a type.
            StreamReader r = new StreamReader(@"C:\Users\asand\source\repos\TheatreCMS3\TheatreCMS3\SiteSettings.json");
            string jsonString = r.ReadToEnd();
            //Deserializes the JSON directly from the file.
            SiteSettings ss = JsonConvert.DeserializeObject<SiteSettings>(jsonString);
        }
    }  
}