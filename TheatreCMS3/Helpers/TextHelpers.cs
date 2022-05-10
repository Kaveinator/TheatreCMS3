using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Helpers
{
    public class TextHelpers
    {

        public static string characterLimit(string text, int allowedCharAmount)  // This method will limit the amount of characters in a string and replace the last 3 digits with ...
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;  // if empty return empty // allows for user input useage 
            }
            if (text.Length < allowedCharAmount) // if under or equal to specified character amount do nothing
            {
                return text;
            }
            else
            {
                return text.Substring(0, allowedCharAmount) + "..."; // if string is over the specified character limit replace end of string with ...
            }
        }
    }
}