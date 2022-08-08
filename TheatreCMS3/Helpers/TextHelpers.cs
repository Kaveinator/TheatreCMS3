using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Helpers
{
    public class TextHelpers
    {
        //Truncates a string to show only the first n characters adding an elpise only if it removes characters
        public static string TxtTruncate (string str, int n)
        {
            if (str.Length > n)
            {
                string newString = str.Substring(0, n) + "...";
                return newString;
            } else
            {
                return str;
            }
        }
    }
}