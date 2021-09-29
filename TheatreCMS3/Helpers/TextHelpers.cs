using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Helpers
{
    public static class TextHelpers
    {
        public static string Truncate(this string value,
            int maxLength,
            bool addEllipsis = false)
        {
            // Check for valid string before attempting to truncate
            if (string.IsNullOrEmpty(value)) return value;

            // Proceed with truncating
            var result = string.Empty;
            if (value.Length > maxLength)
            {
                result = value.Substring(0, maxLength);
                if (addEllipsis) result += "...";
            }
            else
            {
                result = value;
            }

            return result;
        }
          
    }
}