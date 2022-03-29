using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Helpers
{
    public class TextHelper
    {
        public static string helper(string input, int num)
        {

            //converts a string to a character array
            char[] ch = input.ToCharArray();


            //loops through the array from the last element to the first, and replaces each element with a "."
            for (int i = ch.Count(); i > num; i--)
            {

                //if (ch[i - 1] == ' ')
                //{
                //    continue;
                //}
                ch[i - 1] = '.';

            }

            //converts character array back to string to be returned by the method
            string output = new string(ch);
            return output;


        }

        // this method will limit the amount of characters in a string
        public static string LimitCharacters(string text, int length)
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }

            if (text.Length <= length)
            {
                return text;
            }
            // looking for spaces in the beginning of text and omitting it
            if (text.Contains("  " + text))
            {
                return text.TrimStart();
            }
            // and at the end as well
            if (text.Contains(text + "  "))
            {
                return text.TrimEnd();
            }
            // changing any double spacing to single spaces
            while (text.Contains("  "))
            {
                text = text.Replace("  ", " ");
            }
            // checking the text count, iterating through it, returning 
            if (text.Count() >= length)
            {
                int x = 0;
                for (int i = 0; i < length; i++)
                {
                    x = text.IndexOf("", x + 1);
                }
                return text.Substring(0, text.IndexOf("", x)) + "...";
            }
            else
            {
                return text;
            }

            //here we will look for any characters that we could shorten the sentence at
            char[] delimiters = new char[] { ' ', '.', ',', ':', ';' };
            int index = text.LastIndexOfAny(delimiters, length - 3);

            if (index > (length / 2))
            {
                return text.Substring(0, index) + "...";
            }
            else
            {
                return text.Substring(0, length - 3) + "...";
            }
        }

    }
}