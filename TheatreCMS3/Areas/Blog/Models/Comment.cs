using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheatreCMS3.Areas.Blog.Controllers;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Blog.Models
{
    public class Comment 
    {
        [Key]
        public int CommentID { get; set; }
        public virtual ApplicationUser Author { get; set; }
        public string Message { get; set; }
        public DateTime CommentDate { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        

        public Comment()
        {
            CommentDate = DateTime.Now;
        }


        public double LikesRatio()
        {
            return Likes / (Convert.ToDouble(Likes) + Dislikes);
        }

        

    }

  
}