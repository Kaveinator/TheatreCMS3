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
    }
}