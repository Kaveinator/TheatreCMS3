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
        //Creates the method with 2 parameters
        public static string LimitWords(string userText, int wordLimit = 4)
        {
          //if an empty string is sent to the method, if the integer is negative or 0
          if (userText == "")
            {
                return "";
            }
          //If the number of words is less than 0 or less than, just return the user text
          if (wordLimit <= 0)
            {
                return userText;
            }
            //This removes all unnecessary space at beginning of the string and at the endof it
            string trimmedUser = userText.TrimStart().TrimEnd();
            //This creates variables for our while statement to check for characters
            int a = 0, wordcount = 1;
            //Cretes a while statement that checks for spacing 
            while (trimmedUser.Contains("  "))
            {
             // This replaces all double spaces with single space   
                trimmedUser = trimmedUser.Replace("  ", " ");
            }
            // While the characeters are less than or equal or less than 1,do these things
            while (a <= trimmedUser.Length-1)
            {
                if (trimmedUser[a]== ' '|| trimmedUser[a]=='\n' || trimmedUser[a]== '\t')
                {
                    wordcount++;
                }
                a++;
            }
            //If an empty string is sent to the method, if the integer is negative or 0
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
            if (wordcount > wordLimit)
            {
                int g = 0;
                for(int i = 0; i < wordLimit; i++)
                {
                    g = trimmedUser.IndexOf(' ', g + 1);
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
