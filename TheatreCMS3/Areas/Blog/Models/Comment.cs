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
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public DateTime CommentDate { get; set; }

        public Comment()
        {
            CommentDate = DateTime.Now;
        }

        public double LikeRatio()
        {
            double totalVotes = Likes + Dislikes;
            if (totalVotes == 0)
            {
                return 0;
            }
            return (Likes / totalVotes) * 100;
        }
    }
}