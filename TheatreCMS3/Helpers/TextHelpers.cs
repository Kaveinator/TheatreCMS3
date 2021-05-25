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
    }
}