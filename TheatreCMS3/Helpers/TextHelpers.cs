using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Helpers
{
    
        public static class TextHelpers
        {
            public static string TextHelp(string value, int number)
            {


            if (number >= value.Length)
            {
                return value;
            }
            else
            {

                return value.Substring(0, number) + "...";
            }
            }
        }



    
}