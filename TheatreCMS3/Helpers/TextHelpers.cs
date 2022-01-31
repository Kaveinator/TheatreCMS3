using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Helpers
{
    public static class TextHelpers
    {
        //method that truncates a string to a specified length (inclusive)
        public static string Truncate(this string @this, int maxLength)
        {
            //initialize the ellipsis
            const string suffix = "...";

            //check for if the string is null or if the string length is
            //shorter than or equal to the desired truncation length
            if (@this == null || @this.Length <= maxLength)
            {
                return @this;
            }

            //truncate the string and append the ellipsis
            return @this.Substring(0, maxLength) + suffix;
        }
    }
}