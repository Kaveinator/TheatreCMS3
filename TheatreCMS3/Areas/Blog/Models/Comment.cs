using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Blog.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Author { get; set; }
        public string Message { get; set; }
        public DateTime CommentDate { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
       
        public Comment()
        {
            CommentDate = DateTime.Now;
        }

        public double LikeRatio()
        {
            int totalVotes = Likes + Dislikes;
            double ratio = Likes / Convert.ToDouble(totalVotes);
            double votePercentage = ratio * 100;
            return votePercentage;
        }
    }
     


}