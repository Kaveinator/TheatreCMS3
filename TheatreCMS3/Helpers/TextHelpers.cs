using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Helpers
{
    public static class TextHelpers
    {
        public static string LimitWords(this string stringInput,
            int wordLimit)
        {
            // Check for valid string before attempting to truncate
            if (string.IsNullOrEmpty(stringInput)) return stringInput;

            while (stringInput.Contains("  "))                //This while loop reduces double spaces to single spaces so ghost words aren't counted.
                stringInput = stringInput.Replace("  ", " ");

            int countWords = stringInput.Split().Length; //This Split function counts the amount of spaces in the string and adds 1 to give a word count.

            int spaceCount = 0;
            for (int i = 0; i < wordLimit; i++) //Use a loop to find the location of the space in which the " " of the last word in the limit is.
            {
                spaceCount = stringInput.IndexOf(" ", spaceCount + 1);
            }

            return stringInput.Substring(0, stringInput.IndexOf(" ", spaceCount))+"..."); //Returns substring ending at word limit and adds elipses at the end of string.
        }
    }
}