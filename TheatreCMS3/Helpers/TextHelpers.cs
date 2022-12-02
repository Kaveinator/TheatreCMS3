using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Helpers
{
    public class TextHelpers
    {
        public static string CharacterLimit(string content, int numOfCharacters)
        {
            if (content.Length <= numOfCharacters)
            {
                return content;
            }
            else
            {
                return content.Substring(0, numOfCharacters) + ("...");
            }
        }
        /// <summary>
        /// Limits the number of words that are displayed. Takes in a string from user and an int.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="numOfWords"></param>
        /// <returns>Returns a string cutoff at int.</returns>
        public static string LimitWords(string content, int numOfWords) // Creatign a new method
        {
            string[] word = content.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries); //Created a new array using Split Method. 

            if (numOfWords <= 0)
            {
                return content;
            }
            else if (word.Length > numOfWords)
            {
                var result = word.Take(numOfWords); //Taking string array word and returning specific number of entries. 
                return $"{string.Join(" ", result)}..."; //turning the string array into a string using $. (" ") specifies space. 
            }
            else
            {
                return content;
            }

        }
    }
}