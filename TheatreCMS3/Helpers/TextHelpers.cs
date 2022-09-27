using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Helpers
{
    public class TextHelpers
    {
        public static string CharLimit (string chars, int limit)
        {
            if (chars.Length > limit) { chars = chars.Substring(0, limit) + "..."; }
            return chars;
        }
    }
}