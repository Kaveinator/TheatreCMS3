using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Helpers
{
    public class TextHelper
    {
        public static string Truncate(string inputString, int numCharacters)
        {
            string truncatedString = "";

            int maxLength = Math.Min(inputString.Length, numCharacters);
            truncatedString = inputString.Substring(0, maxLength) + "...";
            return truncatedString;


        }
    }
}