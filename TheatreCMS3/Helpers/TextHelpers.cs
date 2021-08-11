using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Helpers
{
    public static class TextHelpers
    {
        //creating a helper method that takes in a string value and an integer. The int value is set to a default of 8 unless overidden
        public static string Truncate(this string value, int maxLength = 8)
        {
            //creating an ellipses variable to add onto the truncated string before it is returned
            string ellipses = "...";
            //checks to see if the string is null or not. If it is, there is no need to truncate so it is returned.
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }
            //if there it is not null then the following lambda expression is executed
            //it checks the value string length against the maxLength. If the value length is equal to or smaller then it is returned.
            //If it is greater than maxLength, then it is cut down to the size requested by the maxLength and is returned with the ellipses attached to the end
            else
            {
                return value.Length <= maxLength ? value : value.Substring(0, maxLength) + ellipses;
            }
        }
    }
}