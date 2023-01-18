using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Helpers
{
    public class TextHelpers
    {
        public static string Truncate(string value, int maxChars)
        {
            return value.Length <= maxChars ? value : value.Substring(0, maxChars) + "...";
        }


        public static string LimitedWords(string words, int maxWords)
        {
            if (words == null || words.Length < maxWords || maxWords <= 0) return words;

            string trimmed = words.Trim();

            string[] text = trimmed.Split(' ').Take(maxWords).ToArray();
            foreach (var x in text)
            {
                x.Trim();
            }
            words = String.Join(" ", text);
   
            return words + "...";
        }
    }
}