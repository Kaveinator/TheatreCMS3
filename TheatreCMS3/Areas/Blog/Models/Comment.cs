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
        public DateTime CommentDate { get { return DateTime.UtcNow; } }
        public int Likes { get; set; }
        public int Dislikes { get; set; }

        public double LikeRatio()
        {
            double likeRatio = Likes / (Likes + Dislikes);
            return likeRatio;
        }

    }
}