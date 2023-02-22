using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Helpers
{
    public static class TextHelpers
    {
        public static string Truncate(this string value, int maxLength)
        {
            // Check for valid string first
            if (string.IsNullOrEmpty(value)) return value;

            // If value is valid string, then proceed with method
            var newString = string.Empty;
            if (value.Length > maxLength)
            {
                newString = value.Substring(0, maxLength) + "...";                
            }
            else
            {
                newString = value;
            }
            return newString;
        }
    }
}