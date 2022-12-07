using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Helpers
{
    public static class TextHelpers
    {
        public static string TruncateWord(this string yourString, int maxLength)
        {
            if (yourString == null || yourString.Length < maxLength)
            {
                return yourString;
            }
            else
            {
                return yourString.Substring(0, Math.Min(maxLength, yourString.Length)) + "...";
            }
        }
        public static string LimitWords(this string wordString, int maxWords) // This method takes in a string and max words 
        {
            if (wordString == null || maxWords <= 0) // if nothing is entered string returns nothing if
                                                     // max words argument is 0 or negative it returns the original string
            {
                return wordString.Trim(); // this is the string plus trim so spaces before or after string are never returned
            }
            else
            {
                // This returns a string seperated by spaces and concatonates the string,
                // it also removes multiple occurenecs of empty spaces and returns to the new word variable the requested max words argument
                // as well it trims the white space before and after so that there are no preceeding spaces and when conacatonating with the elipses
                // in the new Word String variable there is no chance of of spaces occuring before them
                string newWordString = String.Join(" ", wordString.Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries).Take(maxWords)).Trim();
                return newWordString + "..."; 
            }

        }
    }
}