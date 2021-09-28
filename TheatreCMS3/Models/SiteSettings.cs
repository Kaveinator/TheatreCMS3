using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace TheatreCMS3.Models
{
    public class CopyrightSetting
    {
        public int Copyright { get; set; }

    }

    public class Program
    {
        public static void ReadSiteSettings()
        {
            string fileName = "/SiteSettings.json";
            string readJson = File.ReadAllText(fileName);
            CopyrightSetting copyrightSetting = JsonConvert.DeserializeObject<CopyrightSetting>(readJson);

            Console.WriteLine(copyrightSetting.Copyright);
            Console.ReadLine();
        }
    }
}