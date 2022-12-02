using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Helpers
{
    public static class TextHelpers
    {
        public static string TruncateWord(this string yourString, int maxLength)
        {
            if (yourString == null || yourString.Length < maxLength)
            {
                return yourString;
            }
            else
            {
                return yourString.Substring(0, Math.Min(maxLength, yourString.Length)) + "...";
            }
        }
    }
}