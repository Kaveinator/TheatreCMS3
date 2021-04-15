using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Blog.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public ApplicationUser Author { get; set; }
        public string Message { get; set; }
        public DateTime CommentDate { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }

        public Comment()
        {
            CommentDate = DateTime.Now.ToUniversalTime();         
        }

        public double LikeRatio()
        {
            double likeRatio = Likes / (Likes + Dislikes);
            return likeRatio;
        }
        
        public string TimeSince()
        {
            TimeSpan ts = DateTime.Now.ToUniversalTime().Subtract(CommentDate);
            int days = ts.Days;
            int hours = ts.Hours;
            int minutes = ts.Minutes;
            int seconds = ts.Seconds;

            if (days == 1)
                return "Yesterday";
            if (days > 1)
                return string.Format("{0} days ago", days);
            if (hours > 0)
                return string.Format("{0} hours ago", hours);
            if (minutes > 0)
                return string.Format("{0} minutes ago", minutes);
            if (seconds > 0)
                return string.Format("{0} seconds", seconds);
            return "Just now";            
        }

        public void AddLike()
        {
            Likes++;
        }

        public void AddDislike()
        {
            Dislikes++;
        }


    }
}
