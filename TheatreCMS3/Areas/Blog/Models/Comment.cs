
using Microsoft.AspNet.Identity;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Blog.Models
{
    public class Comment
    {
        public Comment()
        {
            CommentDate = DateTime.Now;
            // supposed to set author to current application user here, right? 
        }

        [Key]
        public int CommentId { get; set; }
        public ApplicationUser Author { get; set; }
        public string Message { get; set; }
        public DateTime CommentDate { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }

        public double LikeRatio()
        {
            double likeRatio = Likes / (Likes + Dislikes);
            return likeRatio;
        }

        public string TimeSincePost()
        {
            TimeSpan timeSincePost = DateTime.Now - CommentDate;
            if (timeSincePost.TotalMinutes < 60)
            {
                string str = Math.Round(timeSincePost.TotalMinutes).ToString() + " minutes ago";
                return str;
            }
            else
            {
                if (Math.Round(timeSincePost.TotalHours) < 2)
                {
                    string str = Math.Round(timeSincePost.TotalHours).ToString() + " hour ago";
                    return str;
                }
                else
                {
                    string str = Math.Round(timeSincePost.TotalHours).ToString() + " hours ago";
                    return str;
                }

            }
        }

    }
}