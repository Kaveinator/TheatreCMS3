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

        public double LikeRatio()
        {
            double totalLikes = Convert.ToDouble(Likes + DisLikes);
            double TotLikeRatio = Convert.ToDouble(Likes / totalLikes);
            TotLikeRatio *= 100;
            return TotLikeRatio;
        }
        public double DislikeRatio()
        {
            double totalLikes = Convert.ToDouble(Likes + DisLikes);
            double TotDislikeRatio = Convert.ToDouble(DisLikes / totalLikes);
            TotDislikeRatio *= 100;
            return TotDislikeRatio;
        }
    }
}