using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
        public static string LimitWords(string content, int maxWords)
        {
            if (content == null || content.Length < maxWords || maxWords <= 0) return content;

            string trimSpaces = Regex.Replace(content, @"\s+", " ").Trim();

            string[] trimmed = trimSpaces.Split(' ').Take(maxWords).ToArray();
            content = String.Join(" ", trimmed);

            return content + "...";
        }

    }
}