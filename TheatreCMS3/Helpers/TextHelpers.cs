using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Helpers
{
    public class TextHelpers
    {        
        public static string Truncate(string phrase, int ellipsisCount)
        {
            // If string argument 'phrase' is null or empty, it is returned unmodified.
            if (string.IsNullOrEmpty(phrase))
            {
                return phrase;
            }

            /* 
                By using ternary operator, we're able to compare string length with int 'ellipsisCount'.
                If string length is less than or equal to 'ellipsisCount', string 'phrase' is returned unmodified.
                If string length is greater than or equal to 'ellipsisCount', 'phrase' is modified using the
                'Substring' method which selects elements starting at index '0' through index 'ellipsisCount'.
                We then concatenate three dots to this new 'Substring'. 
            */
            return phrase.Length <= ellipsisCount ? phrase : phrase.Substring(0, ellipsisCount) + "...";
        }
    }
}