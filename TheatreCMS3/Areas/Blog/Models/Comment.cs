using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Blog.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public ApplicationUser Author { get; set; }
        public string Message { get; set; }
        public DateTime CommentDate { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }

        public Comment()
        {
            CommentDate = DateTime.Now;
        }




        public static int LikeRatio(int likes, int dislikes)
        {
            double ratio = ((double)likes) / ((double)likes + (double)dislikes) * 100;
            return Convert.ToInt32(ratio);
        }

        /// <summary>
        /// Takes a DateTime and tells you how many days, hours, minutes, and 
        /// seconds have passed since the input parameter
        /// </summary>
        /// <param name="commentDate"></param>
        /// <returns>Returns a formatted string telling you how long it has been since the inputted date time. </returns>
        public static string CommentTimePassed(DateTime commentDate)
        {
            string returnString = "";
            List<string> returnStringList = new List<string>();
            returnStringList.Add((DateTime.Now - commentDate).Days.ToString() + " Days,");
            returnStringList.Add((DateTime.Now - commentDate).Hours.ToString() + " Hours,");
            returnStringList.Add((DateTime.Now - commentDate).Minutes.ToString() + " Minutes,");
            returnStringList.Add((DateTime.Now - commentDate).Seconds.ToString() + " Seconds ago");
            for (int i = 0; i < returnStringList.Count; i++)
            {
                if (returnStringList[0].Contains("0 "))
                {
                    returnStringList.RemoveAt(0);
                }
            }

            for (int i = 0; i < returnStringList.Count; i++)
            {
                returnString += returnStringList[i].ToString() + " ";
            }

            return returnString;
        }
    }


}