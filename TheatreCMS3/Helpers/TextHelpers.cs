using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Helpers
{
    public class TextHelpers
    {
        // return a limited character from the text
        // and add ellipse
        // @param
        //      - text: string
        //      - limit: int
        public static string LimitCharacter (string text, int limit)
        {
            //Check for null or empty value
            if (string.IsNullOrEmpty(text)) return text;
            return text.Substring(0, limit) + "...";
        }
    }
}