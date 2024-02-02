using System;

namespace TheatreCMS3.Areas.Blog.Models
{
    public class BlogAuthor
    {
        public int BlogAuthorId { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public DateTime Joined { get; set; }
        public Nullable<DateTime> Left { get; set; }
    }
}