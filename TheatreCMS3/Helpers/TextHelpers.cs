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


        public static string LimitWords(string UserText, int maxLength)//The method should take in a string and an integer.
        {
           
            string suf = "...";//initialize the ellipsis

            //string UTnoSpaces = UserText.Replace(@"\s+", " ");// this should make any double spaces tabs and new lines into single spaces
            //string UTtrim = UTnoSpaces.TrimStart().TrimEnd();
            

            if (UserText == "")//check for if the string is null or if the max length is 0 or negative.
            {
                return "";//If an empty string is sent, return an empty string. If negative or 0, return the entire string without limiting.
            }

            if (maxLength <= 0)//check for if the string is null or if the max length is 0 or negative.
            {
                return UserText;//If an empty string is sent, return an empty string. If negative or 0, return the entire string without limiting.
            }
            string UTtrim = UserText.TrimStart().TrimEnd();
            int l = 0;
            int wrd = 1;
            while(UTtrim.Contains("  "))
            {
                UTtrim = UTtrim.Replace("  "," ");
            }

            while (l <= UTtrim.Length - 1)//loop till end of string
            {
                /* check whether the current character is white space or new line or tab character*/
                if (UTtrim[l] == ' ' || UTtrim[l] == '\n' || UTtrim[l] == '\t')
                {
                    wrd++;
                }
                l++;
            }

            if (UserText == null)
            {
                return "";
            }


            if (UserText == "")
            {
                return "";
            }
            
            if (maxLength <= 0)
            {
                return UTtrim;
            }
            if (wrd > maxLength)
            {
                int g = 0;
                for (int i = 0; i < maxLength; i++)
                {
                    g = UTtrim.IndexOf(' ', g + 1);
                }

                return UTtrim.Substring(0, UTtrim.IndexOf(' ', g)) + suf;//truncate the string and append the ellipsis
            }
            else
            {
                return UTtrim;
            }
        }
    }
}