using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Helpers
{
    public class TextHelpers
    {
        public static string Truncate(string text, int length)
        {
            if (string.IsNullOrEmpty(text)) return text; else if (text.Length <= length) return text;
            while (text[length] == char.Parse(" ")) length -= 1;
            return text.Substring(0, length) + "...";
        }
    }
}