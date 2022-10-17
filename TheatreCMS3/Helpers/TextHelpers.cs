using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace TheatreCMS3.Helpers
{
    public class TextHelpers
    {
        public static string CharLimit (string chars, int limit)
        {
            if (chars.Length > limit) { chars = chars.Substring(0, limit) + "..."; }
            return chars;
        }

        public static string LimitWords (string words, int limit)
        {
            // if input is an empty string, return an empty string
            if (words == "")
            {
                return words;
            }
            // if input limit is 0 or negative, return the entire string
            if (limit < 1)
            {
                return words;
            }

            // split the input string into a List of individual words that can be manipulated
            List<string> wordsList = words.Split(' ').ToList();
            // instantiate a StringBuilder to hold the words to be returned
            var sbWords = new StringBuilder();
            // loop over the list of words until the desired number of words have been added to the StringBuilder
            for (int i = 0; i < limit; i++)
            {
                // if an item in the list is empty, that means there were extra spaces
                // the item is skipped and removed and the index for the loop is not incremented
                if (wordsList[i] == "")
                {
                    wordsList.RemoveAt(i);
                    i -= 1;
                    continue;
                }
                // otherwise add them to the StringBuilder
                sbWords.Append(wordsList[i]);
                // as long as it isn't the last word being added, also add a space
                if (i < limit - 1)
                {
                    sbWords.Append(" ");
                }
            }
            sbWords.Append("...");

            return sbWords.ToString();
        }
    }
}