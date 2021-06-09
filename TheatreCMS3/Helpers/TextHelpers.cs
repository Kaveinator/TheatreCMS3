using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Helpers
{
    public class TextHelpers
    {
        public static string LimitCharacters(string targetText, int limit)
        {
            if (targetText.Length > limit)
            {
                // checks if string surpasses limit
                targetText = targetText.Substring(0, limit);

                // checks if the string ends in a space. If so it is removed.
                string spaceCheck = targetText.Substring(targetText.Length - 1);
                if (spaceCheck == " ")
                {
                    targetText = targetText.Remove(targetText.Length - 1, 1);
                }
                // concatinates an ellipses to the string
                targetText = targetText + "...";
            }

            return targetText;
        }


        public static string LimitWords(string inputText, int wordLimit)
        {
            // Sets our return value to empty
            string returnedSentence = string.Empty;
            // Getting all the words from the string array using the space
            string[] words = inputText.Split(' ');

            // If the words is less than the length or less than or equal to 0 we want we return all the words
            if (words.Length < wordLimit || wordLimit <= 0)
                return inputText;

            // Returns our return sentence with a space from the index value of our array
            for (int i = 0; i < wordLimit; i++)
            {
                returnedSentence = string.Concat(returnedSentence, " ", words[i]);
            }
            // Adding the ellipses to our returned sentence
            if (words.Length > wordLimit)
                returnedSentence += "...";

            // Trimming the first space from our concatination
            return returnedSentence.Trim();
        }
    }
}