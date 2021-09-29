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
        public DateTime CommentDate { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }

        //setting a fully defined Relationship
        public virtual int BlogPostId { get; set; }
        public virtual BlogPost BlogPost { get; set; }

        public Comment() { CommentDate = DateTime.Now; }
        public double LikeRatio()
        {
            double ratio = Likes /(Likes + Dislikes) * 100;
            return ratio;
        }
        
    }
}