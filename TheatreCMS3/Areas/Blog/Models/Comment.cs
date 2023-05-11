using System;
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

        public double LikeRatio()
        {
            if (Likes + Dislikes == 0)
            {
                return 0;
            }
            return (double)Likes / (Likes + Dislikes) * 100;
        }
    }
}