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
        public string Author { get; set; }
        public string Message { get; set; }
        public DateTime CommentDate { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }



        public double LikeRatio()
        {
            int likes = Likes;
            int dislikes = Dislikes;
            int totalLikes = dislikes + likes;
            double percentage = likes / totalLikes;
            return percentage;
        }

    }
}