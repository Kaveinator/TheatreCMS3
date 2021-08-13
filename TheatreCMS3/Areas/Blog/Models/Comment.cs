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
        {//constructor that sets CommentDate equal to whatever time it is when the comment is instantiated
            CommentDate = DateTime.Now;
        }
        [Key]
        public int CommentId { get; set; }
        public ApplicationUser Author { get; set; }
        public string Message { get; set; }
        public DateTime CommentDate { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public double LikeRatio() => Convert.ToDouble(Likes / (Likes + Dislikes) * 100);
        //lambda function that should be able to be called on to display the Percentage liked. May change in the future.
    }
}