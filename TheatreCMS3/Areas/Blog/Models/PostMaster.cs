using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Blog.Models
{
    public class PostMaster : ApplicationUser
    {
        public int PublishedBlogPosts { get; set; } //the total number of BlogPosts that this PostMaster has published to the public
        public int RejectedBlogPosts { get; set; } //the number of BlogPosts taht a BlogAuthor wrote that this PostMaster has rejected
        public int PendingBlogPosts { get; set; } //the number of BlogPosts that are waiting for the PostMaster to review
    }
}