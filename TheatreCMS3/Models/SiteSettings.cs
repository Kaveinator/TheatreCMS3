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
            var filePath = @"C:\Users\asand\source\repos\TheatreCMS3\TheatreCMS3\SiteSettings.json";
            var invalidPath = new string(Path.GetInvalidPathChars());
            foreach(var c in invalidPath)
            {
                filePath = filePath.Replace(c.ToString(), "");
            }
            //Read the file into a string format and deserialize JSON to a type.
            SiteSettings m = JsonConvert.DeserializeObject<SiteSettings>(File.ReadAllText(filePath));
            //Deserializes the JSON directly from the file.
            using (StreamReader file = File.OpenText(File.ReadAllText(filePath)))
            {
                JsonSerializer serializer = new JsonSerializer();
                SiteSettings m2 = (SiteSettings)serializer.Deserialize(file, typeof(SiteSettings));
            }
        }
    }  
}