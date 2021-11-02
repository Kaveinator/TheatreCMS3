using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Helpers
{
    public class TextHelpers
    {

        public static string StrEllipsis(string txtString, int strLength)
        {
            if (txtString.Length > strLength)
            {
                return txtString.Substring(0, strLength) + (char)0x2026;
            }
            else
            {
                return txtString;
            }

        }
        
    }
}

// Text Helper Part 1: Character Limit Helper Method
// 1. Create a folder in the main project, if it doesn't already exist, called "Helpers".
// 2. Create a new C# class in that folder called "TextHelpers". 
// 3. Create a static method in that class that takes in a string and an integer.
// 4. he string is the content that we are trying to truncate and the integer represents
        // how many characters are allowed before cutting off the string and adding ellipses ( . . . ).
// 5. To test your method, go to the Home > About > Company History page and use the
        // helper method to limit the number of characters of one of the properties.