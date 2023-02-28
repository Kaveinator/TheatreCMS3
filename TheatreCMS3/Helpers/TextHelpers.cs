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

        public static string LimitWords(string value, int maxWords)
        {
            if (string.IsNullOrEmpty(value)) return value;

            int wordCount = 0, index = 0;

            // skip whitespace until first word
            while (index < value.Length && char.IsWhiteSpace(value[index]))
                index++;

            while (index < value.Length)
            {
                // check if current char is part of a word
                while (index < value.Length && !char.IsWhiteSpace(value[index]))
                    index++;

                wordCount++;

                // skip whitespace until next word
                while (index < value.Length && char.IsWhiteSpace(value[index]))
                    index++;
            }

            var newWords = string.Empty;

            if (maxWords < 0 || maxWords == 0) return value;
            if (value.Length > maxWords)
            {
                newWords = value.Substring(0, maxWords) + "...";
            }
            else
            {
                newWords = value;
            }

            return newWords;    
        }
}
}