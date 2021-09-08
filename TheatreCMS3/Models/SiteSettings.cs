using System;
using System.Collections.Generic;
using System.IO;
//using System.Text.Json;
using Newtonsoft.Json;

namespace SiteSettings
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
            string readjson = File.ReadAllText(fileName);
            CopyrightSetting copyrightSetting = JsonConvert.DeserializeObject<CopyrightSetting>(readjson);
        }
    }
}