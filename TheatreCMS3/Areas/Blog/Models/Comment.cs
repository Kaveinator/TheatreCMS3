using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TheatreCMS3.Models;


// Create a model in the Blog area called Comment.
namespace TheatreCMS3.Areas.Blog.Models
{
    public class Comment
    {
        [Key]                   // The Key attribute can be applied to a property to make it a key property in an entity class and the corresponding column to a primary key column in the database.
        public int CommentId { get; set; }
        public ApplicationUser Author { get; set; }
        public string Message { get; set; }
        public DateTime CommentDate { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        // public properties does not require restating inside constructor or methods.

        // The Comment constructor should set the CommentDate to the current time.
        // constructor is called when a comment object is made, no arguments is required, as it can access all properties required.
        public Comment ()               
        {
            CommentDate = DateTime.Now;
        }

        // The LikeRatio method should return the percentage of Likes to total votes (Likes + Dislikes).
        // following can be a separate class & inherit Comments if it is a subclass. then argument with properties is required in ().
        public double LikeRatio()
        {
            double LikeRatio = (Likes / Convert.ToDouble(Likes + Dislikes)) *100;       // percentage. Must convert to double before division. int divide double = double. Int will truncates decimals.   
            LikeRatio = Math.Round(LikeRatio, 2);                       // limit to 2 decimal place
            return LikeRatio;                                           // Must have a return for method
        }
    } 
}