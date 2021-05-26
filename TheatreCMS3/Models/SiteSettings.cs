using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization; // for serialize and deserialize  
 
namespace TheatreCMS3.Models
{   
    public class SiteSettings
    {
        public int number { get; set; }

        public static void ReadSiteSettings()
        {
            //Read the file into a string format and deserialize JSON to a type.
            string filePath = Server.MapPath("~/TheatreCMS3/SiteSettings.json");
            string jsonString = System.IO.File.ReadAllText(filePath);
            //Deserializes the JSON directly from the file.
            SiteSettings ss = JsonConvert.DeserializeObject<SiteSettings>(jsonString);
        }
    }  
}