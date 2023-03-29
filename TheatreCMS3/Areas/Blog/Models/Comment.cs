namespace TheatreCMS3.Areas.Blog.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using TheatreCMS3.Models;

    public partial class Comment
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
            double Ratio = Likes * 100 / (Likes + Dislikes);
            return Ratio;
        }
    }
}
