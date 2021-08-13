using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Blog.Models
{
    public class Comment
    {
        public Comment()
        {
            CommentDate = DateTime.Now;
        }
        [Key]
        public int CommentId { get; set; }
        public ApplicationUser Author { get; set; }
        [DisplayName("User Name")]
        public string Message { get; set; }
        [DisplayName("Comment")]
        public DateTime CommentDate { get; set; }
        [DisplayName("Time Posted")]
        public int Likes { get; set; }
        [DisplayName("Likes")]
        public int Dislikes { get; set; }
        [DisplayName("Dislikes")]
        public double LikeRatio() => Convert.ToDouble(Likes / (Likes + Dislikes) * 100);
    }
}