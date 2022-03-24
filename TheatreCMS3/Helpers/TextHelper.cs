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
    }
}