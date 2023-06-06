using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheatreCMS3.Models;

//Creates a model in the Blog area called Comment | model will represent a user's comment on a blog post
namespace TheatreCMS3.Areas.Blog.Models
{
    public class Comment
    {
        //defining the Comment class with appropriate properties and methods
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

            return (double)Likes / (Likes + Dislikes);
        }
    }
}