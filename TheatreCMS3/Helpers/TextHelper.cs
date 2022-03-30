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
        
        public static string LimitSentenceLength(string text, int length)
        {
            // creating a string array from the text 
            //string[] words = text.Split(' ').Take(length).ToArray();
            //text = string.Join(" ", words);
            

            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }
            if (text.Length <= length)
            {
                return text;
            }
            string trimmedText = text.TrimStart().TrimEnd();

            int a = 0;
            int wordCount = 1;
            // looking for spaces in the beginning of text and omitting it
           
            // changing any double spacing to single spaces
            while (trimmedText.Contains("  "))
            {
                text = text.Replace("  ", " ");
            }
            while (a <= trimmedText.Length - 1)
            {
                if (trimmedText[a] == ' ' || trimmedText[a] == '\n' || trimmedText[a] == '\t')
                {
                    wordCount++;   
                }
                a++;
            }
            if (wordCount > length)
            {
                int x = 0;
                for (int i = 0; i < length; i++)
                {
                    x = trimmedText.IndexOf(" ", x + 1);
                }
                return trimmedText.Substring(0, trimmedText.IndexOf(" ", x)) + "...";
            }
            else
            {
                return trimmedText;
            }
           

            //here we will look for any characters that we could shorten the sentence at
            //char[] delimiters = new char[] { ' ', '.', ',', ':', ';' };
            //int index = text.LastIndexOfAny(delimiters, length - 3);

            //if (index > (length / 2))
            //{
            //    return text.Substring(0, index) + "...";
            //}
            //else
            //{
            //    return text.Substring(0, length - 3) + "...";
            //}
        }

    }
}