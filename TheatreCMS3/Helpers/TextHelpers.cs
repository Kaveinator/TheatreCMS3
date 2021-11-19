using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Helpers
{
    public class TextHelpers
    {


        //creating a method named LimitWords that takes in a string and an int.
        //The int represents how many words are allowed before cutting off the string and adding ellipses (...)
        public static string LimitWords(string userText, int wordLimit = 10)
        {

            //if an empty string is sent to the method, if the integer is negative or 0
            if (userText == "")
            {
                return "";
            }
            if (wordLimit <= 0)
            {
                return userText;
            }

            //This removes all unnecessary space at beginning of string and at the end of it
            string trimmedUser = userText.TrimStart().TrimEnd();

            int a = 0, wordCount = 1;

            while (trimmedUser.Contains("  "))
            {
               trimmedUser = trimmedUser.Replace("  ", " ");
            }

            

            while (a <= trimmedUser.Length - 1)
            {
                if (trimmedUser[a]==' ' || trimmedUser[a]=='\n' || trimmedUser[a] == '\t')
                {
                    wordCount++;
                }
                a++;
            }

            //if an empty string is sent to the method, if the integer is negative or 0
            if (userText == null)
            {
                return "";
            }
            if (userText == "")
            {
                return "";
            }
            if (wordLimit <= 0)
            {
                return trimmedUser;
            }

            
            if (wordCount > wordLimit)
            {
                int g = 0;
                for (int i = 0; i < wordLimit; i++)
                {
                    g = trimmedUser.IndexOf(' ', g+1);
                }
                return trimmedUser.Substring(0, trimmedUser.IndexOf(' ', g)) + "...";
                      
            }
            else
            {
                return trimmedUser;
            }

            



        }
        
    }
}
