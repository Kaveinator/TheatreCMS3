using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Helpers
{
    public class TextHelpers
    {
        public static string CharLimit(string content, int cutoff = 15)
        {
            if (content == null || content.Length < cutoff) return content;
            return content.Substring(0, cutoff) + "...";
        }
    }
}