using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Blog.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        public string Author { get; set; }
        public string Message { get; set; }
        public DateTime CommentDate { get; set; }
        public int Likes { get; set; }
        public int DisLikes { get; set; }

        public double likeRatio()
        {
            double totalLikes = Convert.ToDouble(Likes + DisLikes);
            double LikeRatio = Convert.ToDouble(Likes / totalLikes);
            LikeRatio = LikeRatio * 100;
            return LikeRatio;
        }
    }
}