using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Helpers
{
    public class TextHelpers
    {
        public static string Truncate(string value,
            int maxLength,
            bool addEllipsis = false)
        {
            if (string.IsNullOrEmpty(value)) return value;

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